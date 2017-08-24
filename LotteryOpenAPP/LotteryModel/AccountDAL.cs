using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
namespace LotteryModel
{
    public class AccountDAL
    {
        LotteryAPPEntities e;
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        public Accounts LoginOn(string Name, string Pwd)
        {
            var dtNow = DateTime.Now;//EntitiesTool.GetDateTimeNow();
            using (e = new LotteryAPPEntities())
            {
                var account = e.Accounts.FirstOrDefault(n => n.AccountName == Name && n.AccountPwd == Pwd && n.AccountStatus == (int)Enum_AccountStatus.Normal);
                if (account != null)//登录成功记录时间与次数
                {
                    account.LastLogin = dtNow;
                    account.LoginCount++;
                    e.SaveChanges();
                }
                return account;
            }
        }
        public List<Accounts> LoginOnTest(string Name)
        {
            using (e = new LotteryAPPEntities())
            {
                var account = e.Accounts.Where(n => n.AccountName.Contains(Name)).ToList();
                return account;
            }
        }
        /// <summary>
        /// 变更余额
        /// </summary>
        /// <param name="account"></param>
        /// <param name="money"></param>
        //public Accounts BalanceChange(Accounts account, decimal money)
        //{
        //    using (e = new LotteryAPPEntities())
        //    {
        //        var a = e.Accounts.FirstOrDefault(n => n.Id == account.Id);
        //        a.AccountBalance += money;
        //        e.SaveChanges();
        //        return a;
        //    }
        //}
        /// <summary>
        /// 下注扣款
        /// </summary>
        /// <param name="account"></param>
        /// <param name="money"></param>
        public Accounts BalanceChange(int AccountId, BetInfo BetInfo)
        {

            using (e = new LotteryAPPEntities())
            {
                var dt = EntitiesTool.GetDateTimeNow(e);
                using (var tran = new TransactionScope())
                {
                    e.BetInfo.Add(BetInfo);
                    e.SaveChanges();
                    var account = e.Accounts.FirstOrDefault(n => n.Id == AccountId);

                    #region 添加业务单
                    var ab = new AccountBusiness
                               {
                                   AccountId = BetInfo.AccountId,
                                   BusinessTypeId = (int)Enum_AccountBusinessType.Bet,
                                   CreateTime = dt,
                                   EventId = BetInfo.Id,
                                   PayBefore = account.AccountBalance,
                                   PayOut = BetInfo.BetMoney,
                                   PayAfter = account.AccountBalance - BetInfo.BetMoney,
                               };
                    e.AccountBusiness.Add(ab);//投注业务单
                    account.AccountBalance = ab.PayAfter;
                    var pList = GetAllParentAccount(AccountId, e);//上级名单(含自己)
                    if (BetInfo.GetBackPercent > 0)//如果要返点
                    {
                        ab = new AccountBusiness
                                    {
                                        AccountId = BetInfo.AccountId,
                                        BusinessTypeId = (int)Enum_AccountBusinessType.BackPercent,
                                        CreateTime = dt,
                                        EventId = BetInfo.Id,
                                        PayBefore = account.AccountBalance,
                                        PayIn = (BetInfo.BetMoney * BetInfo.GetBackPercent / 100),
                                    };
                        ab.PayAfter = account.AccountBalance + ab.PayIn.Value;
                        account.AccountBalance = ab.PayAfter;
                        e.AccountBusiness.Add(ab);//返点业务单
                    }
                    #region 单个玩法投注>0.2元，上级产生返点(固定等级差返点)
                    if (BetInfo.BetMoney >= new decimal(0.2) && pList.Count > 1)
                    {
                        for (int i = 1; i < pList.Count; i++)
                        {
                            ab = new AccountBusiness
                            {
                                AccountId = pList[i].Id,
                                BusinessTypeId = (int)Enum_AccountBusinessType.BackPercent,
                                CreateTime = dt,
                                EventId = BetInfo.Id,
                                PayBefore = pList[i].AccountBalance,
                                PayIn = BetInfo.BetMoney * (pList[i].AgentPercent11X5 - pList[i - 1].AgentPercent11X5) / 100,
                            };
                            ab.PayAfter = pList[i].AccountBalance + ab.PayIn.Value;
                            pList[i].AccountBalance = ab.PayAfter;
                            e.AccountBusiness.Add(ab);//返点业务单
                        }
                    }
                    #endregion
                    #endregion
                    e.SaveChanges();
                    tran.Complete();
                    return account;
                }
            }
        }
        public Accounts BalanceChange(int AccountId, List<BetInfo> BList)
        {

            using (e = new LotteryAPPEntities())
            {
                var dt = EntitiesTool.GetDateTimeNow(e);
                var account = e.Accounts.FirstOrDefault(n => n.Id == AccountId);
                using (var tran = new TransactionScope())
                {
                    foreach (var BetInfo in BList)
                    {
                        e.BetInfo.Add(BetInfo);
                        e.SaveChanges();
                        #region 添加业务单
                        var ab = new AccountBusiness
                        {
                            AccountId = BetInfo.AccountId,
                            BusinessTypeId = (int)Enum_AccountBusinessType.Bet,
                            CreateTime = dt,
                            EventId = BetInfo.Id,
                            PayBefore = account.AccountBalance,
                            PayOut = BetInfo.BetMoney,
                            PayAfter = account.AccountBalance - BetInfo.BetMoney,
                        };
                        e.AccountBusiness.Add(ab);//投注业务单
                        account.AccountBalance = ab.PayAfter;
                        #region 返点
                        if (false)//若不是追号则给返点
                        {
                            var pList = GetAllParentAccount(AccountId, e);//上级名单(含自己)
                            if (BetInfo.IsGetBackPercent)//如果要返点
                            {
                                ab = new AccountBusiness
                                {
                                    AccountId = BetInfo.AccountId,
                                    BusinessTypeId = (int)Enum_AccountBusinessType.BackPercent,
                                    CreateTime = dt,
                                    EventId = BetInfo.Id,
                                    PayBefore = account.AccountBalance,
                                    PayIn = (BetInfo.BetMoney * BetInfo.GetBackPercent / 100),
                                };
                                ab.PayAfter = account.AccountBalance + ab.PayIn.Value;
                                account.AccountBalance = ab.PayAfter;
                                e.AccountBusiness.Add(ab);//返点业务单
                            }
                            #region 单个玩法投注>0.2元，上级产生返点(固定等级差返点)
                            if (BetInfo.BetMoney >= new decimal(0.2) && pList.Count > 1)
                            {
                                for (int i = 1; i < pList.Count; i++)
                                {
                                    var payIn = EntitiesTool.GetLotteryDic().FirstOrDefault(n => n.Value.Id == BetInfo.LotteryId).Value.LotteryType == "11x5" ? BetInfo.BetMoney * (pList[i].AgentPercent11X5 - pList[i - 1].AgentPercent11X5) / 100 : BetInfo.BetMoney * (pList[i].AgentPercentSSC - pList[i - 1].AgentPercentSSC) / 100;
                                    ab = new AccountBusiness
                                    {
                                        AccountId = pList[i].Id,
                                        BusinessTypeId = (int)Enum_AccountBusinessType.BackPercent,
                                        CreateTime = dt,
                                        EventId = BetInfo.Id,
                                        PayBefore = pList[i].AccountBalance,
                                        PayIn = payIn,
                                    };
                                    ab.PayAfter = pList[i].AccountBalance + ab.PayIn.Value;
                                    pList[i].AccountBalance = ab.PayAfter;
                                    e.AccountBusiness.Add(ab);//返点业务单
                                }
                            }
                            #endregion
                        }
                        #endregion
                        #endregion
                        e.SaveChanges();
                    }
                    tran.Complete();
                }
                return account;
            }
        }

        //public object GetBetHistory(int AccountId,int count)
        //{
        //    using (e = new LotteryAPPEntities())
        //    {
        //        var query = e.BetInfo.Where(n => n.AccountId == AccountId).OrderByDescending(n => n.Id).ToList().Select(n => new
        //        {
        //            n.BackMoney,
        //            n.BetMoney,
        //            BetNum = MyTool.GetBet_danshuang(n.BetNum, n.BetPlayTypeCode),
        //            BetPlayTypeCode = LotteryOpenTool.LpList().FirstOrDefault(w => w.BetPlayTypeCode == n.BetPlayTypeCode).LotteryPlayName,
        //            n.BetTimes,
        //            n.BetUnit,
        //            n.CreateTime,
        //            n.WinMoney,
        //            n.WinUnit,
        //            OpenNo = MyTool.AddZeroStr(n.LotteryOpenInfo.Expect, 3),
        //            OpenNum = n.ResultType > 1 ? "" : MyTool.AddZeroStr(n.LotteryOpenInfo.OpenCode),
        //            Enum_ResultType = MyTool.GetBetResultType(n.ResultType),
        //        });
        //        if(count>=0)
        //        {
        //            query = query.Take(count);
        //        }
        //        return query.ToList();
        //    }
        //}
        public object GetBetHistory(int AccountId, Lotterys lottery, DateTime DtLoad)
        {
            using (e = new LotteryAPPEntities())
            {

                var query = e.BetInfo.Where(n => n.AccountId == AccountId && n.LotteryOpenInfo.LotteryId == lottery.Id && n.CreateTime >= DtLoad).OrderByDescending(n => n.Id).ToList().Select(n => new
                {
                    n.BackMoney,
                    n.BetMoney,
                    BetNum = lottery.LotteryType == "11x5" ? MyTool.GetBet_ZH_11X5(n.BetNum, n.BetPlayTypeCode) : n.BetNum,
                    BetPlayTypeCode = MyTool.GetLotteryPlayList(lottery.LotteryType)[n.BetPlayTypeCode - 1].LotteryPlayName,
                    n.BetTimes,
                    n.BetUnit,
                    n.CreateTime,
                    n.WinMoney,
                    n.WinUnit,
                    OpenNo = MyTool.AddZeroStr(n.LotteryOpenInfo.Expect, 3),
                    //OpenNum = n.ResultType==2 ? "" : n.LotteryOpenInfo.OpenCode,
                    OpenNum = n.LotteryOpenInfo.OpenCode,
                    Enum_ResultType = EnumTool.GetBetResultType(n.ResultType),
                });
                return query.ToList();
            }
        }


        public Accounts GetAccount(int AccountId)
        {
            using (e = new LotteryAPPEntities())
            {
                return e.Accounts.FirstOrDefault(n => n.Id == AccountId);
            }
        }
        /// <summary>
        /// 递归获取所有关联上级
        /// </summary>
        /// <param name="AccountId"></param>
        /// <returns></returns>
        List<Accounts> GetAllParentAccount(int AccountId, LotteryAPPEntities e)
        {
            List<Accounts> listAccounts = null;
            listAccounts = e.Accounts.ToList();
            List<Accounts> list = new List<Accounts>();
            while (true)
            {
                var pId = listAccounts.FirstOrDefault(n => n.Id == AccountId);
                list.Add(pId);
                if (pId.AccountParentId == 0)
                {
                    break;
                }
                AccountId = pId.AccountParentId;
            }
            return list;
        }
        /// <summary>
        /// 获取返点奖金
        /// </summary>
        /// <param name="BetPlayTypeCode"></param>
        /// <param name="percent"></param>
        /// <returns></returns>
        public List<string> GetAgentBackMoneyByCode(int BetPlayTypeCode, decimal percent, string lotteryType)
        {
            List<string> list = new List<string>();
            switch (lotteryType)
            {
                case "ssc":
                    list.Add(AgentCalculateTool.GetAgentBackMoney_SSC(BetPlayTypeCode, percent) + "-0%");
                    list.Add(LotteryInfo_SSC.LpList()[BetPlayTypeCode - 1].PayBack + "-" + percent + "%");
                    break;
                case "11x5":
                    list.Add(AgentCalculateTool.GetAgentBackMoney_11x5(BetPlayTypeCode, percent) + "-0%");
                    list.Add(LotteryOpenTool_11x5.LpList()[BetPlayTypeCode - 1].PayBack + "-" + percent + "%");
                    break;
                case "dpc":
                    list.Add(AgentCalculateTool.GetAgentBackMoney_3D(BetPlayTypeCode, percent) + "-0%");
                    list.Add(LotteryOpenTool_3D.LpList()[BetPlayTypeCode - 1].PayBack + "-" + percent + "%");
                    break;
            }
            return list;
        }

        public List<AccountBusiness> GetAccountBusiness(int accountId, string betId, string busId, DateTime dtStart, DateTime dtEnd, int type)
        {
            using (e = new LotteryAPPEntities())
            {
                int id = 0;
                int eId = 0;
                var query = e.AccountBusiness.Where(n => n.AccountId == accountId && n.CreateTime >= dtStart && n.CreateTime < dtEnd);
                if (int.TryParse(betId, out eId))
                {
                    query = query.Where(n => n.EventId == eId);
                }
                if (int.TryParse(busId, out id))
                {
                    query = query.Where(n => n.Id == id);
                }
                if (type != 0)
                {
                    query = query.Where(n => n.BusinessTypeId == type);
                }
                return query.OrderByDescending(n => n.Id).ToList();
            }
        }
        public List<WS_AccountBusiness> GetWS_AccountBusiness(int accountId, string betId, string busId, DateTime dtStart, DateTime dtEnd, int type)
        {
            using (e = new LotteryAPPEntities())
            {
                long id = 0;
                long eId = 0;
                dtStart = dtStart.Date;
                dtEnd = dtEnd.Date.AddDays(1);
                var query = e.AccountBusiness.Where(n => n.AccountId == accountId && n.CreateTime >= dtStart && n.CreateTime < dtEnd);
                if (long.TryParse(betId, out eId))
                {
                    query = query.Where(n => n.EventId == eId);
                }
                if (long.TryParse(busId, out id))
                {
                    query = query.Where(n => n.Id == id);
                }
                if (type != 0)
                {
                    query = query.Where(n => n.BusinessTypeId == type);
                }
                var list = (from a in query
                            from b in e.Accounts
                            where a.AccountId == b.Id
                            orderby a.Id descending
                            select new WS_AccountBusiness
                            {
                                AccountName = b.AccountName,
                                BusinessTypeId = a.BusinessTypeId,
                                CreateTime = a.CreateTime,
                                PayAfter = a.PayAfter,
                                PayBefore = a.PayBefore,
                                EventId = a.EventId,
                                PayIn = a.PayIn,
                                PayOut = a.PayOut,
                                Id = a.Id,
                            }).ToList();
                list.ForEach(n => n.BusinessTypeStr = EnumTool.GetBusinessType(n.BusinessTypeId));
                return list;
            }
        }


        public List<AccountBusiness> GetAccountBusiness(int accountId, DateTime dtStart, DateTime dtEnd)
        {
            using (e = new LotteryAPPEntities())
            {
                var query = e.AccountBusiness.Where(n => n.CreateTime >= dtStart && n.CreateTime < dtEnd);
                var list = new List<int>();
                list.Add(accountId);
                var aList = (from a in e.Accounts
                             where query.Select(n => n.AccountId).Contains(a.Id)
                             select a).ToList();
                getChildId(accountId, aList, list);
                query = query.Where(n => list.Contains(n.AccountId));
                return query.ToList();
            }
        }
        #region 代理相关
        /// <summary>
        /// 注册下级
        /// </summary>
        public void RegChildAccount(Accounts Account)
        {
            using (e = new LotteryAPPEntities())
            {
                Account.CreateTime = EntitiesTool.GetDateTimeNow(e);
                e.Accounts.Add(Account);
                e.SaveChanges();
            }
        }
        public bool IsExistsLoginName(string loginName)
        {
            using (e = new LotteryAPPEntities())
            {
                return e.Accounts.FirstOrDefault(n => n.AccountName == loginName) != null;
            }
        }
        /// <summary>
        /// 查询下级会员
        /// </summary>
        /// <param name="AccountId"></param>
        /// <param name="Name"></param>
        /// <param name="B1"></param>
        /// <param name="B2"></param>
        /// <param name="Fd1"></param>
        /// <param name="Fd2"></param>
        /// <param name="Fanwei"></param>
        /// <returns></returns>
        public List<Accounts> GetAll(int AccountId, string Name, string B1, string B2, string Fd1, string Fd2, int Fanwei)
        {
            using (e = new LotteryAPPEntities())
            {
                var list = new List<int>();
                list.Add(AccountId);
                if (Fanwei == 0)//直属会员
                {
                    list.AddRange(e.Accounts.Where(n => n.AccountParentId == AccountId).Select(n => n.Id).ToList());
                }
                else//全部会员
                {
                    getChildId(AccountId, e.Accounts.ToList(), list);
                }
                var query = e.Accounts.Where(n => list.Contains(n.Id));
                if (!string.IsNullOrEmpty(Name))
                {
                    query = query.Where(n => n.AccountName == Name);
                }
                if (!string.IsNullOrEmpty(B1))
                {
                    var b1 = Convert.ToDecimal(B1);
                    query = query.Where(n => n.AccountBalance >= b1);
                }
                if (!string.IsNullOrEmpty(B2))
                {
                    var b2 = Convert.ToDecimal(B2);
                    query = query.Where(n => n.AccountBalance <= b2);
                }
                if (!string.IsNullOrEmpty(Fd1))
                {
                    var fd1 = Convert.ToDecimal(Fd1);
                    query = query.Where(n => n.AgentPercentSSC >= fd1);
                }
                if (!string.IsNullOrEmpty(Fd2))
                {
                    var fd2 = Convert.ToDecimal(Fd2);
                    query = query.Where(n => n.AgentPercentSSC <= fd2);
                }
                return query.ToList();
            }
        }
        public List<WS_Accounts_Agent> GetWS_Accounts_AgentList(int AccountId, string Name, string B1, string B2, int Fanwei)
        {
            using (e = new LotteryAPPEntities())
            {
                var list = new List<int>();
                var accountsList = e.Accounts.ToList();
                //list.Add(AccountId);
                if (Fanwei == 0)//直属会员
                {
                    list.AddRange(accountsList.Where(n => n.AccountParentId == AccountId).Select(n => n.Id).ToList());
                }
                else//全部会员
                {
                    getChildId(AccountId, accountsList, list);
                }
                var query = accountsList.Where(n => list.Contains(n.Id));
                if (!string.IsNullOrEmpty(Name))
                {
                    query = query.Where(n => n.AccountName == Name);
                }
                if (!string.IsNullOrEmpty(B1))
                {
                    var b1 = Convert.ToDecimal(B1);
                    query = query.Where(n => n.AccountBalance >= b1);
                }
                if (!string.IsNullOrEmpty(B2))
                {
                    var b2 = Convert.ToDecimal(B2);
                    query = query.Where(n => n.AccountBalance <= b2);
                }
                var list1 = from a in query.ToList()
                            select new WS_Accounts_Agent
                            {
                                AccountBalance = a.AccountBalance,
                                AccountName = a.AccountName,
                                AccountParentId = a.AccountParentId,
                                AccountParentName = a.AccountParentId == 0 ? "" : accountsList.FirstOrDefault(n => n.Id == a.AccountParentId).AccountName,
                                AccountStatus = a.AccountStatus == (int)Enum_AccountStatus.Normal ? "正常" : "禁用",
                                AgentPercentSSC = a.AgentPercentSSC,
                                CreateTime = a.CreateTime,
                                Id = a.Id,
                                LoginCount = a.LoginCount,
                            };
                return list1.ToList();
            }
        }
        public decimal GetGroupMoney(int AccountId)
        {
            decimal total = 0;
            using (e = new LotteryAPPEntities())
            {
                var list = new List<int>();
                list.Add(AccountId);
                var accountsList = e.Accounts.ToList();
                getChildId(AccountId, accountsList, list);
                var query = accountsList.Where(n => list.Contains(n.Id));
                total = query.Sum(n => n.AccountBalance);
            }
            return total;
        }
        /// <summary>
        /// 递归所有下级
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="aList"></param>
        /// <param name="list"></param>
        void getChildId(int pId, List<Accounts> aList, List<int> list)
        {
            foreach (var item in aList.Where(n => n.AccountParentId == pId))
            {
                list.Add(item.Id);
                getChildId(item.Id, aList, list);
            }
        }
        /// <summary>
        /// 新增注册链接Id
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool AddAccountRegInfoSet(AccountRegInfoSet info)
        {
            using (e = new LotteryAPPEntities())
            {
                info.No = e.AccountRegInfoSet.Count(n => n.AccountId == info.AccountId) + 1;
                if (info.No > 3)
                {
                    return false;
                }
                e.AccountRegInfoSet.Add(info);
                return e.SaveChanges() == 1;
            }
        }

        /// <summary>
        /// 返回所有注册信息
        /// </summary>
        /// <param name="AccountId"></param>
        /// <returns></returns>
        public List<AccountRegInfoSet> GetAccountRegInfoSetList(int AccountId)
        {
            using (e = new LotteryAPPEntities())
            {
                var query = e.AccountRegInfoSet.Where(n => n.AccountId == AccountId).ToList();
                return query;
            }
        }
        /// <summary>
        /// 链接注册下级用户
        /// </summary>
        /// <returns></returns>
        public bool RegAccountBySet(int AccountRegInfoSetId, string Name, string Pwd, string MoneyPwd, string NickName, string Email)
        {
            using (e = new LotteryAPPEntities())
            {
                if(e.Accounts.FirstOrDefault(n=>n.AccountName==Name)!=null)
                {
                    return false;
                }
                var s = e.AccountRegInfoSet.FirstOrDefault(n => n.Id == AccountRegInfoSetId);
                var account = new Accounts
                {
                    AccountMoneyPwd = MoneyPwd,
                    AccountName = Name,
                    AccountPwd = Pwd,
                    AccountNickname = NickName,
                    Email = Email,
                    //AgentPercent11X5 = s.AgentPercent11X5,
                    //AgentPercentDPC = s.AgentPercentDPC,
                    //AgentPercentSSC = s.AgentPercentSSC,
                    //AccountParentId = s.AccountId,
                    CreateTime = EntitiesTool.GetDateTimeNow(e),
                    AccountStatus = (int)Enum_AccountStatus.Normal,
                };
                if (s != null)
                {
                    var acc = e.Accounts.FirstOrDefault(n => n.Id == s.AccountId);
                    if (acc != null)
                    {
                        if (s.AgentPercent11X5 > acc.AgentPercent11X5)
                        {
                            return false;
                        }
                        if (s.AgentPercentDPC > acc.AgentPercentDPC)
                        {
                            return false;
                        }
                        if (s.AgentPercentSSC > acc.AgentPercentSSC)
                        {
                            return false;
                        }
                        account.AgentPercent11X5 = s.AgentPercent11X5;
                        account.AgentPercentDPC = s.AgentPercentDPC;
                        account.AgentPercentSSC = s.AgentPercentSSC;
                        account.AccountParentId = s.AccountId;
                    }
                }
                e.Accounts.Add(account);
                return e.SaveChanges() == 1;
            }
        }
        public bool EditAccountRegInfoSet(AccountRegInfoSet info)
        {
            using (e = new LotteryAPPEntities())
            {
                var s = e.AccountRegInfoSet.FirstOrDefault(n => n.Id == info.Id);
                if (s == null)
                {
                    return false;
                }
                var acc = e.Accounts.FirstOrDefault(n => n.Id == s.AccountId);
                if (acc == null)
                {
                    return false;
                }
                if (info.AgentPercent11X5 > acc.AgentPercent11X5)
                {
                    return false;
                }
                if (info.AgentPercentDPC > acc.AgentPercentDPC)
                {
                    return false;
                }
                if (info.AgentPercentSSC > acc.AgentPercentSSC)
                {
                    return false;
                }
                s.AgentPercent11X5 = info.AgentPercent11X5;
                s.AgentPercentDPC = info.AgentPercentDPC;
                s.AgentPercentSSC = info.AgentPercentSSC;
                return e.SaveChanges() == 1;
            }
        }
        #endregion

        #region 银行卡相关
        /// <summary>
        /// 绑定银行卡
        /// </summary>
        /// <param name="BankCard"></param>
        public void BindBankCard(BankCard BankCard)
        {

            using (e = new LotteryAPPEntities())
            {
                BankCard.CreatTime = EntitiesTool.GetDateTimeNow(e);
                BankCard.No = e.BankCard.Count(n => n.AccountId == BankCard.AccountId) + 1;
                e.BankCard.Add(BankCard);
                e.SaveChanges();
            }
        }
        /// <summary>
        /// 检查同一用户名
        /// </summary>
        /// <param name="AccountId"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public bool IsExistsOpenCardName(int AccountId, string Name)
        {
            using (e = new LotteryAPPEntities())
            {
                var c = e.BankCard.FirstOrDefault(n => n.AccountId == AccountId);
                if (c == null)
                {
                    return true;
                }
                else
                {
                    return c.OpenCardName == Name;
                }
            }
        }
        public bool IsExistsOpenCardNo(int AccountId, string CardNo)
        {
            using (e = new LotteryAPPEntities())
            {
                var c = e.BankCard.FirstOrDefault(n => n.AccountId == AccountId && n.CardNo == CardNo);
                return c != null;
            }
        }

        public List<BankCard> GetBankCard(int AccountId)
        {
            using (e = new LotteryAPPEntities())
            {
                return e.BankCard.Where(n => n.AccountId == AccountId).ToList();
            }
        }
        public BankCard GetBankCard(int AccountId, string cardNo)
        {
            using (e = new LotteryAPPEntities())
            {
                return e.BankCard.FirstOrDefault(n => n.AccountId == AccountId && n.CardNo == cardNo);
            }
        }
        /// <summary>
        /// 锁定银行卡
        /// </summary>
        /// <param name="AccountId"></param>
        public void LockBankCard(int AccountId)
        {
            using (e = new LotteryAPPEntities())
            {
                var a = e.Accounts.FirstOrDefault(n => n.Id == AccountId);
                a.BankCardLockStatus = true;
                e.SaveChanges();
            }
        }
        #endregion

        public bool EditLoginPwd(int AccountId, string Opwd, string Npwd)
        {
            using (e = new LotteryAPPEntities())
            {
                var a = e.Accounts.FirstOrDefault(n => n.Id == AccountId && n.AccountPwd == Opwd);
                if (a == null)
                {
                    return false;
                }
                a.AccountPwd = Npwd;
                e.SaveChanges();
                return true;
            }
        }
        public bool EditMoneyPwd(int AccountId, string Opwd, string Npwd)
        {
            using (e = new LotteryAPPEntities())
            {
                var a = e.Accounts.FirstOrDefault(n => n.Id == AccountId && n.AccountMoneyPwd == Opwd);
                if (a == null)
                {
                    return false;
                }
                a.AccountMoneyPwd = Npwd;
                e.SaveChanges();
                return true;
            }
        }
        public bool EditNickName(int AccountId, string NickName)
        {
            using (e = new LotteryAPPEntities())
            {
                var a = e.Accounts.FirstOrDefault(n => n.Id == AccountId);
                if (a == null)
                {
                    return false;
                }
                a.AccountNickname = NickName;
                e.SaveChanges();
                return true;
            }
        }
        #region 账户充提
        /// <summary>
        /// 账户充值
        /// </summary>
        /// <param name="AccountId"></param>
        /// <param name="Type"></param>
        /// <param name="Money"></param>
        public void Recharge(int AccountId, string Type, decimal Money, string OrderNo)
        {

            using (e = new LotteryAPPEntities())
            {
                var dt = EntitiesTool.GetDateTimeNow(e);
                var account = e.Accounts.FirstOrDefault(n => n.Id == AccountId);
                var no = e.AccountRecharge.Count(n => n.AccountId == AccountId) + 1;
                using (var tran = new TransactionScope())
                {
                    var o = new AccountRecharge
                    {
                        AccountId = AccountId,
                        CreateTime = dt,
                        Money = Money,
                        OrderNo = OrderNo,
                        Type = Type,
                        Remarks = "",
                    };
                    e.AccountRecharge.Add(o);
                    var ab = new AccountBusiness
                                           {
                                               AccountId = AccountId,
                                               BusinessTypeId = (int)Enum_AccountBusinessType.Recharge,
                                               CreateTime = dt,
                                               PayBefore = account.AccountBalance,
                                               PayIn = Money,
                                               PayAfter = account.AccountBalance + Money,

                                           };
                    e.AccountBusiness.Add(ab);//充值业务单 
                    account.AccountBalance = ab.PayAfter;
                    e.SaveChanges();
                    tran.Complete();
                }
            }
        }
        /// <summary>
        /// 账户提现
        /// </summary>
        /// <returns>-1失败，0人工，1自动</returns>
        public AccountWithdraw Withdraw(int AccountId, decimal Money, string OrderNo, string BankCardNo, string BankName)
        {
            using (e = new LotteryAPPEntities())
            {
                var dt = EntitiesTool.GetDateTimeNow(e);
                var account = e.Accounts.FirstOrDefault(n => n.Id == AccountId);
                var o = new AccountWithdraw
                {
                    AccountId = AccountId,
                    CreateTime = dt,
                    Money = Money,
                    //No = e.AccountWithdraw.Count(n => n.AccountId == AccountId) + 1,
                    OrderNo = OrderNo,
                    Remarks = "",
                    BankCardNo = BankCardNo,
                    BankName = BankName,
                    Status = 0,
                };
                if (Money > 1)
                {
                    o.isAutoPay = false;
                }
                else
                {
                    o.isAutoPay = true;
                    o.auditor = "[自助提现]";
                    o.auditTime = dt;
                }
                e.AccountWithdraw.Add(o);

                if (e.SaveChanges() != 1)
                {
                    return null;
                }
                return o;
            }
        }
        public bool DoneWithdraw(SinglePay_Record record)
        {
            using (e = new LotteryAPPEntities())
            {
                var w = e.AccountWithdraw.FirstOrDefault(n => n.OrderNo == record.orderNO);
                if (w != null && w.BankCardNo == record.accountNo && w.Money == record.amt)
                {
                    var account = e.Accounts.FirstOrDefault(n => n.Id == w.AccountId);
                    var ab = new AccountBusiness
                    {
                        AccountId = w.AccountId,
                        BusinessTypeId = (int)Enum_AccountBusinessType.Withdraw,
                        CreateTime = EntitiesTool.GetDateTimeNow(e),
                        PayBefore = account.AccountBalance,
                        PayIn = w.Money,
                        PayAfter = account.AccountBalance + w.Money,
                    };
                    e.AccountBusiness.Add(ab);//提现业务单 
                    account.AccountBalance = ab.PayAfter;
                    return e.SaveChanges() >= 2;
                }
                return false;
            }
        }
        /// <summary>
        /// 单日提现次数
        /// </summary>
        /// <param name="AccountId"></param>
        /// <returns></returns>
        public int TodayWithdrawCount(int AccountId)
        {
            using (e = new LotteryAPPEntities())
            {
                var dt = EntitiesTool.GetDateTimeNow(e).Date;
                var dt1 = dt.AddDays(1);
                return e.AccountWithdraw.Count(n => n.AccountId == AccountId && n.CreateTime >= dt && n.CreateTime < dt1);
            }
        }

        public List<AccountRecharge> GetAccountRechargeByDate(int AccountId, DateTime dtStart, DateTime dtEnd)
        {
            using (e = new LotteryAPPEntities())
            {
                dtStart = dtStart.Date;
                dtEnd = dtEnd.Date.AddDays(1);
                var query = e.AccountRecharge.Where(n => n.AccountId == AccountId && n.CreateTime >= dtStart && n.CreateTime < dtEnd).ToList();
                return query;
            }
        }

        public List<AccountWithdraw> GetAccountWithdrawByDate(int AccountId, DateTime dtStart, DateTime dtEnd)
        {
            using (e = new LotteryAPPEntities())
            {
                dtStart = dtStart.Date;
                dtEnd = dtEnd.Date.AddDays(1);
                var query = e.AccountWithdraw.Where(n => n.AccountId == AccountId && n.CreateTime >= dtStart && n.CreateTime < dtEnd).ToList();
                return query;
            }
        }
        public AccountWithdraw GetAccountWithdraw(string OrderNo)
        {
            using (e = new LotteryAPPEntities())
            {
                return e.AccountWithdraw.FirstOrDefault(n => n.OrderNo == OrderNo);
            }
        }
        #endregion
    }
}
