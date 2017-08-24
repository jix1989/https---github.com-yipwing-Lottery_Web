using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotteryModel
{
    public class LotteryOpenTool_3D
    {
        static List<LotteryPlay> lpList = new List<LotteryPlay>();
        static List<LotteryPlay> slpList = new List<LotteryPlay>();
        static void Initial()
        {
            int i = 0;
            #region 定位胆
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "定位胆",
                PayBack = 18,
            });
            #endregion
            #region 三星
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "三星直选复式",
                PayBack = 1800,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "三星直选单式",
                PayBack = 1800,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "三星直选和值",
                PayBack = 1800,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "三星组三复式",
                PayBack = 600,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "三星组三单式",
                PayBack = 600,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "三星组六复式",
                PayBack = 300,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "三星组六单式",
                PayBack = 300,
            });
            var ssc = new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "三星混合组选",
                PrizeClass = new Dictionary<int, decimal>(),
            };
            ssc.PrizeClass.Add(3, 600);
            ssc.PrizeClass.Add(6, 300);
            lpList.Add(ssc);
            ssc = new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "三星组选和值",
                PrizeClass = new Dictionary<int, decimal>(),
            };
            ssc.PrizeClass.Add(3, 600);
            ssc.PrizeClass.Add(6, 300);
            lpList.Add(ssc);
            #endregion
            #region 二星
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "前二直选复式",
                PayBack = 180,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "前二直选单式",
                PayBack = 180,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "后二直选复式",
                PayBack = 180,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "后二直选单式",
                PayBack = 180,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "前二组选复式",
                PayBack = 90,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "前二组选单式",
                PayBack = 90,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "后二组选复式",
                PayBack = 90,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "后二组选单式",
                PayBack = 90,
            });
            #endregion
            #region 不定位
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "一码不定位",
                PayBack = new decimal(6.6),
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "二码不定位",
                PayBack = new decimal(33),
            });
            #endregion
            #region 大小单双
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "前二大小单双",
                PayBack = new decimal(7.2),
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "后二大小单双",
                PayBack = new decimal(7.2),
            });
            #endregion
        }
        public static List<LotteryPlay> LpList()
        {
            if (lpList.Count == 0)
            {
                Initial();
            }
            return lpList;
        }
        public static List<LotteryPlay> SlpList()
        {
            if (slpList.Count == 0)
            {
                slpList = LpList().Where(n => n.PrizeClass != null).ToList();
            }
            return slpList;
        }
        /// <summary>
        /// 开奖判断
        /// </summary>
        public static int isWin(int BetPlayTypeCode, string betNum, List<int> rxdswz, List<int> openCode, List<int> h2, List<int> q2, int dan, int da, out decimal BackMoney)
        {
            int winTimes = 0;
            List<ZXLB> zxlbList = null;
            BackMoney = 0;
            var b1 = new List<List<int>>();//投注号
            if (!LotteryInfo_SSC.LpList().FirstOrDefault(n => n.BetPlayTypeCode == BetPlayTypeCode).LotteryPlayName.Contains("单式"))
            {
                b1 = betNum.Split('|').Select(
                        n => n.Split(' ').Select(w => Convert.ToInt32(w)).ToList()
                        ).ToList();
            }
            switch (BetPlayTypeCode)
            {
                #region 定位胆
                case 1://定位胆
                    for (int i = 0; i < openCode.Count; i++)
                    {
                        winTimes += b1[i].Contains(openCode[i]) ? 1 : 0;
                    }
                    break;
                #endregion
                #region 三星
                case 2://三星直选复式
                    winTimes = b1[0].Contains(openCode[0]) && b1[1].Contains(openCode[1]) && b1[2].Contains(openCode[2]) ? 1 : 0;
                    break;
                case 3://三星直选单式
                    winTimes = betNum.Contains(string.Format("{0}{1}{2}", openCode[0], openCode[1], openCode[2])) ? 1 : 0;
                    break;
                case 4://三星直选和值
                    winTimes = b1[0].Contains(openCode[0] + openCode[1] + openCode[2]) ? 1 : 0;
                    break;
                case 5://三星组三复式
                    winTimes =LotteryPlayArithmetic.zxfs(b1,  zxlbList, 3, 2, openCode);
                    break;
                case 6://三星组三单式
                    winTimes = LotteryPlayArithmetic.zxds(betNum,  zxlbList, 3, openCode);
                    break;
                case 7://三星组六复式
                    winTimes = LotteryPlayArithmetic.zxfs(b1,  zxlbList, 6, 3, openCode);
                    break;
                case 8://三星组六单式
                    winTimes = LotteryPlayArithmetic.zxds(betNum,  zxlbList, 6, openCode);
                    break;
                case 9://三星混合组选
                    LotteryPlayArithmetic.hshhzx(BetPlayTypeCode, betNum,  zxlbList, out winTimes, out BackMoney, openCode);
                    break;
                case 10://三星组选和值
                    LotteryPlayArithmetic.hszxhz(BetPlayTypeCode, b1,  zxlbList, out winTimes, out BackMoney, openCode);
                    break;
                #endregion
                #region 二星
                case 11://前二直选复式
                    winTimes = b1[0].Contains(openCode[0]) && b1[1].Contains(openCode[1]) ? 1 : 0;
                    break;
                case 12://前二直选单式
                    winTimes = betNum.Contains(string.Format("{0}{1}", openCode[0], openCode[1])) ? 1 : 0;
                    break;
                case 13://后二直选复式
                    winTimes = b1[0].Contains(openCode[0]) && b1[1].Contains(openCode[1]) ? 1 : 0;
                    break;
                case 14://后二直选单式
                    winTimes = betNum.Contains(string.Format("{0}{1}", openCode[0], openCode[1])) ? 1 : 0;
                    break;
                case 15://前二组选复式
                    winTimes = LotteryPlayArithmetic.zxfs(b1,  zxlbList, 1, 2, q2);
                    break;
                case 16://前二组选单式
                    winTimes = LotteryPlayArithmetic.zxds(betNum,  zxlbList, 1, q2);
                    break;
                case 17://后二组选复式
                    winTimes = LotteryPlayArithmetic.zxfs(b1,  zxlbList, 1, 2, h2);
                    break;
                case 18://后二组选单式
                    winTimes = LotteryPlayArithmetic.zxds(betNum,  zxlbList, 1, h2);
                    break;
                #endregion
                #region 不定位
                case 19://一码不定位
                    winTimes = LotteryPlayArithmetic.bdw(b1, 1, openCode);
                    break;
                case 20://二码不定位
                    winTimes = LotteryPlayArithmetic.bdw(b1, 1, openCode);
                    break;
                #endregion
                #region 大(6)小(5)单(1)双(0)
                case 21://前二大小单双
                    winTimes = LotteryPlayArithmetic.pd_dxds(openCode[0], b1[0]) && LotteryPlayArithmetic.pd_dxds(openCode[1], b1[1]) ? 1 : 0;
                    break;
                case 22://后二大小单双
                    winTimes = LotteryPlayArithmetic.pd_dxds(openCode[1], b1[0]) && LotteryPlayArithmetic.pd_dxds(openCode[2], b1[1]) ? 1 : 0;
                    break;
                #endregion
            }
            //不具有奖级玩法类型的中奖金额
            if (LpList()[BetPlayTypeCode-1].PrizeClass == null)
            {
                BackMoney = winTimes * LpList()[BetPlayTypeCode - 1].PayBack;
            }
            return winTimes;
        }
    }
}
