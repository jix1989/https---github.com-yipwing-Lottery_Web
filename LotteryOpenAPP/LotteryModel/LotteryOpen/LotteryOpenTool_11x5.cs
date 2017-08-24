using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotteryModel
{
    public static class LotteryOpenTool_11x5
    {
        static List<LotteryPlay> lpList = new List<LotteryPlay>();
        //static List<LotteryPlay> slpList = new List<LotteryPlay>();
        static void Initial()
        {
            int i = 0;
            lpList.Add(new LotteryPlay { LotteryPlayName = "前三直选复式", PayBack = new decimal(1811), BetPlayTypeCode = ++i, });
            lpList.Add(new LotteryPlay { LotteryPlayName = "前三直选单式", PayBack = new decimal(1811), BetPlayTypeCode = ++i });
            lpList.Add(new LotteryPlay { LotteryPlayName = "前三组选复式", PayBack = new decimal(301), BetPlayTypeCode = ++i });
            lpList.Add(new LotteryPlay { LotteryPlayName = "前三组选单式", PayBack = new decimal(301), BetPlayTypeCode = ++i });
            lpList.Add(new LotteryPlay { LotteryPlayName = "前三组选胆拖", PayBack = new decimal(301.95), BetPlayTypeCode = ++i });
            lpList.Add(new LotteryPlay { LotteryPlayName = "前二直选复式", PayBack = new decimal(201), BetPlayTypeCode = ++i });
            lpList.Add(new LotteryPlay { LotteryPlayName = "前二直选单式", PayBack = new decimal(201), BetPlayTypeCode = ++i });
            lpList.Add(new LotteryPlay { LotteryPlayName = "前二组选复式", PayBack = new decimal(100), BetPlayTypeCode = ++i });
            lpList.Add(new LotteryPlay { LotteryPlayName = "前二组选单式", PayBack = new decimal(100), BetPlayTypeCode = ++i });
            lpList.Add(new LotteryPlay { LotteryPlayName = "前二组选胆拖", PayBack = new decimal(100.65), BetPlayTypeCode = ++i });
            lpList.Add(new LotteryPlay { LotteryPlayName = "不定位", PayBack = new decimal(6.6), BetPlayTypeCode = ++i });
            lpList.Add(new LotteryPlay { LotteryPlayName = "定位胆", PayBack = new decimal(19.8), BetPlayTypeCode = ++i });//12
            #region 趣味型
            var prizeClass = new Dictionary<int, decimal>();
            prizeClass.Add(5, new decimal(140.3));//"5单0双"
            prizeClass.Add(4, new decimal(11.18));//"4单1双"
            prizeClass.Add(3, new decimal(4.06));//"3单2双"
            prizeClass.Add(2, new decimal(5.5));//"2单3双"
            prizeClass.Add(1, new decimal(27.45));//"1单4双"
            prizeClass.Add(0, new decimal(843.8));//"0单5双"
            lpList.Add(new LotteryPlay { LotteryPlayName = "趣味定_单双", PrizeClass = prizeClass, BetPlayTypeCode = ++i });//13

            prizeClass = new Dictionary<int, decimal>();
            prizeClass.Add(3, new decimal(29.48));
            prizeClass.Add(9, new decimal(29.48));
            prizeClass.Add(4, new decimal(13.2));
            prizeClass.Add(8, new decimal(13.2));
            prizeClass.Add(5, new decimal(9.15));
            prizeClass.Add(7, new decimal(9.15));
            prizeClass.Add(6, new decimal(8.1));
            lpList.Add(new LotteryPlay { LotteryPlayName = "趣味猜_中位", PrizeClass = prizeClass, BetPlayTypeCode = ++i });//14
            #endregion
            lpList.Add(new LotteryPlay { LotteryPlayName = "任选一中一", PayBack = new decimal(3.5), BetPlayTypeCode = ++i });//15
            lpList.Add(new LotteryPlay { LotteryPlayName = "任选二中二", PayBack = new decimal(10), BetPlayTypeCode = ++i });
            lpList.Add(new LotteryPlay { LotteryPlayName = "任选三中三", PayBack = new decimal(29.4), BetPlayTypeCode = ++i });
            lpList.Add(new LotteryPlay { LotteryPlayName = "任选四中四", PayBack = new decimal(119), BetPlayTypeCode = ++i });
            lpList.Add(new LotteryPlay { LotteryPlayName = "任选五中五", PayBack = new decimal(845.46), BetPlayTypeCode = ++i });//19
            lpList.Add(new LotteryPlay { LotteryPlayName = "任选六中五", PayBack = new decimal(140.3), BetPlayTypeCode = ++i });
            lpList.Add(new LotteryPlay { LotteryPlayName = "任选七中五", PayBack = new decimal(39.65), BetPlayTypeCode = ++i });
            lpList.Add(new LotteryPlay { LotteryPlayName = "任选八中五", PayBack = new decimal(14.7), BetPlayTypeCode = ++i });
            lpList.Add(new LotteryPlay { LotteryPlayName = "单式任选一中一", PayBack = new decimal(3.5), BetPlayTypeCode = ++i });
            lpList.Add(new LotteryPlay { LotteryPlayName = "单式任选二中二", PayBack = new decimal(10), BetPlayTypeCode = ++i });
            lpList.Add(new LotteryPlay { LotteryPlayName = "单式任选三中三", PayBack = new decimal(29.4), BetPlayTypeCode = ++i });
            lpList.Add(new LotteryPlay { LotteryPlayName = "单式任选四中四", PayBack = new decimal(119), BetPlayTypeCode = ++i });
            lpList.Add(new LotteryPlay { LotteryPlayName = "单式任选五中五", PayBack = new decimal(845.46), BetPlayTypeCode = ++i });
            lpList.Add(new LotteryPlay { LotteryPlayName = "单式任选六中五", PayBack = new decimal(140.3), BetPlayTypeCode = ++i });
            lpList.Add(new LotteryPlay { LotteryPlayName = "单式任选七中五", PayBack = new decimal(39.65), BetPlayTypeCode = ++i });
            lpList.Add(new LotteryPlay { LotteryPlayName = "单式任选八中五", PayBack = new decimal(14.7), BetPlayTypeCode = ++i });//30
            //胆拖
            lpList.Add(new LotteryPlay { LotteryPlayName = "胆拖任选二中二", PayBack = new decimal(10.06), BetPlayTypeCode = ++i });//31
            lpList.Add(new LotteryPlay { LotteryPlayName = "胆拖任选三中三", PayBack = new decimal(29.48), BetPlayTypeCode = ++i });
            lpList.Add(new LotteryPlay { LotteryPlayName = "胆拖任选四中四", PayBack = new decimal(119.9), BetPlayTypeCode = ++i });
            lpList.Add(new LotteryPlay { LotteryPlayName = "胆拖任选五中五", PayBack = new decimal(844.85), BetPlayTypeCode = ++i });
            lpList.Add(new LotteryPlay { LotteryPlayName = "胆拖任选六中五", PayBack = new decimal(140.3), BetPlayTypeCode = ++i });
            lpList.Add(new LotteryPlay { LotteryPlayName = "胆拖任选七中五", PayBack = new decimal(39.65), BetPlayTypeCode = ++i });
            lpList.Add(new LotteryPlay { LotteryPlayName = "胆拖任选八中五", PayBack = new decimal(14.7), BetPlayTypeCode = ++i });//37
            //
            //lpList = lpList.OrderByDescending(n => n.PayBack).ToList();

        }
        public static List<LotteryPlay> LpList()
        {
            if (lpList.Count == 0)
            {
                Initial();
            }
            return lpList;
        }
        //public static List<LotteryPlay> SlpList()
        //{
        //    if (slpList.Count == 0)
        //    {
        //        slpList = LpList().Where(n => n.PrizeClass != null).ToList();
        //    }
        //    return slpList;
        //}
        /// <summary>
        /// 判断当期奖金是否超额
        /// </summary>
        /// <param name="BList"></param>
        /// <param name="openNo"></param>
        /// <returns>true为超额</returns>
        public static bool isOutBetMoney(List<BetInfo> BList, List<int> openCode, bool isLimit, decimal betTotalMoney, decimal abTotalMoney, decimal Prizepool, out decimal backTotalMoney)
        {
            var flag = false;
            backTotalMoney = 0;//总返奖金额
            var f3 = openCode.Take(3).ToList();//前三号字符串
            var f2 = openCode.Take(2).ToList();//前二号字符串
            var dan = openCode.Where(n => n % 2 != 0).Count();//单号个数
            var zhongwei = openCode.OrderBy(n => n).ToList()[2];//中位值
            foreach (var item in BList)
            {
                decimal backMoney = 0;
                item.WinUnit = isWin(item.BetPlayTypeCode, item.BetNum, openCode, f3, f2, dan, zhongwei, out backMoney);//中奖次数
                if (item.WinUnit > 0)
                {
                    if (!item.IsGetBackPercent)//若不要返点
                    {
                        item.BackMoney = AgentCalculateTool.GetAgentBackMoney_11x5(backMoney, item.GetBackPercent);
                    }
                    else 
                    {
                        item.BackMoney = backMoney;
                    }
                    item.BackMoney = item.BackMoney * (item.BetMoney / item.BetUnit / 2);//(item.BetMoney /item.BetUnit/2)=投注单位(元角分厘)*倍数=中奖金额倍数
                    backTotalMoney += item.BackMoney;
                    //if (SlpList().Count(n => n.BetPlayTypeCode == item.BetPlayTypeCode) == 0)//非特殊型中奖
                    //{

                    //    item.BackMoney = item.WinUnit * item.MaxBackMoney;
                    //    backTotalMoney += item.BackMoney;
                    //}
                    //else
                    //{
                    //    item.BackMoney = SlpList().FirstOrDefault(n => n.SpecialValue == item.WinUnit).PayBack * (item.BetMoney / item.BetUnit / 2);
                    //    backTotalMoney += item.BackMoney;//特殊型按默认奖金算
                    //    item.WinUnit = 1;
                    //}
                    //flag = (backTotalMoney / new decimal(0.995)) > betTotalMoney;//中奖金额是否小于等于总投注的91.5%
                    //flag = backTotalMoney > (Prizepool<=0?(new decimal(0.916) * betTotalMoney):(new decimal(0.8) * betTotalMoney + Prizepool));//中奖金额是否小于等于总投注
                    if (isLimit)
                    {
                        flag = backTotalMoney > (betTotalMoney - abTotalMoney) + (Prizepool < new decimal(0.1) * betTotalMoney ? 0 : Prizepool - new decimal(0.1) * betTotalMoney);
                        if (flag)
                        {
                            break;
                        } 
                    }
                }
            }
            return flag;
        }
        /// <summary>
        /// 获得中奖总金额
        /// </summary>
        /// <returns></returns>
        public static decimal GetBackMoney(List<BetInfo> BList, List<int> openNum, List<int> f3, List<int> f2, int dan, int zhongwei)
        {
            decimal backTotalMoney = 0;
            foreach (var item in BList)
            {
                decimal backMoney = 0;
                item.WinUnit = isWin(item.BetPlayTypeCode, item.BetNum, openNum, f3, f2, dan, zhongwei, out backMoney);//中奖次数
                if (item.WinUnit > 0)
                {
                    //if (SlpList().Count(n => n.BetPlayTypeCode == item.BetPlayTypeCode) == 0)//非特殊型中奖
                    //{
                    //    item.BackMoney = item.WinUnit * item.MaxBackMoney;
                    //    backTotalMoney += item.BackMoney;
                    //}
                    //else
                    //{
                    //    item.BackMoney = SlpList().FirstOrDefault(n => n.SpecialValue == item.WinUnit).PayBack * (item.BetMoney / item.BetUnit / 2);
                    //    backTotalMoney += item.BackMoney;//特殊型按默认奖金算
                    //    item.WinUnit = 1;//特殊型只会中一次(大概)
                    //}
                }
            }
            return backTotalMoney;
        }
        /// <summary>
        /// 开奖金额集合返回
        /// </summary>
        /// <param name="BList"></param>
        /// <param name="openNum"></param>
        public static List<BetInfo> GetBackMoney(List<BetInfo> BList, List<int> openNum, List<int> f3, List<int> f2, int dan, int zhongwei, DateTime dt)
        {
            foreach (var item in BList)
            {
                decimal backMoney = 0;
                item.WinUnit = isWin(item.BetPlayTypeCode, item.BetNum, openNum, f3, f2, dan, zhongwei, out backMoney);//中奖次数
                item.ResultType = item.WinUnit > 0 ? (int)Enum_ResultType.True : (int)Enum_ResultType.False;
                item.BackTime = dt;
                if (item.WinUnit > 0)
                {
                    //if (SlpList().Count(n => n.BetPlayTypeCode == item.BetPlayTypeCode) == 0)
                    //{
                    //    item.BackMoney = item.WinUnit * item.MaxBackMoney;
                    //}
                    //else
                    //{
                    //    item.BackMoney = SlpList().FirstOrDefault(n => n.SpecialValue == item.WinUnit).PayBack * (item.BetMoney / item.BetUnit / 2);//特殊型默认都返点
                    //    item.WinUnit = 1;
                    //}
                }
            }
            return BList;
        }
        /// <summary>
        /// 开奖判断
        /// </summary>
        /// <param name="LotteryPlayName"></param>
        /// <param name="betNo"></param>
        /// <param name="openNo"></param>
        /// <returns></returns>
        public static int isWin(int BetPlayTypeCode, string betNum, List<int> openCode, List<int> f3, List<int> f2, int dan, int zhongwei, out decimal BackMoney)
        {
            int winTimes = 0;
            BackMoney = 0;
            var b1 = new List<List<int>>();//投注号
            if (BetPlayTypeCode == 13)
            {
                betNum = MyTool.ChangeBetNumTSH(betNum);
            }
            //if (BetPlayTypeCode == 12) 
            //{
            //    var str = betNum.Split('|');
            //    foreach (var item in str)
            //    {
            //        if (item.Length > 1)
            //        {
            //            b1.Add(item.Split(' ').Select(w => Convert.ToInt32(w)).ToList());
            //        }
            //        else 
            //        {
            //            b1.Add(null);
            //        }
            //    }
            //}
            //else if (betNum.IndexOf('|') > -1)//()
            //{
            //    b1 = betNum.Split('|').Select(
            //            n => n.Split(' ').Select(w => Convert.ToInt32(w)).ToList()
            //            ).ToList();
            //}
            //else
            //{
            //    b1.Add(betNum.Split(' ').Select(w => Convert.ToInt32(w)).ToList());
            //}
            ////else 
            ////{
            ////    foreach (var item in betNum.Split('|'))
            ////    {
            ////        if (string.IsNullOrEmpty(item))
            ////        {
            ////            b1.Add(new List<int>());
            ////        }
            ////        else 
            ////        {
            ////            b1.Add(item.Split(' ').Select(w => Convert.ToInt32(w)).ToList());
            ////        }
            ////    }
            ////}
            if (betNum.IndexOf('|') > -1)
            {
                foreach (var item in betNum.Split('|'))
                {
                    if (item.Length > 0)
                    {
                        b1.Add(item.Split(' ').Select(w => Convert.ToInt32(w)).ToList());
                    }
                    else
                    {
                        b1.Add(null);
                    }
                }
            }
            else
            {
                b1.Add(betNum.Split(' ').Select(w => Convert.ToInt32(w)).ToList());
            }
            switch (BetPlayTypeCode)
            {
                #region 前三
                case 1://"前三直选复式"
                    winTimes = b1[0].Contains(openCode[0]) && b1[1].Contains(openCode[1]) && b1[2].Contains(openCode[2]) ? 1 : 0;
                    break;
                case 2://"前三直选单式":
                    winTimes = b1.Exists(n => n[0] == openCode[0] && n[1] == openCode[1] && n[2] == openCode[2]) ? 1 : 0;//前3个号顺序数值一致
                    break;
                case 3://"前三组选复式":
                    winTimes = b1[0].Contains(openCode[0]) && b1[0].Contains(openCode[1]) && b1[0].Contains(openCode[2]) ? 1 : 0;
                    break;
                case 4://"前三组选单式":
                    winTimes = b1.Exists(n => n.Contains(openCode[0]) && n.Contains(openCode[1]) && n.Contains(openCode[2])) ? 1 : 0;
                    break;
                case 5://"前三组选胆拖":
                    winTimes = dtPlay(b1, f3, 3, 3);
                    break;
                #endregion
                #region 前二
                case 6://"前二直选复式":
                    winTimes = b1[0].Contains(openCode[0]) && b1[1].Contains(openCode[1]) ? 1 : 0;
                    break;
                case 7://"前二直选单式":
                    winTimes = b1.Exists(n => n[0] == openCode[0]&&n[1] == openCode[1]) ? 1 : 0;//前2个号顺序数值一致
                    break;
                case 8://"前二组选复式":
                    winTimes = b1[0].Contains(openCode[0]) && b1[0].Contains(openCode[1]) ? 1 : 0;
                    break;
                case 9://"前二组选单式":
                    winTimes = b1.Exists(n => n.Contains(openCode[0]) && n.Contains(openCode[1]))? 1 : 0;
                    break;
                case 10://"前二组选胆拖":
                    winTimes = dtPlay(b1, f2, 2, 2);
                    break;
                #endregion
                #region 不定位，定位胆，趣味型
                case 11://"不定位"://前三位
                    winTimes = (from a in b1[0]
                                from b in f3
                                where a == b
                                select a).Count();
                    break;
                case 12://"定位胆"://前三位
                    for (int i = 0; i < b1.Count; i++)//投选几位判断几位,b1.Length取值(1-3)
                    {
                        if (b1[i]!=null)
                        {
                            winTimes += b1[i].Contains(openCode[i]) ? 1 : 0; 
                        }
                    }
                    break;
                //"趣味定_单双":
                case 13:
                    if (b1[0].Contains(dan))
                    {
                        winTimes = 1;
                        BackMoney = winTimes * LpList()[BetPlayTypeCode - 1].PrizeClass[dan]; 
                    }
                    break;
                //"趣味猜_中位":
                case 14:
                    if (b1[0].Contains(zhongwei))
                    {
                        winTimes = 1;
                        BackMoney = winTimes * LpList()[BetPlayTypeCode - 1].PrizeClass[zhongwei]; 
                    }
                    break;
                #endregion
                #region 任选X中X
                case 15://"任选一中一":
                case 16://"任选二中二":
                case 17://"任选三中三":
                case 18://"任选四中四":
                    winTimes = rxPlay(b1[0], openCode, BetPlayTypeCode - 14, BetPlayTypeCode - 14);
                    break;
                case 19://"任选五中五":
                case 20://"任选六中五":
                case 21://"任选七中五":
                case 22://"任选八中五":
                    winTimes = rxPlay(b1[0], openCode, 5, BetPlayTypeCode - 14);
                    break;
                #endregion
                #region 单式任选X中X
                case 23://"单式任选一中一":  
                case 24://"单式任选二中二":
                case 25://"单式任选三中三":
                case 26://"单式任选四中四":
                    winTimes = rxPlay_ds(b1, openCode, BetPlayTypeCode - 22);
                    break;
                case 27://"单式任选五中五":
                case 28://"单式任选六中五":
                case 29://"单式任选七中五":
                case 30://"单式任选八中五":
                    winTimes = rxPlay_ds(b1, openCode, 5);
                    break;
                #endregion
                #region 任选胆拖X中X
                case 31://"胆拖任选二中二":
                case 32://"胆拖任选三中三":
                case 33://"胆拖任选四中四":
                    winTimes = dtPlay(b1, openCode, BetPlayTypeCode - 29, BetPlayTypeCode - 29);
                    break;
                case 34://"胆拖任选五中五":
                case 35://"胆拖任选六中五":
                case 36://"胆拖任选七中五":
                case 37://"胆拖任选八中五":
                    winTimes = dtPlay(b1, openCode, 5, BetPlayTypeCode - 29);
                    break;
                #endregion
                
            }
            //不具有奖金的玩法奖金计算
            if (LpList()[BetPlayTypeCode - 1].PrizeClass == null)
            {
                BackMoney = winTimes * LpList()[BetPlayTypeCode - 1].PayBack;
            }
            return winTimes;
        }

        #region 玩法算法
        /// <summary>
        /// 胆拖玩法
        /// </summary>
        /// <param name="b1">下注号</param>
        /// <param name="b2">开奖号</param>
        /// <param name="need">中几个号才算中</param>
        /// <returns></returns>
        static int dtPlay(List<List<int>> b1, List<int> b2, int need, int choice)
        {
            var dt = (from a in b1[0]//匹配胆码
                      from b in b2
                      where a == b
                      select a).Count();
            if (choice > need)//玩法任选X>中Y时
            {
                if (dt == 5) return MyTool.CalculateCombination(choice - b1[0].Count, b1[1].Count);//胆码全中
                return rxPlay(b1[1], b2, need - dt, choice - b1[0].Count);//胆码未全中
            }
            //玩法任选X中X时
            if (dt == b1[0].Count)//胆码全中则匹配拖码
            {
                return rxPlay(b1[1], b2, need - dt, choice - b1[0].Count);//胆码全中后相当于任选X中X
            }
            return 0;
        }
        /// <summary>
        /// 任选算法复式
        /// </summary>
        /// <param name="b1">下注号</param>
        /// <param name="b2">开奖号</param>
        /// <param name="need">中几个号才算中</param>
        /// <returns></returns>
        static int rxPlay(List<int> b1, List<int> b2, int need, int choice)
        {
            int zhong = (from a in b1//匹配中奖号码
                         from b in b2
                         where a == b
                         select a).Count();
            if (zhong >= need)
            {
                if (choice > need) return MyTool.CalculateCombination(choice - need, b1.Count - need);
                return MyTool.CalculateCombination(need, zhong);
            }
            return 0;
        }

        /// <summary>
        /// 任选算法单式
        /// </summary>
        /// <param name="b1">下注号</param>
        /// <param name="b2">开奖号</param>
        /// <param name="need">中几个号才算中</param>
        /// <returns></returns>
        static int rxPlay_ds(List<List<int>> b1, List<int> b2, int need)
        {
            return b1.Where(n => (from a in n
                                  from b in b2
                                  where a == b
                                  select a).Count() == need).Count();
        }
        #endregion
    }


}
