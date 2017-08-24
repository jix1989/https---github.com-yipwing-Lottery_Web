using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace LotteryModel
{
    public class LotteryOpenInfoDAL
    {
        LotteryAPPEntities e;
        TransactionScope tran;
        private readonly static object _MyLock = new object();
        public void Add(List<LotteryOpenInfo> Info)
        {
            using (e = new LotteryAPPEntities())
            {
                using (tran = new TransactionScope())
                {
                    try
                    {
                        var lId = Info[0].LotteryId;
                        var query = e.LotteryOpenInfo.Where(n => n.LotteryId == lId).Select(n => n.Expect).ToList();
                        var query1 = Info.Where(n => !query.Contains(n.Expect)).ToList();//如果期号不存在
                        if (query1.Count > 0)
                        {
                            e.LotteryOpenInfo.AddRange(query1);
                        }
                        var query2 = e.LotteryOpenInfo.Where(n => n.LotteryId == lId && n.OpenCode == "").ToList();//更新期号存在且号码为空的开奖信息
                        foreach (var item in query2)
                        {
                            var f = Info.FirstOrDefault(n => n.Expect == item.Expect);
                            if (f != null && !string.IsNullOrEmpty(f.OpenCode))
                            {
                                item.OpenCode = f.OpenCode;
                                item.OpenTime = f.OpenTime;
                            }
                        }
                        e.SaveChanges();
                        tran.Complete();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public void Add(LotteryOpenInfo Info)
        {
            using (e = new LotteryAPPEntities())
            {
                try
                {
                    if (e.LotteryOpenInfo.FirstOrDefault(n => n.LotteryId == Info.LotteryId && n.Expect == Info.Expect) != null)
                    {
                        return;//存在期号不增加
                    }
                    e.LotteryOpenInfo.Add(Info);
                    e.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        /// <summary>
        /// 获取准备开奖期号
        /// </summary>
        /// <returns></returns>
        public LotteryOpenInfo NextOpenNo(int LotteryId)
        {

            using (e = new LotteryAPPEntities())
            {
                var dt = EntitiesTool.GetDateTimeNow(e);
                var query = e.LotteryOpenInfo.Where(n => n.LotteryId == LotteryId && n.OpenTime > dt).FirstOrDefault();
                return query;
            }
        }
        /// <summary>
        /// 获取上一期号码
        /// </summary>
        /// <returns></returns>
        public LotteryOpenInfo LastOpenNo(int LotteryId)
        {

            using (e = new LotteryAPPEntities())
            {
                var dt = EntitiesTool.GetDateTimeNow(e);
                var query = e.LotteryOpenInfo.Where(n => n.LotteryId == LotteryId && n.OpenTime <= dt).OrderByDescending(n => n.OpenTime).FirstOrDefault();//获取已开奖的最后一期
                if (query == null)//如果没有已开奖期号
                {
                    query = e.LotteryOpenInfo.Where(n => n.LotteryId == LotteryId && n.OpenTime > dt).FirstOrDefault();//获取第一期
                }
                return query;
            }
        }
        /// <summary>
        /// 获取特定已开奖期数
        /// </summary>
        /// <returns></returns>
        public List<LotteryOpenInfo> LastOpen_Count(int count, int LotteryId)
        {
            using (e = new LotteryAPPEntities())
            {
                var query = e.LotteryOpenInfo.Where(n => n.LotteryId == LotteryId && n.OpenCode != "").OrderByDescending(n => n.OpenTime).Take(count).ToList();
                return query;
            }
        }
        /// <summary>
        /// 开奖号存在或停止投注
        /// </summary>
        /// <param name="LotteryId"></param>
        /// <param name="Expect"></param>
        /// <param name="isPrivate"></param>
        /// <returns></returns>
        public string IsExistsExpect(int LotteryId, string Expect, bool isPrivate)
        {

            using (e = new LotteryAPPEntities())
            {
                var dt = EntitiesTool.GetDateTimeNow(e);
                var f = e.LotteryOffcialSchedule.FirstOrDefault(n => n.LotteryId == LotteryId && n.Expect == Expect);
                if (f != null)
                {
                    dt = dt.AddSeconds(isPrivate ? 3 : 30);//30秒截止
                    if (dt > f.ScheduleOpenTime)
                    {
                        return "该期已截止投注";
                    }
                    else
                    {
                        return "";
                    }
                }
                return "下注期号无效";
            }
        }
        /// <summary>
        /// 开奖返奖&修改下注状态
        /// </summary>
        /// <param name="loId"></param>
        /// <returns></returns>
        public void BackWinMoney(int? LotteryId, string Except)
        {
            try
            {
                using (e = new LotteryAPPEntities())
                {
                    var dt = EntitiesTool.GetDateTimeNow(e);
                    //获取待开奖下注信息
                    var query = (from a in e.LotteryOpenInfo
                                 from b in e.BetInfo
                                 where b.ResultType == (int)Enum_ResultType.Wait && a.LotteryId == b.LotteryId && a.Expect == b.LotteryExcept
                                 select b);
                    if (LotteryId.HasValue)
                    {
                        query = query.Where(n => n.LotteryId == LotteryId.Value);
                    }
                    if (!string.IsNullOrEmpty(Except))
                    {
                        query = query.Where(n => n.LotteryExcept == Except);
                    }
                    using (tran = new TransactionScope())
                    {
                        var betList = query.ToList();
                        if (betList.Count > 0)
                        {
                            foreach (var item in betList.GroupBy(n => new { n.LotteryId, n.LotteryExcept }))
                            {
                                var lottery = EntitiesTool.GetLotteryList().FirstOrDefault(n => n.Id == item.Key.LotteryId);
                                var open = e.LotteryOpenInfo.FirstOrDefault(n => n.LotteryId == item.Key.LotteryId && n.Expect == item.Key.LotteryExcept);//获取开奖期信息
                                var openCode = open.OpenCode.Split(',').Select(n => Convert.ToInt32(n)).ToList();//获取开奖号
                                var b = betList.Where(n => n.LotteryId == item.Key.LotteryId && n.LotteryExcept == item.Key.LotteryExcept).ToList();//获取当期投注信息
                                decimal backMoney = 0;
                                switch (lottery.LotteryType)
                                {
                                    case "ssc":
                                        LotteryOpenTool_SSC.isOutBetMoney(b, openCode, false, 0, 0, 0, out backMoney);
                                        break;
                                    case "11x5":
                                        LotteryOpenTool_11x5.isOutBetMoney(b, openCode, false, 0, 0, 0, out backMoney);
                                        break;
                                }
                                foreach (var BetInfo in betList.Where(n => n.LotteryId == item.Key.LotteryId && n.LotteryExcept == item.Key.LotteryExcept))
                                {
                                    #region 返点
                                    var pList = EntitiesTool.GetAllParentAccount(BetInfo.AccountId, e);//上级名单(含自己)
                                    var account = e.Accounts.FirstOrDefault(n => n.Id == BetInfo.AccountId);
                                    if (BetInfo.IsGetBackPercent)//如果要返点
                                    {
                                        var ab = new AccountBusiness
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
                                    //单个玩法投注>0.2元，上级产生返点(固定等级差返点)
                                    if (BetInfo.BetMoney >= new decimal(0.2) && pList.Count > 1)
                                    {
                                        for (int i = 1; i < pList.Count; i++)
                                        {
                                            var ab = new AccountBusiness
                                            {
                                                AccountId = pList[i].Id,
                                                BusinessTypeId = (int)Enum_AccountBusinessType.BackPercent,
                                                CreateTime = dt,
                                                EventId = BetInfo.Id,
                                                PayBefore = pList[i].AccountBalance,
                                                PayIn = lottery.LotteryType == "11x5" ? BetInfo.BetMoney * (pList[i].AgentPercent11X5 - pList[i - 1].AgentPercent11X5) / 100 : BetInfo.BetMoney * (pList[i].AgentPercentSSC - pList[i - 1].AgentPercentSSC) / 100,
                                            };
                                            ab.PayAfter = pList[i].AccountBalance + ab.PayIn.Value;
                                            pList[i].AccountBalance = ab.PayAfter;
                                            e.AccountBusiness.Add(ab);//返点业务单
                                        }
                                    }
                                    #endregion
                                }
                            }
                            betList.ForEach(n => n.ResultType = (int)Enum_ResultType.Backing);
                            // 未中奖号码状态修改
                            var betList1 = betList.Where(n => n.ResultType == (int)Enum_ResultType.Backing && n.BackMoney <= 0).ToList();//所有未中奖
                            if (betList1.Count > 0)
                            {
                                betList1.ForEach(n => n.ResultType = (int)Enum_ResultType.False);
                                betList1.ForEach(n => n.BackTime = dt);
                            }
                            if (betList1.Count != betList.Count)
                            {
                                //中奖停止追号
                                var zList = betList.Where(n => n.ResultType == (int)Enum_ResultType.Backing && n.BackMoney > 0).Select(n=>n.AddNumNo).ToList();
                                var zBetList = e.BetInfo.Where(n => n.ResultType == (int)Enum_ResultType.Wait && n.IsWinCancel == true&&zList.Contains(n.AddNumNo)).ToList();
                                zBetList.ForEach(n => n.ResultType = (int)Enum_ResultType.WinThenCancel);
                            }
                            e.SaveChanges();
                            tran.Complete();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 更新中奖用户金额
        /// </summary>
        public int UpdateAccountMoney()
        {
            int count = 0;
            using (e = new LotteryAPPEntities())
            {
                var query = e.BetInfo.Where(n => n.ResultType == (int)Enum_ResultType.Backing && n.BackMoney > 0).ToList();
                if (query.Count > 0)
                {
                    var dt = EntitiesTool.GetDateTimeNow(e);
                    foreach (var item in query.GroupBy(n => n.AccountId))
                    {
                        var account = e.Accounts.FirstOrDefault(n => n.Id == item.Key);
                        decimal lastMoney = 0;
                        foreach (var bet in query.Where(n => n.AccountId == item.Key))
                        {
                            count++;
                            var ab = new AccountBusiness
                            {
                                AccountId = account.Id,
                                BusinessTypeId = (int)Enum_AccountBusinessType.Win,
                                CreateTime = dt,
                                EventId = bet.Id,
                                PayBefore = account.AccountBalance,
                                PayIn = bet.BackMoney,
                                PayAfter = account.AccountBalance + bet.BackMoney,
                            };
                            e.AccountBusiness.Add(ab);//添加业务单
                            bet.ResultType = (int)Enum_ResultType.True;//投注单变成已中奖
                            lastMoney = ab.PayAfter;//余额
                            bet.BackTime = dt;
                        }
                        account.AccountBalance = lastMoney;
                        e.SaveChanges();
                    }
                }
            }
            return count;
        }
        ///// <summary>
        ///// 计算返奖金额
        ///// </summary>
        ///// <param name="loId"></param>
        ///// <returns></returns>
        //public void BackWinMoney_11x5()
        //{
        //    using (e = new LotteryAPPEntities())
        //    {
        //        var dt = EntitiesTool.GetDateTimeNow(e);
        //        #region 官彩状态待开转待返奖
        //        var betList = (from a in e.LotteryOpenInfo
        //                       from b in e.BetInfo
        //                       where !a.Lotterys.IsPrivate && a.Lotterys.LotteryType == "11x5" && !string.IsNullOrEmpty(a.OpenCode) && a.LotteryId == b.LotteryId && a.Expect == b.LotteryExcept && b.ResultType == (int)Enum_ResultType.Wait
        //                       select b).ToList();//官彩11选五待返奖
        //        using (tran = new TransactionScope())
        //        {
        //            if (betList.Count > 0)
        //            {
        //                foreach (var item in betList.GroupBy(n => new { n.LotteryId, n.LotteryExcept }))
        //                {
        //                    var open = e.LotteryOpenInfo.FirstOrDefault(n => n.LotteryId == item.Key.LotteryId && n.Expect == item.Key.LotteryExcept);
        //                    var openCode = open.OpenCode.Split(',').Select(n => Convert.ToInt32(n)).ToList();
        //                    var b = betList.Where(n => n.LotteryId == item.Key.LotteryId && n.LotteryExcept == item.Key.LotteryExcept).ToList();
        //                    b.ForEach(n => n.LotteryOpenId = open.Id);
        //                    decimal backMoney = 0;
        //                    LotteryOpenTool_11x5.isOutBetMoney(b, openCode, false, 0, 0, 0, out backMoney);
        //                }
        //                betList.ForEach(n => n.ResultType = (int)Enum_ResultType.Backing);
        //                e.SaveChanges();
        //                #region 未中奖号码状态修改
        //                var betList1 = e.BetInfo.Where(n => n.ResultType == (int)Enum_ResultType.Backing && n.BackMoney <= 0).ToList();//所有未中奖
        //                if (betList1.Count > 0)
        //                {
        //                    betList1.ForEach(n => n.ResultType = (int)Enum_ResultType.False);
        //                    betList1.ForEach(n => n.BackTime = dt);
        //                    e.SaveChanges();
        //                }
        //                #endregion
        //            }
        //        #endregion
        //            tran.Complete();
        //        }

        //    }
        //    //return list;
        //}

        //public void PrivateBackWinMoney(Lotterys lottery, string Expect)
        //{

        //    using (e = new LotteryAPPEntities())
        //    {
        //        var dt = EntitiesTool.GetDateTimeNow(e);
        //        #region 私彩状态待开转待返奖
        //        var betList = (from b in e.BetInfo
        //                       where lottery.Id == b.LotteryId && Expect == b.LotteryExcept && b.ResultType == (int)Enum_ResultType.Wait
        //                       select b).ToList();//官彩11选五待返奖
        //        if (betList.Count > 0)
        //        {
        //            var open = e.LotteryOpenInfo.FirstOrDefault(n => n.LotteryId == lottery.Id && n.Expect == Expect);
        //            using (tran = new TransactionScope())
        //            {
        //                var openCode = open.OpenCode.Split(',').Select(n => Convert.ToInt32(n)).ToList();
        //                betList.ForEach(n => n.LotteryOpenId = open.Id);
        //                decimal backMoney = 0;
        //                if (lottery.LotteryType == "11x5")
        //                {
        //                    LotteryOpenTool_11x5.isOutBetMoney(betList, openCode, false, 0, 0, 0, out backMoney);
        //                }
        //                else if (lottery.LotteryType == "ssc")
        //                {
        //                    LotteryOpenTool_SSC.isOutBetMoney(betList, openCode, false, 0, 0, 0, out backMoney);
        //                }
        //                betList.ForEach(n => n.ResultType = (int)Enum_ResultType.Backing);
        //                e.SaveChanges();
        //                #region 未中奖号码状态修改
        //                var betList1 = e.BetInfo.Where(n => n.ResultType == (int)Enum_ResultType.Backing && n.BackMoney <= 0).ToList();//所有未中奖
        //                if (betList1.Count > 0)
        //                {
        //                    betList1.ForEach(n => n.ResultType = (int)Enum_ResultType.False);
        //                    betList1.ForEach(n => n.BackTime = dt);
        //                    e.SaveChanges();
        //                }
        //                #endregion
        //                foreach (var BetInfo in betList.Where(n=>!string.IsNullOrEmpty(n.AddNumNo)))
        //                {
        //                    #region 返点
        //                    var pList =EntitiesTool.GetAllParentAccount(BetInfo.AccountId, e);//上级名单(含自己)
        //                    var account = e.Accounts.FirstOrDefault(n => n.Id == BetInfo.AccountId);
        //                    if (BetInfo.IsGetBackPercent)//如果要返点
        //                    {
        //                       var ab = new AccountBusiness
        //                        {
        //                            AccountId = BetInfo.AccountId,
        //                            BusinessTypeId = (int)Enum_AccountBusinessType.BackPercent,
        //                            CreateTime = dt,
        //                            EventId = BetInfo.Id,
        //                            PayBefore = account.AccountBalance,
        //                            PayIn = (BetInfo.BetMoney * BetInfo.GetBackPercent / 100),
        //                        };
        //                        ab.PayAfter = account.AccountBalance + ab.PayIn.Value;
        //                        account.AccountBalance = ab.PayAfter;
        //                        e.AccountBusiness.Add(ab);//返点业务单
        //                    }
        //                    //单个玩法投注>0.2元，上级产生返点(固定等级差返点)
        //                    if (BetInfo.BetMoney >= new decimal(0.2) && pList.Count > 1)
        //                    {
        //                        for (int i = 1; i < pList.Count; i++)
        //                        {
        //                           var ab = new AccountBusiness
        //                            {
        //                                AccountId = pList[i].Id,
        //                                BusinessTypeId = (int)Enum_AccountBusinessType.BackPercent,
        //                                CreateTime = dt,
        //                                EventId = BetInfo.Id,
        //                                PayBefore = pList[i].AccountBalance,
        //                                PayIn = lottery.LotteryType == "11x5" ? BetInfo.BetMoney * (pList[i].AgentPercent11X5 - pList[i - 1].AgentPercent11X5) / 100 : BetInfo.BetMoney * (pList[i].AgentPercentSSC - pList[i - 1].AgentPercentSSC) / 100,
        //                            };
        //                            ab.PayAfter = pList[i].AccountBalance + ab.PayIn.Value;
        //                            pList[i].AccountBalance = ab.PayAfter;
        //                            e.AccountBusiness.Add(ab);//返点业务单
        //                        }
        //                    }
        //                    #endregion
        //                }
        //                tran.Complete();
        //            }
        //        #endregion
        //        }

        //    }
        //    //return list;
        //}
        //public void PrivateBackWinMoney()
        //{
        //    using (e = new LotteryAPPEntities())
        //    {
        //        var dt = EntitiesTool.GetDateTimeNow(e);
        //        #region 私彩状态待开转待返奖
        //        var betList = (from b in e.BetInfo
        //                       from a in e.LotteryOpenInfo
        //                       where b.ResultType == (int)Enum_ResultType.Wait&&a.LotteryId==b.LotteryId&&a.Expect==b.LotteryExcept
        //                       select b).ToList();//官彩11选五待返奖
        //        if (betList.Count > 0)
        //        {
        //            foreach (var item in betList.GroupBy(n => new {n.LotteryId,n.LotteryExcept }))
        //            {
        //                var lottery = EntitiesTool.GetLotteryDic().FirstOrDefault(n => n.Value.Id == item.Key.LotteryId).Value;
        //                var open = e.LotteryOpenInfo.FirstOrDefault(n => n.LotteryId == lottery.Id && n.Expect == item.Key.LotteryExcept);
        //                using (tran = new TransactionScope())
        //                {
        //                    var openCode = open.OpenCode.Split(',').Select(n => Convert.ToInt32(n)).ToList();
        //                    betList.ForEach(n => n.LotteryOpenId = open.Id);
        //                    decimal backMoney = 0;
        //                    if (lottery.LotteryType == "11x5")
        //                    {
        //                        LotteryOpenTool_11x5.isOutBetMoney(betList, openCode, false, 0, 0, 0, out backMoney);
        //                    }
        //                    else if (lottery.LotteryType == "ssc")
        //                    {
        //                        LotteryOpenTool_SSC.isOutBetMoney(betList, openCode, false, 0, 0, 0, out backMoney);
        //                    }
        //                    betList.ForEach(n => n.ResultType = (int)Enum_ResultType.Backing);
        //                    e.SaveChanges();
        //                    #region 未中奖号码状态修改
        //                    var betList1 = e.BetInfo.Where(n => n.ResultType == (int)Enum_ResultType.Backing && n.BackMoney <= 0).ToList();//所有未中奖
        //                    if (betList1.Count > 0)
        //                    {
        //                        betList1.ForEach(n => n.ResultType = (int)Enum_ResultType.False);
        //                        betList1.ForEach(n => n.BackTime = dt);
        //                        e.SaveChanges();
        //                    }
        //                    #endregion
        //                    tran.Complete();
        //                }
        //            }
        //        #endregion
        //        }

        //    }
        //    //return list;
        //}

        //public int BackWinMoney_11x5_pro()
        //{
        //    using (e = new LotteryAPPEntities())
        //    {
        //        var i = e.ChangeAccountMoney(1);
        //        i = i / 3;
        //        return i;
        //    }
        //}
        //public void BackWinMoney_SSC()
        //{
        //    //List<BackDgvInfo> list = new List<BackDgvInfo>();

        //    using (e = new LotteryAPPEntities())
        //    {
        //        var dt = EntitiesTool.GetDateTimeNow(e);
        //        #region 官彩状态待开转待返奖
        //        var betList = (from a in e.LotteryOpenInfo
        //                       from b in e.BetInfo
        //                       where !a.Lotterys.IsPrivate && a.Lotterys.LotteryType == "ssc" && !string.IsNullOrEmpty(a.OpenCode)
        //                       && a.LotteryId == b.LotteryId && a.Expect == b.LotteryExcept && b.ResultType == (int)Enum_ResultType.Wait
        //                       select b).ToList();//官彩时时彩待返奖
        //        using (tran = new TransactionScope())
        //        {
        //            if (betList.Count > 0)
        //            {
        //                foreach (var item in betList.GroupBy(n => new { n.LotteryId, n.LotteryExcept }))
        //                {
        //                    var open = e.LotteryOpenInfo.FirstOrDefault(n => n.LotteryId == item.Key.LotteryId && n.Expect == item.Key.LotteryExcept);
        //                    var openCode = open.OpenCode.Split(',').Select(n => Convert.ToInt32(n)).ToList();
        //                    var b = betList.Where(n => n.LotteryId == item.Key.LotteryId && n.LotteryExcept == item.Key.LotteryExcept).ToList();
        //                    b.ForEach(n => n.LotteryOpenId = open.Id);
        //                    decimal backMoney = 0;
        //                    LotteryOpenTool_SSC.isOutBetMoney(b, openCode, false, 0, 0, 0, out backMoney);
        //                    b.ForEach(n => n.ResultType = (int)Enum_ResultType.Backing);
        //                }
        //                e.SaveChanges();
        //        #endregion
        //                #region 未中奖号码状态修改
        //                var betList1 = e.BetInfo.Where(n => n.ResultType == (int)Enum_ResultType.Backing && n.BackMoney <= 0).ToList();//所有未中奖
        //                if (betList1.Count > 0)
        //                {
        //                    betList1.ForEach(n => n.ResultType = (int)Enum_ResultType.False);
        //                    betList1.ForEach(n => n.BackTime = dt);
        //                    e.SaveChanges();
        //                }
        //                #endregion
        //            }
        //            tran.Complete();
        //        }
        //    }
        //    //return list;
        //}

        //public List<BackDgvInfo> BackWinMoney()
        //{
        //    List<BackDgvInfo> list = new List<BackDgvInfo>();
        //    list.Add(new BackDgvInfo
        //    {
        //        Expect = "0",
        //        LotteryName = "0",
        //        TotalWin = 0,
        //    });
        //    int onceCount = 100;//单次处理条数
        //    using (e = new LotteryAPPEntities())
        //    {

        //        #region 官彩状态待开转待返奖
        //        var betList = (from a in e.LotteryOpenInfo
        //                       from b in e.BetInfo
        //                       where !a.Lotterys.IsPrivate && !string.IsNullOrEmpty(a.OpenCode) && a.Id == b.LotteryOpenId && b.ResultType == (int)Enum_ResultType.Wait
        //                       select b).Take(onceCount).ToList();//官彩待返奖
        //        // Where(n => n.ResultType == (int)Enum_ResultType.Wait && !n.LotteryOpenInfo.Lotterys.IsPrivate);
        //        if (betList.Count > 0)
        //        {
        //            foreach (var item in betList.GroupBy(n => n.LotteryOpenId))
        //            {
        //                var openCode = e.LotteryOpenInfo.FirstOrDefault(n => n.Id == item.Key).OpenCode;
        //                var openNum = openCode.Split(',').Select(n => Convert.ToInt32(n)).ToList();
        //                var f3 = openNum.Take(3).ToList();//前三号字符串
        //                var f2 = openNum.Take(2).ToList();//前二号字符串
        //                var dan = openNum.Where(n => n % 2 != 0).Count();//单号个数
        //                var zhongwei = openNum.OrderBy(n => n).ToList()[2];//中位值 
        //                decimal backMoney = 0;
        //                LotteryOpenTool_11x5.isOutBetMoney(betList, openNum, false, 0, 0, 0, out backMoney);
        //            }
        //            using (tran = new TransactionScope())//一期彩票一个事务
        //            {
        //                betList.ForEach(n => n.ResultType = (int)Enum_ResultType.Backing);
        //                e.SaveChanges();
        //                tran.Complete();
        //            }
        //        }
        //        #endregion
        //        e.ChangeAccountMoney(onceCount);
        //        return list;
        //        #region 未中奖号码状态修改
        //        e.BetInfo.Where(n => n.ResultType == (int)Enum_ResultType.Backing && n.BackMoney <= 0).Take(onceCount * 10).ToList();//所有未中奖
        //        betList.ForEach(n => n.ResultType = (int)Enum_ResultType.False);
        //        betList.ForEach(n => n.BackTime = EntitiesTool.GetDateTimeNow());
        //        e.SaveChanges();
        //        #endregion
        //        #region 将待返奖状态进行判断中奖情况并上账
        //        //int count = 0;
        //        betList = e.BetInfo.Where(n => n.ResultType == (int)Enum_ResultType.Backing).Take(onceCount).ToList();//所有待返奖

        //        //count = betList.Count;
        //        if (betList.Count > 0)
        //        {
        //            //betList.ForEach(n => n.BackTime = dt);//判断中奖，返回待返奖集合
        //            //betList.ForEach(n => n.ResultType = n.BackMoney > 0 ? (int)Enum_ResultType.True : (int)Enum_ResultType.False);
        //            foreach (var bet in betList)
        //            {
        //                #region 添加回执信息集合
        //                var o = e.LotteryOpenInfo.FirstOrDefault(n => n.Id == bet.LotteryOpenId);
        //                var f = list.FirstOrDefault(n => n.LotteryName == o.Lotterys.LotteryName && n.Expect == o.Expect);
        //                if (f == null)
        //                {
        //                    var info = new BackDgvInfo
        //                    {
        //                        LotteryName = o.Lotterys.LotteryName,
        //                        Expect = o.Expect,
        //                    };
        //                    list.Add(info);
        //                    f = info;
        //                }
        //                f.TotalBet++;
        //                #endregion
        //                if (bet.BackMoney > 0)//中奖则返奖
        //                {
        //                    f.TotalWin++;
        //                    ////lock (_MyLock)
        //                    ////{
        //                    ////    using (tran = new TransactionScope())
        //                    ////    {
        //                    //var dt = EntitiesTool.GetDateTimeNow();
        //                    //var account = e.Accounts.FirstOrDefault(n => n.Id == bet.AccountId);
        //                    //var ab = new AccountBusiness
        //                    //            {
        //                    //                AccountId = account.Id,
        //                    //                BusinessTypeId = (int)Enum_AccountBusinessType.Win,
        //                    //                CreateTime = dt,
        //                    //                EventId = bet.Id,
        //                    //                PayBefore = account.AccountBalance,
        //                    //                PayIn = bet.BackMoney,
        //                    //                PayAfter = account.AccountBalance + bet.BackMoney,
        //                    //            };
        //                    //e.AccountBusiness.Add(ab);//添加业务单
        //                    //account.AccountBalance = ab.PayAfter;
        //                    //bet.ResultType = (int)Enum_ResultType.True;
        //                    //bet.BackTime = dt;
        //                    //e.SaveChanges();
        //                    //        tran.Complete();
        //                    //    } 
        //                    //}
        //                }
        //                else
        //                {
        //                    //bet.ResultType = (int)Enum_ResultType.False;
        //                    //bet.BackTime = EntitiesTool.GetDateTimeNow();
        //                    //e.SaveChanges();
        //                }
        //                //        //var aList = betList.Where(w => w.ResultType == (int)Enum_ResultType.True).Select(w => w.AccountId).ToList();
        //                //        //foreach (var item in betList.GroupBy(n => n.LotteryOpenId))
        //                //        //{
        //                //        //    foreach (var account in e.Accounts.Where(n => aList.Contains(n.Id)))//对中奖账户进行上账
        //                //        //    {
        //                //        //        using (tran = new TransactionScope())//一个账户一个事务上账(暂定)
        //                //        //        {
        //                //        //            foreach (var item1 in betList.Where(w => w.ResultType == (int)Enum_ResultType.True && w.AccountId == account.Id && w.LotteryOpenId == item.Key))//获取该中奖用户投注单(每单生成一个相应业务单)
        //                //        //            {
        //                //        //                var ab = new AccountBusiness
        //                //        //                {
        //                //        //                    AccountId = item1.AccountId,
        //                //        //                    BusinessTypeId = (int)Enum_AccountBusinessType.Win,
        //                //        //                    CreateTime = dt,
        //                //        //                    EventId = item1.Id,
        //                //        //                    PayBefore = account.AccountBalance,
        //                //        //                    PayIn = item1.BackMoney,
        //                //        //                    PayAfter = account.AccountBalance + item1.BackMoney,
        //                //        //                };
        //                //        //                e.AccountBusiness.Add(ab);//添加业务单
        //                //        //                account.AccountBalance = ab.PayAfter;
        //                //        //            }
        //                //        //            e.SaveChanges();
        //                //        //            tran.Complete();
        //                //        //        }
        //                //        //    }

        //            }
        //        }
        //        #endregion

        //    }

        //}

        //public long GetLotteryOpenInfoId(long LotteryOpenId) 
        //{
        //    using (e = new LotteryAPPEntities())
        //    {
        //        var query = (from a in e.LotteryOpen
        //                     from b in e.LotteryOpenInfo
        //                     where a.Id == LotteryOpenId && a.LotteryId == b.LotteryId && a.Expect == b.Expect
        //                     select b.Id).FirstOrDefault();
        //        return query != null ? query : 0;
        //    }
        //}

    }
    public class BackDgvInfo
    {
        public List<long> OpenInfoList = new List<long>();
        public string LotteryName { get; set; }
        public string Expect { get; set; }
        public int TotalBet { get; set; }
        public int TotalWin { get; set; }
    }
}
