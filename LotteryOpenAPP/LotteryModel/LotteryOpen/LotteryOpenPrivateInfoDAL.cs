using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;

namespace LotteryModel
{
    public class LotteryOpenPrivateInfoDAL
    {
        LotteryAPPEntities e;
        TransactionScope tran;
        static Random random = new Random();
        //Dictionary<string, int> LotteryDic = new Dictionary<string, int>();
        static List<string> AllCodeList = new List<string>();
        static string[] NumList11x5_Normal = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11" };
        static int[] NumList11x5_NormalInt = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
        /// <summary>
        /// 获取所有摇号组合
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public LotteryOpenPrivateInfoDAL()
        {
            GetAllCodeList();
        }
        public List<string> GetAllCodeList()
        {
            #region 初始化所有组合
            if (File.Exists("11x5code") && AllCodeList.Count == 0)
            {
                var sb = File.ReadAllLines("11x5code", Encoding.Default);
                foreach (var item in sb)
                {
                    AllCodeList.Add(item);
                }
            }
            if (AllCodeList.Count != 55440)
            {
                StringBuilder sb = new StringBuilder();
                var nList = GetOpenNum_IntList(null);
                var code = string.Format("{0},{1},{2},{3},{4}", NumList11x5_Normal[nList[0] - 1], NumList11x5_Normal[nList[1] - 1], NumList11x5_Normal[nList[2] - 1], NumList11x5_Normal[nList[3] - 1], NumList11x5_Normal[nList[4] - 1]);
                while (AllCodeList.Count != 55440) //最多有A(5,11):55440种组合
                {
                    if (!AllCodeList.Contains(code))
                    {
                        AllCodeList.Add(code);
                        sb.AppendLine(code);
                    }
                    else
                    {
                        nList = GetOpenNum_IntList(null);
                        code = string.Format("{0},{1},{2},{3},{4}", NumList11x5_Normal[nList[0] - 1], NumList11x5_Normal[nList[1] - 1], NumList11x5_Normal[nList[2] - 1], NumList11x5_Normal[nList[3] - 1], NumList11x5_Normal[nList[4] - 1]);
                    }
                }
                File.WriteAllText("11x5code", sb.ToString(), Encoding.Default);
            }
            #endregion
            return AllCodeList;
        }
        /// <summary>
        /// 初始化开奖信息(一期)
        /// </summary>
        public void InitialTodayInfo(Lotterys Lottery, DateTime dt)
        {
            using (e = new LotteryAPPEntities())
            {
                var dtS = dt.Date.AddHours((double)Lottery.TimeStart.Value);
                var dtE = dtS;//dtS.AddHours(Lottery..Value);
                var query = e.LotteryOpen.Count(n => n.LotteryId == Lottery.Id && (n.ScheduleOpenTime > dtS && n.ScheduleOpenTime <= dtE));
                if (query == 0)
                {
                    //int AddZero = Lottery.BetweenMinute == 1 ? 4 : 3;
                    using (tran = new TransactionScope())
                    {
                        for (int i = 1; true; i++)
                        {
                            var ot = dtS.AddMinutes(i * (int)Lottery.BetweenMinute.Value);
                            if (ot > dtE)//超期退出循环
                            {
                                break;
                            }
                            var code = GetAllCodeList()[random.Next(0, GetAllCodeList().Count)];
                            var open = new LotteryOpen
                            {
                                LotteryId = Lottery.Id,
                                OpenStatus = (int)Enum_LotteryOpenStatus.Schedule,
                                ScheduleOpenCode = code,//预先开出随机号
                                ScheduleOpenTime = ot,//间隔多少时间一期
                                Expect = ot.Date.ToString("yyyyMMdd") + MyTool.AddZeroStr(i,Lottery.ExceptLength.HasValue? Lottery.ExceptLength.Value:0),
                                ExpectDate = ot.Date.ToString("yyyyMMdd"),
                                RerollCount = 0,
                            };
                            e.LotteryOpen.Add(open);
                            var info = new LotteryOpenInfo
                            {
                                Expect = open.Expect,
                                LotteryId = open.LotteryId,
                                OpenCode = "",
                                OpenDate = open.ScheduleOpenTime.Date,
                                OpenTime = open.ScheduleOpenTime,
                            };
                            e.LotteryOpenInfo.Add(info);
                        }
                        e.SaveChanges();
                        tran.Complete();
                    }
                }
            }
        }

        /// <summary>
        /// 进行开奖
        /// </summary>
        /// <param name="loId"></param>
        /// <param name="isFixed">固定开奖</param>
        /// <param name="NoStrs"></param>
        public void OpeningNo(long loId, bool isXZ, bool isYK, bool isFixed, params string[] NoStrs)
        {
            using (e = new LotteryAPPEntities())
            {
                var open = e.LotteryOpen.Where(n => n.Id == loId).FirstOrDefault();
                if (open.OpenStatus == (int)Enum_LotteryOpenStatus.Schedule)
                {
                    open.OpenStatus = (int)Enum_LotteryOpenStatus.Opening;//设置此期为开奖中
                    open.OpenCode = open.ScheduleOpenCode;
                    //e.SaveChanges();
                }
                //由最大返奖比金额开始判断
                var bList = (from b in e.BetInfo
                             where b.LotteryOpenInfo.LotteryId == open.LotteryId && b.LotteryOpenInfo.Expect == open.Expect
                             orderby b.MaxBackMoney descending
                             select b).ToList();
                //总投注金额
                var betTotalMoney = bList.Sum(n => n.BetMoney);
                //奖金池金额
                var pool = e.LotteryPrizePool.FirstOrDefault(n => n.LotteryId == open.LotteryId);
                //总返点金额
                var query = (from a in e.AccountBusiness
                             from b in e.BetInfo
                             where b.LotteryOpenInfo.LotteryId == open.LotteryId && b.LotteryOpenInfo.Expect == open.Expect && a.BusinessTypeId == (int)Enum_AccountBusinessType.BackPercent && a.EventId == b.Id && a.PayIn.HasValue
                             select a);
                //总返点金额
                var abTotalMoney = query.Count() > 0 ? query.Sum(n => n.PayIn.Value) : 0;
                //总返奖金额
                decimal backTotalMoney = 0;
                //开奖号int型集合
                var nList = open.ScheduleOpenCode.Split(',').Select(n => Convert.ToInt32(n)).ToList();
                
                #region 开奖
                if (isXZ)//规则开奖
                {
                    
                    //var pp = e.BetInfo.Where(n =>n.LotteryOpenId != loId&&n.ResultType==(int)Enum_ResultType.Wait).ToList();
                    //var pool = pp.Sum(n => n.BetMoney) - pp.Sum(n => n.BackMoney);
                    if (bList.Count > 0)
                    {
                        
                        var poolMoney=pool == null ? 0 : pool.PoolMoney;
                        List<int> OpenNumInOnce = new List<int>();//当期已重摇号组合索引
                        var index = AllCodeList.FindIndex(n => n == open.ScheduleOpenCode);
                        var cList = new List<int>();//所有组合摇奖号的索引
                        for (int i = 0; i < AllCodeList.Count; i++)
                        {
                            cList.Add(i);
                        }
                        #region 进行限制开奖
                        for (int i = 0; true; i++)
                        {
                            if (!OpenNumInOnce.Contains(index))
                            {
                                if (i > 0)//预开奖号不处理
                                {
                                    nList = GetAllCodeList()[index].Split(',').Select(n => Convert.ToInt32(n)).ToList();
                                }
                                if (LotteryOpenTool_11x5.isOutBetMoney(bList, nList, isXZ, betTotalMoney, abTotalMoney, poolMoney, out backTotalMoney))//若超额则保存此次摇号并重摇
                                {
                                    OpenNumInOnce.Add(index);//添加索引至已摇
                                    cList.Remove(index);//删除该索引
                                    index = random.Next(0, cList.Count);//从剩余索引号中随机取一个
                                    open.RerollCount++;//重摇次数+1
                                }
                                else
                                {
                                    break;//若不超额则退出循环
                                }
                            }
                            else
                            {
                                index = random.Next(0, GetAllCodeList().Count);//存在同号直接重新摇
                            }
                            if (OpenNumInOnce.Count >= 55440) //最多跑A(5,11):55440次
                            {
                                open.RerollCount = OpenNumInOnce.Count;
                                break;
                            }
                        }
                        #endregion
                        open.OpenCode = GetAllCodeList()[index];
                        
                    }
                }
                else if (isYK)//预开号开奖
                {
                    LotteryOpenTool_11x5.isOutBetMoney(bList, nList, isXZ, 0, 0, 0, out backTotalMoney);
                }
                else if (isFixed)//固定开奖
                {
                    nList.Clear();
                    foreach (var item in NoStrs)
                    {
                        int no = 0;
                        if (int.TryParse(item, out no) && no >= 1 && no <= 11)
                        {
                            nList.Add(Convert.ToInt32(item));
                        }
                        else
                        {
                            nList.Add(-1);
                        }
                    }
                    GetOpenNum_IntList1(nList);
                    open.OpenCode = string.Format("{0},{1},{2},{3},{4}", NumList11x5_Normal[nList[0] - 1], NumList11x5_Normal[nList[1] - 1], NumList11x5_Normal[nList[2] - 1], NumList11x5_Normal[nList[3] - 1], NumList11x5_Normal[nList[4] - 1]);
                    LotteryOpenTool_11x5.isOutBetMoney(bList, nList, isXZ, 0, 0, 0, out backTotalMoney);
                }
                if (bList.Count > 0)
                {
                    bList.ForEach(n => n.ResultType = (int)Enum_ResultType.Backing);
                }
                #endregion
                open.OpenStatus = (int)Enum_LotteryOpenStatus.Succeed;//开奖期改为已开
                var dt = EntitiesTool.GetDateTimeNow(e);
                open.OpenTime = dt;
                #region 更新开奖表LotteryOpenInfo
                var f = e.LotteryOpenInfo.FirstOrDefault(n => n.LotteryId == open.LotteryId && n.Expect == open.Expect);
                if (f != null)
                {
                    f.OpenTime = dt;
                    f.OpenCode = open.OpenCode;
                }
                else
                {
                    e.LotteryOpenInfo.Add(new LotteryOpenInfo
                    {
                        Expect = open.Expect,
                        LotteryId = open.LotteryId,
                        OpenCode = open.OpenCode,
                        OpenDate = open.ScheduleOpenTime.Date,
                        OpenTime = dt,
                    });
                } 
                #endregion
                #region 更新奖金池
                if (e.LotteryPrizePoolInfo.FirstOrDefault(n => n.LotteryOpenId == open.Id) == null)
                {
                    var p = new LotteryPrizePoolInfo
                    {
                        LotteryOpenId = open.Id,
                        TotalAgenBack = abTotalMoney,
                        TotalBack = backTotalMoney,
                        TotalBet = betTotalMoney,
                        Profit = betTotalMoney - backTotalMoney - abTotalMoney,
                    };
                    e.LotteryPrizePoolInfo.Add(p);//本期利润情况
                    //var pool = e.LotteryPrizePool.FirstOrDefault(n => n.LotteryId == open.LotteryId);
                    if (pool == null)
                    {
                        e.LotteryPrizePool.Add(new LotteryPrizePool
                        {
                            LotteryId = open.LotteryId,
                            PoolMoney = p.Profit,
                        });
                    }
                    else
                    {
                        pool.PoolMoney += p.Profit;
                    }
                }
                #endregion
                using (tran = new TransactionScope())
                {
                    e.SaveChanges();
                    tran.Complete();
                }
                //var betList = e.BetInfo.Where(n => n.LotteryOpenId == loId).ToList();//当期投注信息
                //betList.ForEach(n => n.ResultType = (int)Enum_ResultType.Backing);//投注单改为返奖中
                //上一期
                //下一期
                //var query = e.LotteryOpen.Where(n => n.Id == open.Id + 1).FirstOrDefault();//获取新一期
                //if (query != null)
                //{
                //    query.OpenStatus = (int)Enum_LotteryOpenStatus.Next;//修改新一期为待开
                //}

            }
        }
        /// <summary>
        /// 获取5位随机号
        /// </summary>
        /// <param name="nList"></param>
        List<int> GetOpenNum_IntList(List<int> nList)
        {
            if (nList == null)
            {
                nList = new List<int>();
            }
            var l = NumList11x5_NormalInt.ToList();
            while (nList.Count != 5)
            {
                var num = l[random.Next(0, l.Count)];
                nList.Add(num);
                l.Remove(num);
            }
            return nList;
        }
        /// <summary>
        /// 去除-1获取随机号
        /// </summary>
        /// <param name="nList"></param>
        List<int> GetOpenNum_IntList1(List<int> nList)
        {
            for (int i = 0; i < nList.Count; i++)
            {
                if(nList[i]==-1)
                {
                    var l = NumList11x5_NormalInt.Where(n => !nList.Contains(n)).ToList();
                    nList[i] = l[random.Next(0, l.Count)];
                }
            }
            return nList;
        }

        /// <summary>
        /// 进行开奖
        /// </summary>
        /// <param name="loId"></param>
        /// <param name="isFixed">固定开奖</param>
        /// <param name="NoStrs"></param>
        //public void OpeningNo(int LotteryId, string Except, decimal Limit, string ScheduleOpenCode)
        //{
        //    using (e = new LotteryAPPEntities())
        //    {
        //        //var open = e.LotteryOpen.Where(n => n.Id == loId).FirstOrDefault();
        //        //if (open.OpenStatus == (int)Enum_LotteryOpenStatus.Schedule)
        //        //{
        //        //    open.OpenStatus = (int)Enum_LotteryOpenStatus.Opening;//设置此期为开奖中
        //        //    open.OpenCode = open.ScheduleOpenCode;
        //        //    //e.SaveChanges();
        //        //}
        //        //由最大返奖比金额开始判断
        //        var bList = (from b in e.BetInfo
        //                     where b.LotteryId == LotteryId && b.LotteryOpenInfo.Expect == Except
        //                     orderby b.MaxBackMoney descending
        //                     select b).ToList();
        //        //总投注金额
        //        var betTotalMoney = bList.Sum(n => n.BetMoney);
        //        //奖金池金额
        //        var pool = e.LotteryPrizePool.FirstOrDefault(n => n.LotteryId == LotteryId);
        //        //总返点金额
        //        var query = (from a in e.AccountBusiness
        //                     from b in e.BetInfo
        //                     where b.LotteryOpenInfo.LotteryId == LotteryId && b.LotteryOpenInfo.Expect == Except && a.BusinessTypeId == (int)Enum_AccountBusinessType.BackPercent && a.EventId == b.Id && a.PayIn.HasValue
        //                     select a);
        //        //总返点金额
        //        var abTotalMoney = query.Count() > 0 ? query.Sum(n => n.PayIn.Value) : 0;
        //        //总返奖金额
        //        decimal backTotalMoney = 0;
        //        //开奖号int型集合
        //        var nList = ScheduleOpenCode.Split(',').Select(n => Convert.ToInt32(n)).ToList();
        //        #region 开奖
        //        //规则开奖
        //            if (bList.Count > 0)
        //            {
        //                var poolMoney = pool == null ? 0 : pool.PoolMoney;
        //                var index = AllCodeList.FindIndex(n => n == ScheduleOpenCode);
        //                var OpenNumInOnce = new List<int>();//当期已重摇号组合索引
        //                var cList = new List<int>();//所有组合摇奖号的索引
        //                for (int i = 0; i < AllCodeList.Count; i++)
        //                {
        //                    cList.Add(i);
        //                }
        //                #region 进行限制开奖
        //                for (int i = 0; true; i++)
        //                {
        //                    if (!OpenNumInOnce.Contains(index))
        //                    {
        //                        if (i > 0)//预开奖号不处理
        //                        {
        //                            nList = GetAllCodeList()[index].Split(',').Select(n => Convert.ToInt32(n)).ToList();
        //                        }
        //                        if (LotteryOpenTool_11x5.isOutBetMoney(bList, nList, true, betTotalMoney, abTotalMoney, poolMoney, out backTotalMoney))//若超额则保存此次摇号并重摇
        //                        {
        //                            OpenNumInOnce.Add(index);//添加索引至已摇
        //                            cList.Remove(index);//删除该索引
        //                            index = random.Next(0, cList.Count);//从剩余索引号中随机取一个
        //                            //open.RerollCount++;//重摇次数+1
        //                        }
        //                        else
        //                        {
        //                            break;//若不超额则退出循环
        //                        }
        //                    }
        //                    else
        //                    {
        //                        index = random.Next(0, GetAllCodeList().Count);//存在同号直接重新摇
        //                    }
        //                    if (OpenNumInOnce.Count >= 55440) //最多跑A(5,11):55440次
        //                    {
        //                        //open.RerollCount = OpenNumInOnce.Count;
        //                        break;
        //                    }
        //                }
        //                #endregion
        //                open.OpenCode = GetAllCodeList()[index];

        //            }
                
                
        //        if (bList.Count > 0)
        //        {
        //            bList.ForEach(n => n.ResultType = (int)Enum_ResultType.Backing);
        //        }
        //        #endregion
        //        open.OpenStatus = (int)Enum_LotteryOpenStatus.Succeed;//开奖期改为已开
        //        var dt = EntitiesTool.GetDateTimeNow();
        //        open.OpenTime = dt;
        //        #region 更新开奖表LotteryOpenInfo
        //        var f = e.LotteryOpenInfo.FirstOrDefault(n => n.LotteryId == open.LotteryId && n.Expect == open.Expect);
        //        if (f != null)
        //        {
        //            f.OpenTime = dt;
        //            f.OpenCode = open.OpenCode;
        //        }
        //        else
        //        {
        //            e.LotteryOpenInfo.Add(new LotteryOpenInfo
        //            {
        //                Expect = open.Expect,
        //                LotteryId = open.LotteryId,
        //                OpenCode = open.OpenCode,
        //                OpenDate = open.ScheduleOpenTime.Date,
        //                OpenTime = dt,
        //            });
        //        }
        //        #endregion
        //        #region 更新奖金池
        //        if (e.LotteryPrizePoolInfo.FirstOrDefault(n => n.LotteryOpenId == open.Id) == null)
        //        {
        //            var p = new LotteryPrizePoolInfo
        //            {
        //                LotteryOpenId = open.Id,
        //                TotalAgenBack = abTotalMoney,
        //                TotalBack = backTotalMoney,
        //                TotalBet = betTotalMoney,
        //                Profit = betTotalMoney - backTotalMoney - abTotalMoney,
        //            };
        //            e.LotteryPrizePoolInfo.Add(p);//本期利润情况
        //            //var pool = e.LotteryPrizePool.FirstOrDefault(n => n.LotteryId == open.LotteryId);
        //            if (pool == null)
        //            {
        //                e.LotteryPrizePool.Add(new LotteryPrizePool
        //                {
        //                    LotteryId = open.LotteryId,
        //                    PoolMoney = p.Profit,
        //                });
        //            }
        //            else
        //            {
        //                pool.PoolMoney += p.Profit;
        //            }
        //        }
        //        #endregion
        //        using (tran = new TransactionScope())
        //        {
        //            e.SaveChanges();
        //            tran.Complete();
        //        }
        //        //var betList = e.BetInfo.Where(n => n.LotteryOpenId == loId).ToList();//当期投注信息
        //        //betList.ForEach(n => n.ResultType = (int)Enum_ResultType.Backing);//投注单改为返奖中
        //        //上一期
        //        //下一期
        //        //var query = e.LotteryOpen.Where(n => n.Id == open.Id + 1).FirstOrDefault();//获取新一期
        //        //if (query != null)
        //        //{
        //        //    query.OpenStatus = (int)Enum_LotteryOpenStatus.Next;//修改新一期为待开
        //        //}

        //    }
        //}
    }
}
