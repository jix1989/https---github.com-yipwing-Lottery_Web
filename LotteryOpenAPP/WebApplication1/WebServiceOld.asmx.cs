using LotteryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
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
    public class WebServiceOld : System.Web.Services.WebService
    {
        AccountDAL AccountDAL = new AccountDAL();
        LotteryOpenInfoDAL LotteryOpenInfoDAL = new LotteryOpenInfoDAL();
        LotteryOpenOffcialInfoDAL LotteryOpenOffcialInfoDAL = new LotteryOpenOffcialInfoDAL();
        LotteryBetInfoDAL LotteryBetInfoDAL = new LotteryBetInfoDAL();
        [WebMethod(EnableSession = true)]
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
        [WebMethod(EnableSession = true)]
        public string Json_LoginOn(string Name, string Pwd)
        {
            var acc = AccountDAL.LoginOn(Name, Pwd);
            if (acc != null)
            {
                Context.Session["AccountId"] = acc.Id;
                return "true";
            }
            return "";
        }
        /// <summary>
        /// 根据session获取个人信息Id
        /// </summary>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string Json_GetAccountInfo()
        {
            var json = "";
            if (Context.Session["AccountId"] != null)
            {
                var acc = AccountDAL.GetAccount(Convert.ToInt32(Context.Session["AccountId"]));
                json = acc == null ? "" : ObjectToJson(new Account
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
            return json;
        }
        List<object> LotteryList = new List<object>();
        /// <summary>
        /// 获取彩种信息
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string Json_GetLotteryList()
        {
            if (LotteryList.Count == 0)
            {
                foreach (var item in EntitiesTool.GetLotteryDic())
                {
                    LotteryList.Add(new { item.Value.Id, item.Value.LotteryName });
                };
            }
            return ObjectToJson(LotteryList);
        }
        /// <summary>
        /// 获取下一期开奖信息
        /// </summary>
        /// <param name="LotteryId">彩种id字符串用,隔开</param>
        /// <returns></returns>
        [WebMethod]
        public string Json_GetLotteryNextInfo(string LotteryId)
        {
            var arr = LotteryId.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            if (arr.Length == 0)
            {
                return "";
            }
            var dt = EntitiesTool.GetDateTimeNow();
            var list = LotteryOpenOffcialInfoDAL.NextOpenNo(arr).Select(n => new { n.LotteryId, RemainderSeconds = (n.ScheduleOpenTime - dt).TotalSeconds, n.Expect }).ToList();
            return ObjectToJson(list);
        }
        /// <summary>
        /// 获取开奖号集合
        /// </summary>
        /// <param name="Count">获取行数</param>
        /// <param name="LotteryId">彩种Id</param>
        /// <returns></returns>
        [WebMethod]
        public string Json_GetLotteryHistroyInfo(int Count, int LotteryId)
        {
            var list = LotteryOpenInfoDAL.LastOpen_Count(Count, LotteryId).Select(n => new { n.LotteryId, n.Expect, n.OpenCode, }).ToList();
            return ObjectToJson(list);
        }
        /// <summary>
        /// 获取彩种玩法集合
        /// </summary>
        /// <param name="LotteryId"></param>
        /// <returns></returns>
        [WebMethod]
        public string Json_GetLotteryPlayInfo(int LotteryId)
        {
            var l = EntitiesTool.GetLotteryDic().Values.FirstOrDefault(n => n.Id == LotteryId);
            if (l == null) { return "无该彩种信息"; }
            var list = new List<LotteryPlay>();
            switch (l.LotteryType)
            {
                case "ssc":
                    list = LotteryInfo_SSC.LpList();
                    break;
                case "11x5":
                    list = LotteryOpenTool_11x5.LpList();
                    break;
                case "dpc":
                    list = LotteryOpenTool_3D.LpList();
                    break;
            }
            return ObjectToJson(list);
        }
        /// <summary>
        /// 下单投注
        /// </summary>
        /// <param name="LotteryId"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string Json_SendBetInfo(int LotteryId, string Except, string BetInfo)
        {
            if (Context.Session["AccountId"] == null)
            {
                return "请先登录";
            }
            var l = EntitiesTool.GetLotteryDic().Values.FirstOrDefault(n => n.Id == LotteryId);
            if (l == null) { return "无该彩种信息"; }
            var t = new List<WS_BetInfo>();
            if (l.LotteryType=="ssc")
            {
                t.Add(new WS_BetInfo
                    {
                        BetMoney = 2,
                        BetMoneyMode = "元",
                        BetNum = "0|0|0|0|0",
                        BetPlayTypeCode = 2,
                        BetTimes = 1,
                        BetUnit = 1,
                        ChoicePosition = "",
                        IsGetBackPercent = true,
                    });
                t.Add(new WS_BetInfo
                {
                    BetMoney = 6,
                    BetMoneyMode = "角",
                    BetNum = "0 1 2|0 1 2",
                    BetPlayTypeCode = 116,
                    BetTimes = 1,
                    BetUnit = 30,
                    ChoicePosition = "0,1,2,3,4",
                    IsGetBackPercent = true,
                }); 
            }
            if(l.LotteryType=="11x5")
            {
                t.Add(new WS_BetInfo
                {
                    BetMoney = 2,
                    BetMoneyMode = "元",
                    BetNum = "04|05|06",
                    BetPlayTypeCode = 1,
                    BetTimes = 1,
                    BetUnit = 1,
                    ChoicePosition = "",
                    IsGetBackPercent = false,
                }); 
            }
            //BetInfo = ObjectToJson(t);//示例[{"BetNum":"0","BetPlayTypeCode":1,"BetUnit":1,"BetTimes":1,"BetMoneyMode":"元","BetMoney":0.0,"ChoicePosition":"","IsGetBackPercent":true}]
            try
            {
                var acc = AccountDAL.GetAccount(Convert.ToInt32(Context.Session["AccountId"]));
                //var acc = AccountDAL.GetAccount(2);//jix008
                var list = JsonToObject(BetInfo, new List<WS_BetInfo>()) as List<WS_BetInfo>;
                #region 验证下注信息
                var returnStr=LotteryOpenInfoDAL.IsExistsExpect(LotteryId,Except);
                if (returnStr!="")
                {
                    return returnStr;
                }
                if (list.Exists(n => n.BetMoney < new decimal(0.2)))
                {
                    return "每种玩法的下注金额不能少于0.2元";
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
                        CreateTime = EntitiesTool.GetDateTimeNow(),
                        BetNum = item.BetNum,
                        BetPlayTypeCode = item.BetPlayTypeCode,
                        BetTimes = item.BetTimes,
                        BetUnit = item.BetUnit,
                        BetMoney = item.BetMoney,
                        ChoicePosition = item.ChoicePosition,
                        IsGetBackPercent = item.IsGetBackPercent,
                        LotteryId=LotteryId,
                        LotteryExcept=Except,
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
                if(wBetList.Count==0)
                {
                    return "无有效下注信息";
                }
                var account = AccountDAL.BalanceChange(acc.Id, wBetList);
                return account.AccountBalance + "元";
            }
            catch (Exception ex)
            {
                return "错误的下注信息";
            }
        }
        //[WebMethod]
        //public Account LoginOn(string Name, string Pwd)
        //{
        //    var acc = AccountDAL.LoginOn(Name, Pwd);
        //    return acc == null ? null : new Account
        //    {
        //        AccountBalance = acc.AccountBalance,
        //        AccountName = acc.AccountName,
        //        AccountStatus = acc.AccountStatus,
        //        AccountNickname = acc.AccountNickname,
        //        AccountParentId = acc.AccountParentId,
        //        AccountPwd = acc.AccountPwd,
        //        AgentPercent11X5 = acc.AgentPercent11X5,
        //        AgentPercentDPC = acc.AgentPercentDPC,
        //        AgentPercentSSC = acc.AgentPercentSSC,
        //        BankCardLockStatus = acc.BankCardLockStatus,
        //        CreateTime = acc.CreateTime,
        //        Id = acc.Id,
        //        LastLogin = acc.LastLogin,
        //        LoginCount = acc.LoginCount,
        //    };
        //}
        // 从一个对象信息生成Json串
        public static string ObjectToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        // 从一个Json串生成对象信息
        public static object JsonToObject(string jsonString, object obj)
        {
            return JsonConvert.DeserializeObject(jsonString, obj.GetType());
        }
    }
}
