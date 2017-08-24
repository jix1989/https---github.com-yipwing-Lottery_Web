using LotteryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
namespace WebApplication1
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://XY.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        Random random = new Random();
        string gdjm = "ewd2asr87ghht9rt4wqw78e2qw778wds21x777gjd";//固定效验码
        /// <summary>
        /// 登录用户信息
        /// </summary>
        static Dictionary<string, Item_LoginIdDic> LoginIdDic = new Dictionary<string, Item_LoginIdDic>();
        /// <summary>
        /// 彩票信息
        /// </summary>
        static List<WS_Lotterys> LotteryList = new List<WS_Lotterys>();
        static AccountDAL AccountDAL = new AccountDAL();
        static LotteryOpenInfoDAL LotteryOpenInfoDAL = new LotteryOpenInfoDAL();
        static LotteryOpenOffcialInfoDAL LotteryOpenOffcialInfoDAL = new LotteryOpenOffcialInfoDAL();
        static LotteryBetInfoDAL LotteryBetInfoDAL = new LotteryBetInfoDAL();
        static PayDAL PayDAL = new PayDAL();
        public static int GetLoginId(string guid)
        {
            #region 30分钟失效
            var list = LoginIdDic.Where(n => n.Value.LoginTime.AddMinutes(30) < DateTime.Now).Select(n => n.Key).ToList();
            foreach (var item in list)
            {
                LoginIdDic.Remove(item);
            }
            #endregion
            if (LoginIdDic.ContainsKey(guid))
            {
                LoginIdDic[guid].LoginTime = DateTime.Now;
                return LoginIdDic[guid].Id;
            }
            return 0;
        }
        public static bool isLogin(string guid)
        {
            var accId = GetLoginId(guid);
            return accId > 0;
        }
        [WebMethod]
        public string HelloWorld()
        {
            var json = "HelloWorld";
            return json;
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        [WebMethod]
        public string LoginOn(string jm,string Guid, string Name, string Pwd)
        {
            if(!Tools.GetJmDic().ContainsValue(jm))
            {
                return "jm error";
            }
            if (LoginIdDic.ContainsKey(Guid))
            {
                LoginIdDic.Remove(Guid);
            }
            var acc = AccountDAL.LoginOn(Name, Pwd);
            if (acc != null)
            {
                LoginIdDic.Add(Guid, new Item_LoginIdDic { Id = acc.Id, LoginTime = acc.LastLogin.Value });
                return "true";
            }
            return "";
        }
        /// <summary> 
        /// 根据guid获取个人信息
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public Account GetAccountInfo(string Guid)
        {
            var accId = GetLoginId(Guid);
            if (accId <= 0)
            {
                return null;
            }
            var acc = AccountDAL.GetAccount(accId);
            return acc == null ? null : (new Account
             {
                 AccountBalance = acc.AccountBalance,
                 AccountName = acc.AccountName,
                 AccountNickname = acc.AccountNickname,
                 AgentPercent11X5 = acc.AgentPercent11X5,
                 AgentPercentDPC = acc.AgentPercentDPC,
                 AgentPercentSSC = acc.AgentPercentSSC,
                 BankCardLockStatus = acc.BankCardLockStatus,
                 CreateTime = acc.CreateTime,
                 LastLogin = acc.LastLogin,
                 LoginCount = acc.LoginCount,
             });
        }

        /// <summary>
        /// 获取彩种信息
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public List<WS_Lotterys> GetLotteryList(string Guid)
        {
            if (!(isLogin(Guid) || Tools.GetJmDic().ContainsValue(Guid)))
            {
                return null;
            }
            if (LotteryList.Count == 0)
            {
                foreach (var item in EntitiesTool.GetLotteryDic())
                {
                    LotteryList.Add(new WS_Lotterys
                    {
                        BetweenMinute = item.Value.BetweenMinute,
                        ExceptLength = item.Value.ExceptLength,
                        ExceptOneDay = item.Value.ExceptOneDay,
                        Id = item.Value.Id,
                        IsPrivate = item.Value.IsPrivate,
                        LotteryCode = item.Value.LotteryCode,
                        LotteryName = item.Value.LotteryName,
                        LotteryType = item.Value.LotteryType,
                        TimeEnd = item.Value.TimeEnd,
                        TimeStart = item.Value.TimeStart,
                    });
                };
            }
            return LotteryList;
        }
        /// <summary>
        /// 获取彩票玩法
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public List<LotteryPlays> GetLotteryPlayList(string Guid, string LotteryType)
        {
            if (!isLogin(Guid))
            {
                return null;
            }
            return EntitiesTool.GetLotteryPlayList(LotteryType);
        }
        /// <summary>
        /// 获取下一期开奖信息
        /// </summary>
        /// <param name="LotteryId">彩种id字符串用,隔开</param>
        /// <returns></returns>
        [WebMethod]
        public List<WS_LotteryOffcialSchedule> GetLotteryNextInfo(string Guid, List<int> LotteryId)
        {
            if (!isLogin(Guid))
            {
                return null;
            }
            var list = LotteryOpenOffcialInfoDAL.NextOpenNo(LotteryId);
            return list.Select(n => new WS_LotteryOffcialSchedule
            {
                Expect = n.Expect,
                LotteryId = n.LotteryId,
                ScheduleOpenTime = n.ScheduleOpenTime,
            }).ToList();
        }
        /// <summary>
        /// 获取开奖号集合
        /// </summary>
        /// <param name="Count">获取行数</param>
        /// <param name="LotteryId">彩种Id</param>
        /// <returns></returns>
        [WebMethod]
        public List<WS_LotteryOpenInfo> GetLotteryHistroyInfo(string Guid, int Count, int LotteryId)
        {
            if (!isLogin(Guid))
            {
                return null;
            }
            var list = LotteryOpenInfoDAL.LastOpen_Count(Count, LotteryId).ToList();
            return list.Select(n => new WS_LotteryOpenInfo
            {
                Expect = n.Expect,
                LotteryId = n.LotteryId,
                OpenCode = n.OpenCode,
                OpenTime = n.OpenTime,
            }).ToList();
        }
        [WebMethod]
        public DateTime GetDateTimeNow()
        {
            try
            {
                return DateTime.Now;
            }
            catch (Exception)
            {
                return DateTime.Now;
            }
        }

        [WebMethod]//9:查询已投注信息
        public List<WS_BetInfoDgv> GetBetInfoList(string Guid, int LotteryId, string Execpt, DateTime betTime)
        {
            var accId = GetLoginId(Guid);
            if (accId == 0)
            {
                return null;
            }
            var list = LotteryBetInfoDAL.GetBetInfoList(accId, LotteryId, Execpt, betTime);
            return list;
        }
        [WebMethod]
        public WS_BetInfoDgv GetBetInfo(string Guid, long Id)
        {
            if (!isLogin(Guid))
            {
                return null;
            }
            var list = LotteryBetInfoDAL.GetBetInfo(Id);
            return list;
        }
        /// <summary>
        /// 下单投注
        /// </summary>
        /// <param name="LotteryId"></param>
        /// <returns></returns>
        [WebMethod]
        public string SendBetInfo(string Guid, int LotteryId, string Except, List<WS_BetInfo> BetInfo)
        {
            if (!isLogin(Guid))
            {
                return null;
            }
            var l = EntitiesTool.GetLotteryDic().Values.FirstOrDefault(n => n.Id == LotteryId);
            if (l == null) { return "无该彩种信息"; }
            //if (l.LotteryType == "ssc")
            //{
            //    t.Add(new WS_BetInfo
            //        {
            //            BetMoney = 2,
            //            BetMoneyMode = "元",
            //            BetNum = "0|0|0|0|0",
            //            BetPlayTypeCode = 2,
            //            BetTimes = 1,
            //            BetUnit = 1,
            //            ChoicePosition = "",
            //            IsGetBackPercent = true,
            //        });
            //    t.Add(new WS_BetInfo
            //    {
            //        BetMoney = 6,
            //        BetMoneyMode = "角",
            //        BetNum = "0 1 2|0 1 2",
            //        BetPlayTypeCode = 116,
            //        BetTimes = 1,
            //        BetUnit = 30,
            //        ChoicePosition = "0,1,2,3,4",
            //        IsGetBackPercent = true,
            //    });
            //}
            //if (l.LotteryType == "11x5")
            //{
            //    t.Add(new WS_BetInfo
            //    {
            //        BetMoney = 2,
            //        BetMoneyMode = "元",
            //        BetNum = "04|05|06",
            //        BetPlayTypeCode = 1,
            //        BetTimes = 1,
            //        BetUnit = 1,
            //        ChoicePosition = "",
            //        IsGetBackPercent = false,
            //    });
            //}
            //BetInfo = ObjectToJson(t);//示例[{"BetNum":"0","BetPlayTypeCode":1,"BetUnit":1,"BetTimes":1,"BetMoneyMode":"元","BetMoney":0.0,"ChoicePosition":"","IsGetBackPercent":true}]
            try
            {
                var t = new List<WS_BetInfo>();
                var accId = GetLoginId(Guid);
                var acc = AccountDAL.GetAccount(accId);
                //var acc = AccountDAL.GetAccount(2);//jix008
                var list = BetInfo; //JsonToObject(BetInfo, new List<WS_BetInfo>()) as List<WS_BetInfo>;
                #region 验证下注信息
                var returnStr = LotteryOpenInfoDAL.IsExistsExpect(LotteryId, Except, EntitiesTool.GetLotteryDic().Values.FirstOrDefault(n => n.Id == LotteryId).IsPrivate);
                if (returnStr != "")
                {
                    return returnStr;
                }
                var minDec = new decimal(0.2);
                if (list.Exists(n => n.BetMoney < minDec))
                {
                    return "每种玩法的下注金额不能少于" + minDec + "元";
                }
                if (list.Sum(n => n.BetMoney) > acc.AccountBalance)
                {
                    return "余额不足";
                }
                var wBetList = new List<BetInfo>();
                foreach (var item in list)
                {
                    var betU = Tools.Calculate(l.LotteryType, item.BetPlayTypeCode, item.BetNum, item.ChoicePosition, item.BetUnit);
                    if (betU != item.BetUnit)
                    {
                        return "下单注数验证失败";
                    }
                    if (betU <= 0)
                    {
                        return "下单注数应大于0";
                    }
                    decimal mm = 0;
                    switch (item.BetMoneyMode)
                    {
                        case "元":
                            mm = 2;
                            break;
                        case "角":
                            mm = new decimal(0.2);
                            break;
                        case "分":
                            mm = new decimal(0.02);
                            break;
                        case "厘":
                            mm = new decimal(0.002);
                            break;
                    }
                    if (betU * mm * item.BetTimes != item.BetMoney)
                    {
                        return "下单金额有误";
                    }
                    var betInfo = new BetInfo
                    {
                        AccountId = acc.Id,
                        ResultType = (int)Enum_ResultType.Wait,
                        BetNum = item.BetNum,
                        BetPlayTypeCode = item.BetPlayTypeCode,
                        BetTimes = item.BetTimes,
                        BetUnit = item.BetUnit,
                        BetMoney = item.BetMoney,
                        ChoicePosition = item.ChoicePosition,
                        IsGetBackPercent = item.IsGetBackPercent,
                        LotteryId = LotteryId,
                        LotteryExcept = Except,
                    };
                    switch (l.LotteryType)
                    {
                        case "ssc":
                            betInfo.GetBackPercent = acc.AgentPercentSSC;
                            betInfo.MaxBackMoney = (betInfo.IsGetBackPercent ? LotteryInfo_SSC.LpList()[item.BetPlayTypeCode - 1].PayBack : AgentCalculateTool.GetAgentBackMoney_SSC(LotteryInfo_SSC.LpList()[item.BetPlayTypeCode - 1].PayBack, betInfo.GetBackPercent)) * (betInfo.BetMoney / betInfo.BetUnit / 2);
                            break;
                        case "11x5":
                            betInfo.GetBackPercent = acc.AgentPercent11X5;
                            betInfo.MaxBackMoney = (betInfo.IsGetBackPercent ? LotteryOpenTool_11x5.LpList()[item.BetPlayTypeCode - 1].PayBack : AgentCalculateTool.GetAgentBackMoney_SSC(LotteryOpenTool_11x5.LpList()[item.BetPlayTypeCode - 1].PayBack, betInfo.GetBackPercent)) * (betInfo.BetMoney / betInfo.BetUnit / 2);
                            break;
                        case "dpc":
                            betInfo.GetBackPercent = acc.AgentPercentDPC;
                            betInfo.MaxBackMoney = (betInfo.IsGetBackPercent ? LotteryOpenTool_3D.LpList()[item.BetPlayTypeCode - 1].PayBack : AgentCalculateTool.GetAgentBackMoney_SSC(LotteryOpenTool_3D.LpList()[item.BetPlayTypeCode - 1].PayBack, betInfo.GetBackPercent)) * (betInfo.BetMoney / betInfo.BetUnit / 2);
                            break;
                    }
                    wBetList.Add(betInfo);
                }
                #endregion
                if (wBetList.Count == 0)
                {
                    return "无有效下注信息";
                }
                var dt = EntitiesTool.GetDateTimeNow(new LotteryAPPEntities());
                wBetList.ForEach(n => n.CreateTime = dt);
                var account = AccountDAL.BalanceChange(acc.Id, wBetList);
                return account.AccountBalance + "(元)";
            }
            catch (Exception ex)
            {
                return "错误的下注信息" + ex.Message;
            }
        }
        /// <summary>
        /// 29.追号下单投注
        /// </summary>
        /// <param name="LotteryId"></param>
        /// <returns></returns>
        [WebMethod]
        public string SendBetInfo_ZH(string Guid, int LotteryId, bool isWinCancel, List<WS_ZHInfo> ZHInfo)
        {
            if (!isLogin(Guid))
            {
                return null;
            }
            var l = EntitiesTool.GetLotteryDic().Values.FirstOrDefault(n => n.Id == LotteryId);
            if (l == null) { return "无该彩种信息"; }
            try
            {
                var t = new List<WS_BetInfo>();
                var accId = GetLoginId(Guid);
                var acc = AccountDAL.GetAccount(accId);
                var list = ZHInfo;
                #region 验证下注信息
               
                var minDec = new decimal(0.2);
                if (list.Exists(n => n.BetMoney < minDec))
                {
                    return "每种玩法的下注金额不能少于" + minDec + "元";
                }
                if (list.Sum(n => n.BetMoney) > acc.AccountBalance)
                {
                    return "余额不足";
                }
                var returnStr = LotteryOpenInfoDAL.IsExistsExpect(LotteryId, ZHInfo[0].Except, EntitiesTool.GetLotteryDic().Values.FirstOrDefault(n => n.Id == LotteryId).IsPrivate);
                if (returnStr != "")
                {
                    return returnStr;
                }
                var wBetList = new List<BetInfo>();
                var addNumNo="ZH"+DateTime.Now.Ticks+random.Next(1000,10000);
                foreach (var item in list)
                {
                    var betU = Tools.Calculate(l.LotteryType, item.BetPlayTypeCode, item.BetNum, item.ChoicePosition, item.BetUnit);
                    if (betU != item.BetUnit)
                    {
                        return "下单注数验证失败";
                    }
                    if (betU <= 0)
                    {
                        return "下单注数应大于0";
                    }
                    decimal mm = 0;
                    switch (item.BetMoneyMode)
                    {
                        case "元":
                            mm = 2;
                            break;
                        case "角":
                            mm = new decimal(0.2);
                            break;
                        case "分":
                            mm = new decimal(0.02);
                            break;
                        case "厘":
                            mm = new decimal(0.002);
                            break;
                    }
                    if (betU * mm * item.BetTimes != item.BetMoney)
                    {
                        return "下单金额有误";
                    }

                    var betInfo = new BetInfo
                    {
                        AccountId = acc.Id,
                        ResultType = (int)Enum_ResultType.Wait,
                        BetNum = item.BetNum,
                        BetPlayTypeCode = item.BetPlayTypeCode,
                        BetTimes = item.BetTimes,
                        BetUnit = item.BetUnit,
                        BetMoney = item.BetMoney,
                        ChoicePosition = item.ChoicePosition,
                        IsGetBackPercent = item.IsGetBackPercent,
                        LotteryId = LotteryId,
                        LotteryExcept = item.Except,
                        IsWinCancel = isWinCancel,//中奖后停止追号
                        //追号单号
                        AddNumNo=addNumNo,
                    };
                    switch (l.LotteryType)
                    {
                        case "ssc":
                            betInfo.GetBackPercent = acc.AgentPercentSSC;
                            betInfo.MaxBackMoney = (betInfo.IsGetBackPercent ? LotteryInfo_SSC.LpList()[item.BetPlayTypeCode - 1].PayBack : AgentCalculateTool.GetAgentBackMoney_SSC(LotteryInfo_SSC.LpList()[item.BetPlayTypeCode - 1].PayBack, betInfo.GetBackPercent)) * (betInfo.BetMoney / betInfo.BetUnit / 2);
                            break;
                        case "11x5":
                            betInfo.GetBackPercent = acc.AgentPercent11X5;
                            betInfo.MaxBackMoney = (betInfo.IsGetBackPercent ? LotteryOpenTool_11x5.LpList()[item.BetPlayTypeCode - 1].PayBack : AgentCalculateTool.GetAgentBackMoney_SSC(LotteryOpenTool_11x5.LpList()[item.BetPlayTypeCode - 1].PayBack, betInfo.GetBackPercent)) * (betInfo.BetMoney / betInfo.BetUnit / 2);
                            break;
                        case "dpc":
                            betInfo.GetBackPercent = acc.AgentPercentDPC;
                            betInfo.MaxBackMoney = (betInfo.IsGetBackPercent ? LotteryOpenTool_3D.LpList()[item.BetPlayTypeCode - 1].PayBack : AgentCalculateTool.GetAgentBackMoney_SSC(LotteryOpenTool_3D.LpList()[item.BetPlayTypeCode - 1].PayBack, betInfo.GetBackPercent)) * (betInfo.BetMoney / betInfo.BetUnit / 2);
                            break;
                    }
                    wBetList.Add(betInfo);
                }
                #endregion
                if (wBetList.Count == 0)
                {
                    return "无有效下注信息";
                }
                var dt = EntitiesTool.GetDateTimeNow(new LotteryAPPEntities());
                wBetList.ForEach(n => n.CreateTime = dt);
                var account = AccountDAL.BalanceChange(acc.Id, wBetList);
                return account.AccountBalance + "(元)";
            }
            catch (Exception ex)
            {
                return "错误的下注信息" + ex.Message;
            }
        }
        /// <summary>
        /// 30.获取预开奖期信息
        /// </summary>
        /// <param name="LotteryId"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        [WebMethod]
        public List<WS_LotteryOffcialSchedule> GetLotteryOffcialScheduleList(string Guid, int LotteryId, int Count)
        {
            var list = LotteryOpenOffcialInfoDAL.GetLotteryOffcialScheduleList(LotteryId,Count);
            return list.Select(n => new WS_LotteryOffcialSchedule 
            {
                Expect=n.Expect,
                LotteryId=n.LotteryId,
                ScheduleOpenTime=n.ScheduleOpenTime,
            }).ToList();
        }
        [WebMethod]
        public List<WS_AccountBusiness> GetAccountBusiness(string Guid, string BetId, string BusinessId, DateTime dtStart, DateTime dtEnd, int type)
        {
            var accId = GetLoginId(Guid);
            if (accId == 0)
            {
                return null;
            }
            var list = AccountDAL.GetWS_AccountBusiness(accId, BetId, BusinessId, dtStart, dtEnd, type);
            return list;
        }
        [WebMethod]
        public List<Provinces> GetProvincesList()
        {
            return EntitiesTool.GetProvincesList();
        }
        [WebMethod]
        public List<Cities> GetCitiesList()
        {
            return EntitiesTool.GetCitiesList();
        }
        [WebMethod]
        public string BindBankCard(string Guid, WS_BankCard BankCard)
        {
            try
            {
                var accId = GetLoginId(Guid);
                if (accId == 0)
                {
                    return "请先登录";
                }
                if (!AccountDAL.IsExistsOpenCardName(accId, BankCard.OpenCardName))
                {
                    return "新卡与已存在的开户名不一致";
                }
                if (AccountDAL.IsExistsOpenCardNo(accId, BankCard.CardNo)) 
                {
                    return "该卡号已存在";
                }
                var bankCard = new BankCard
                {
                    AccountId = accId,
                    BankName = BankCard.BankName,
                    CardNo = BankCard.CardNo,
                    City = BankCard.City,
                    CityId = BankCard.CityId,
                    OpenCardName = BankCard.OpenCardName,
                    Province = BankCard.Province,
                };
                AccountDAL.BindBankCard(bankCard);
                return "true";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        [WebMethod]
        public List<WS_BankCard> GetBankCard(string Guid)
        {
            var accId = GetLoginId(Guid);
            if (accId == 0)
            {
                return null;
            }
            var list = AccountDAL.GetBankCard(accId).OrderBy(n => n.CreatTime).Select(n => new WS_BankCard
            {
                BankName = n.BankName,
                CardNo = n.CardNo,
                CreatTime = n.CreatTime,
                No = n.No,
            }).ToList();
            //int i = 0;
            //list.ForEach(n => n.No = ++i);
            return list;
        }
        [WebMethod]
        public bool EditLoginPwd(string Guid, string Opwd, string Npwd)
        {
            var accId = GetLoginId(Guid);
            if (accId == 0)
            {
                return false;
            }
            return AccountDAL.EditLoginPwd(accId, Opwd, Npwd);
        }
        [WebMethod]
        public bool EditMoneyPwd(string Guid, string Opwd, string Npwd)
        {
            var accId = GetLoginId(Guid);
            if (accId == 0)
            {
                return false;
            }
            return AccountDAL.EditMoneyPwd(accId, Opwd, Npwd);
        }
        [WebMethod]
        public bool EditNickName(string Guid, string NickName)
        {
            var accId = GetLoginId(Guid);
            if (accId == 0)
            {
                return false;
            }
            return AccountDAL.EditNickName(accId, NickName);
        }
        [WebMethod]
        public bool LockBankCard(string Guid)
        {
            var accId = GetLoginId(Guid);
            if (accId == 0)
            {
                return false;
            }
            AccountDAL.LockBankCard(accId);
            return true;
        }

        /// <summary>
        /// 注册下级
        /// </summary>
        [WebMethod]
        public bool RegChildAccount(string Guid, Account Account)
        {
            var accId = GetLoginId(Guid);
            if (accId == 0)
            {
                return false;
            }
            var parentAcc = AccountDAL.GetAccount(accId);
            if (parentAcc == null)
            {
                return false;
            }
            if (Account.AgentPercent11X5 > parentAcc.AgentPercent11X5 || Account.AgentPercentDPC > parentAcc.AgentPercentDPC || Account.AgentPercentSSC > parentAcc.AgentPercentSSC)
            {
                return false;
            }
            if (AccountDAL.IsExistsLoginName(Account.AccountName))
            {
                return false;
            }
            var acc = new Accounts
            {
                AccountName = Account.AccountName,
                AccountNickname = Account.AccountNickname,
                AccountParentId = parentAcc.Id,
                AccountPwd = Account.AccountPwd,
                //CreateTime = EntitiesTool.GetDateTimeNow(),
                AccountStatus = (int)Enum_AccountStatus.Normal,
                AgentPercent11X5 = Account.AgentPercent11X5,
                AgentPercentDPC = Account.AgentPercentDPC,
                AgentPercentSSC = Account.AgentPercentSSC,
                AccountMoneyPwd = Account.AccountMoneyPwd,
            };
            try
            {
                AccountDAL.RegChildAccount(acc);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [WebMethod]//18.注册时判断登录名是否存在
        public bool IsExistsLoginName(string Guid, string loginName)
        {
            if (isLogin(Guid))
            {
                return AccountDAL.IsExistsLoginName(loginName);
            }
            return true;
        }
        [WebMethod]//19.游戏记录查询
        public List<WS_BetInfoDgv> GetBetInfoList1(string Guid, int LotteryId, DateTime StartTime, DateTime EndTime, int? ResultType, string BetInfoId, bool isIncludeChaseNumber)
        {
            var accId = GetLoginId(Guid);
            if (accId == 0)
            {
                return null;
            }
            var list = LotteryBetInfoDAL.GetBetInfoList(accId, LotteryId, StartTime, EndTime, ResultType, BetInfoId, isIncludeChaseNumber);
            return list;
        }
        [WebMethod]//20.添加充值订单
        public bool AddPayRecord(string Guid, Pay_Record pay)
        {
            var accId = GetLoginId(Guid);
            if (accId == 0)
            {
                return false;
            }
            pay.userId = accId;
            return PayDAL.AddPayRecord(pay);
        }
        [WebMethod]//21.完成充值订单
        public bool DonePayRecord(string jm, string orderNO, int pay_status, string paydatetime, int payType)
        {
            if (jm != gdjm)
            {
                return false;
            }
            //if (!isLogin(Guid))
            //{
            //    return false;
            //}
            return PayDAL.DonePayRecord(orderNO, pay_status, paydatetime, payType);
        }
        [WebMethod]//22生成提现单
        public bool Withdraw(string Guid, decimal Money, string BankCardNo, string BankName)
        {
            var accId = GetLoginId(Guid);
            if (accId == 0)
            {
                return false;
            }
            var orderNo = "TX" + DateTime.Now.Ticks;
            var withdraw = AccountDAL.Withdraw(accId, Money, orderNo, BankCardNo, BankName);
            var bankCardInfo = AccountDAL.GetBankCard(accId,BankCardNo);
            if (withdraw != null&&bankCardInfo!=null)
            {
                if (withdraw.isAutoPay)
                {
                    //调用支付接口
                    var dic = new Dictionary<string, string>();
                    dic.Add("orderNo", withdraw.OrderNo);
                    dic.Add("accountNo", withdraw.BankCardNo);
                    dic.Add("accountName", bankCardInfo.OpenCardName);
                    dic.Add("accountType", "PERSONAL");
                    dic.Add("bankNo",string.IsNullOrEmpty(bankCardInfo.BankNo)?"123456789012":bankCardInfo.BankNo);//银联行号
                    dic.Add("bankName", string.IsNullOrEmpty(bankCardInfo.BankChildName)?"中国建设银行股份有限公司贵阳云峰大道支行":bankCardInfo.BankChildName);//分行地址
                    dic.Add("amt", withdraw.Money.ToString());
                    dic.Add("orderDateTime", withdraw.CreateTime.ToString("yyyyMMddHHmmss"));
                    var res=HttpHelper.CreatePostHttpResponse("http://pay.azskin.cn:8088/home/GetSinglePay", dic,null);
                    var re = HttpHelper.GetResponseString(res);
                    return true;
                }
                else
                {
                    //等待人工审核
                }
            }
            return false;
        }
        [WebMethod]//22.接收提现回执信息
        public bool DoneWithdraw(string jm, SinglePay_Record record)
        {
            if (jm != gdjm)
            {
                return false;
            }
            return AccountDAL.DoneWithdraw(record);
        }
        [WebMethod]//23.用户列表查询
        public List<WS_Accounts_Agent> GetWS_Accounts_AgentList(string Guid, string Name, string B1, string B2, int Fanwei)
        {
            var accId = GetLoginId(Guid);
            if (accId == 0)
            {
                return null;
            }
            return AccountDAL.GetWS_Accounts_AgentList(accId,Name,B1,B2,Fanwei);
        }
        [WebMethod]//24.团队余额查询
        public decimal GetGroupMoney(string Guid) 
        {
            var accId = GetLoginId(Guid);
            if (accId == 0)
            {
                return 0;
            }
            return AccountDAL.GetGroupMoney(accId);
        }
        [WebMethod]//25.新增注册链接
        public bool AddAccountRegInfoSet(string Guid,AccountRegInfoSet info)
        {
            var accId = GetLoginId(Guid);
            if (accId == 0)
            {
                return false;
            }
            info.AccountId = accId;
            return AccountDAL.AddAccountRegInfoSet(info);
        }
        [WebMethod]//26.获取所有注册设置
        public List<AccountRegInfoSet> GetAccountRegInfoSetList(string Guid)
        {
            var accId = GetLoginId(Guid);
            if (accId == 0)
            {
                return null;
            }
            return AccountDAL.GetAccountRegInfoSetList(accId);
        }
        [WebMethod]//27.链接注册下级
        public bool RegAccountBySet(string jm, int AccountRegInfoSetId, string Name, string Pwd, string MoneyPwd, string NickName, string Email) 
        {
            if (jm != gdjm)
            {
                return false;
            }
            return AccountDAL.RegAccountBySet(AccountRegInfoSetId, Name, Pwd, MoneyPwd, NickName, Email);
        }
        [WebMethod]//27.编辑注册设置
        public bool EditAccountRegInfoSet(string Guid,AccountRegInfoSet info) 
        {
            var accId = GetLoginId(Guid);
            if (accId == 0)
            {
                return false;
            }
            info.AccountId = accId;
            return AccountDAL.EditAccountRegInfoSet(info);
        }


    }
}
