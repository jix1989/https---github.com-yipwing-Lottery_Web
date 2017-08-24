using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotteryModel
{
    public class LotteryInfo_SSC
    {
        static List<LotteryPlay> lpList = new List<LotteryPlay>();
        //static List<LotteryPlay> slpList = new List<LotteryPlay>();
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
            #region 五星
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "五星直选复式",
                PayBack = 180000,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "五星直选单式",
                PayBack = 180000,
            });
            var ssc = new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "五星直选组合",
                PrizeClass = new Dictionary<int, decimal>(),
            };
            ssc.PrizeClass.Add(5, 180000);
            ssc.PrizeClass.Add(4, 18000);
            ssc.PrizeClass.Add(3, 1800);
            ssc.PrizeClass.Add(2, 180);
            ssc.PrizeClass.Add(1, 18);
            lpList.Add(ssc);
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "五星组选120",
                PayBack = 1500,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "五星组选60",
                PayBack = 3000,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "五星组选30",
                PayBack = 6000,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "五星组选20",
                PayBack = 9000,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "五星组选10",
                PayBack = 18000,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "五星组选5",
                PayBack = 36000,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "五星一帆风顺",
                PayBack = new decimal(4.38),
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "五星好事成双",
                PayBack = 22,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "五星三星报喜",
                PayBack = 210,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "五星四季发财",
                PayBack = 3900,
            });
            #endregion
            #region 四星
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "四星直选复式",
                PayBack = 18000,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "四星直选单式",
                PayBack = 18000,
            });
            ssc = new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "四星直选组合",
                PrizeClass = new Dictionary<int, decimal>(),
            };
            ssc.PrizeClass.Add(4, 18000);
            ssc.PrizeClass.Add(3, 1800);
            ssc.PrizeClass.Add(2, 180);
            ssc.PrizeClass.Add(1, 18);
            lpList.Add(ssc);
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "四星组选24",
                PayBack = 750,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "四星组选12",
                PayBack = 1500,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "四星组选6",
                PayBack = 3000,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "四星组选4",
                PayBack = 4500,
            });
            #endregion
            #region 百家
            ssc = new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "百家重复号",
                PrizeClass = new Dictionary<int, decimal>(),
            };
            ssc.PrizeClass.Add(5, new decimal(391.3));
            ssc.PrizeClass.Add(10, new decimal(197.8));
            ssc.PrizeClass.Add(20, new decimal(21.02));
            ssc.PrizeClass.Add(30, new decimal(13.0));
            ssc.PrizeClass.Add(60, new decimal(2.57));
            ssc.PrizeClass.Add(120, new decimal(5.96));
            lpList.Add(ssc);
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "百家顺子号",
                PayBack = 250,
            });
            ssc = new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "百家单双号",
                PrizeClass = new Dictionary<int, decimal>(),
            };
            ssc.PrizeClass.Add(5, new decimal(57.6));
            ssc.PrizeClass.Add(0, new decimal(57.6));
            ssc.PrizeClass.Add(4, new decimal(11.52));
            ssc.PrizeClass.Add(1, new decimal(11.52));
            ssc.PrizeClass.Add(3, new decimal(5.76));
            ssc.PrizeClass.Add(2, new decimal(5.76));
            lpList.Add(ssc);
            ssc = new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "百家大小号",
                PrizeClass = new Dictionary<int, decimal>(),
            };
            ssc.PrizeClass.Add(5, new decimal(57.6));
            ssc.PrizeClass.Add(0, new decimal(57.6));
            ssc.PrizeClass.Add(4, new decimal(11.52));
            ssc.PrizeClass.Add(1, new decimal(11.52));
            ssc.PrizeClass.Add(3, new decimal(5.76));
            ssc.PrizeClass.Add(2, new decimal(5.76));
            lpList.Add(ssc);
            #endregion
            #region 后三
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "后三直选复式",
                PayBack = 1800,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "后三直选单式",
                PayBack = 1800,
            });
            ssc = new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "后三直选组合",
                PrizeClass = new Dictionary<int, decimal>(),
            };
            ssc.PrizeClass.Add(3, 1800);
            ssc.PrizeClass.Add(2, 180);
            ssc.PrizeClass.Add(1, 18);
            lpList.Add(ssc);
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "后三直选和值",
                PayBack = 1800,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "后三直选跨度",
                PayBack = 1800,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "后三组三复式",
                PayBack = 600,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "后三组三单式",
                PayBack = 600,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "后三组六复式",
                PayBack = 300,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "后三组六单式",
                PayBack = 300,
            });
            ssc = new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "后三混合组选",
                PrizeClass = new Dictionary<int, decimal>(),
            };
            ssc.PrizeClass.Add(3, 600);
            ssc.PrizeClass.Add(6, 300);
            lpList.Add(ssc);
            ssc = new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "后三组选和值",
                PrizeClass = new Dictionary<int, decimal>(),
            };
            ssc.PrizeClass.Add(3, 600);
            ssc.PrizeClass.Add(6, 300);
            lpList.Add(ssc);
            ssc = new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "后三组选包胆",
                PrizeClass = new Dictionary<int, decimal>(),
            };
            ssc.PrizeClass.Add(3, 600);
            ssc.PrizeClass.Add(6, 300);
            lpList.Add(ssc);
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "后三和值尾数",
                PayBack = 18,
            });
            ssc = new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "后三特殊号",
                PrizeClass = new Dictionary<int, decimal>(),
            };
            ssc.PrizeClass.Add(3, 180);
            ssc.PrizeClass.Add(1, 30);
            ssc.PrizeClass.Add(2, 6);
            lpList.Add(ssc);
            #endregion
            #region 中三
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "中三直选复式",
                PayBack = 1800,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "中三直选单式",
                PayBack = 1800,
            });
            ssc = new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "中三直选组合",
                PrizeClass = new Dictionary<int, decimal>(),
            };
            ssc.PrizeClass.Add(3, 1800);
            ssc.PrizeClass.Add(2, 180);
            ssc.PrizeClass.Add(1, 18);
            lpList.Add(ssc);
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "中三直选和值",
                PayBack = 1800,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "中三直选跨度",
                PayBack = 1800,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "中三组三复式",
                PayBack = 600,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "中三组三单式",
                PayBack = 600,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "中三组六复式",
                PayBack = 300,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "中三组六单式",
                PayBack = 300,
            });
            ssc = new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "中三混合组选",
                PrizeClass = new Dictionary<int, decimal>(),
            };
            ssc.PrizeClass.Add(3, 600);
            ssc.PrizeClass.Add(6, 300);
            lpList.Add(ssc);
            ssc = new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "中三组选和值",
                PrizeClass = new Dictionary<int, decimal>(),
            };
            ssc.PrizeClass.Add(3, 600);
            ssc.PrizeClass.Add(6, 300);
            lpList.Add(ssc);
            ssc = new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "中三组选包胆",
                PrizeClass = new Dictionary<int, decimal>(),
            };
            ssc.PrizeClass.Add(3, 600);
            ssc.PrizeClass.Add(6, 300);
            lpList.Add(ssc);
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "中三和值尾数",
                PayBack = 18,
            });
            ssc = new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "中三特殊号",
                PrizeClass = new Dictionary<int, decimal>(),
            };
            ssc.PrizeClass.Add(3, 180);
            ssc.PrizeClass.Add(1, 30);
            ssc.PrizeClass.Add(2, 6);
            lpList.Add(ssc);
            #endregion
            #region 前三
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "前三直选复式",
                PayBack = 1800,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "前三直选单式",
                PayBack = 1800,
            });
            ssc = new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "前三直选组合",
                PrizeClass = new Dictionary<int, decimal>(),
            };
            ssc.PrizeClass.Add(3, 1800);
            ssc.PrizeClass.Add(2, 180);
            ssc.PrizeClass.Add(1, 18);
            lpList.Add(ssc);
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "前三直选和值",
                PayBack = 1800,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "前三直选跨度",
                PayBack = 1800,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "前三组三复式",
                PayBack = 600,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "前三组三单式",
                PayBack = 600,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "前三组六复式",
                PayBack = 300,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "前三组六单式",
                PayBack = 300,
            });
            ssc = new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "前三混合组选",
                PrizeClass = new Dictionary<int, decimal>(),
            };
            ssc.PrizeClass.Add(3, 600);
            ssc.PrizeClass.Add(6, 300);
            lpList.Add(ssc);
            ssc = new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "前三组选和值",
                PrizeClass = new Dictionary<int, decimal>(),
            };
            ssc.PrizeClass.Add(3, 600);
            ssc.PrizeClass.Add(6, 300);
            lpList.Add(ssc);
            ssc = new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "前三组选包胆",
                PrizeClass = new Dictionary<int, decimal>(),
            };
            ssc.PrizeClass.Add(3, 600);
            ssc.PrizeClass.Add(6, 300);
            lpList.Add(ssc);
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "前三和值尾数",
                PayBack = 18,
            });
            ssc = new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "前三特殊号",
                PrizeClass = new Dictionary<int, decimal>(),
            };
            ssc.PrizeClass.Add(3, 180);
            ssc.PrizeClass.Add(1, 30);
            ssc.PrizeClass.Add(2, 6);
            lpList.Add(ssc);
            #endregion
            #region 后二
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
                LotteryPlayName = "后二直选和值",
                PayBack = 180,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "后二直选跨度",
                PayBack = 180,
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
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "后二组选和值",
                PayBack = 90,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "后二组选包胆",
                PayBack = 90,
            });
            #endregion
            #region 前二
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
                LotteryPlayName = "前二直选和值",
                PayBack = 180,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "前二直选跨度",
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
                LotteryPlayName = "前二组选和值",
                PayBack = 90,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "前二组选包胆",
                PayBack = 90,
            });
            #endregion
            #region 不定位
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "后三一码",
                PayBack = new decimal(6.6),
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "前三一码",
                PayBack = new decimal(6.6),
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "后三二码",
                PayBack = new decimal(33),
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "前三二码",
                PayBack = new decimal(33),
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "四星一码",
                PayBack = new decimal(5.2),
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "四星二码",
                PayBack = new decimal(18.4),
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "五星二码",
                PayBack = new decimal(12),
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "五星三码",
                PayBack = new decimal(41),
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
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "前三大小单双",
                PayBack = new decimal(14.4),
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "后三大小单双",
                PayBack = new decimal(14.4),
            });
            #endregion
            #region 任选二
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "任选二直选复式",
                PayBack = 180,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "任选二直选单式",
                PayBack = 180,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "任选二直选和值",
                PayBack = 180,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "任选二组选复式",
                PayBack = 90,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "任选二组选单式",
                PayBack = 90,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "任选二组选和值",
                PayBack = 90,
            });
            #endregion
            #region 任选三
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "任选三直选复式",
                PayBack = 1800,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "任选三直选单式",
                PayBack = 1800,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "任选三直选和值",
                PayBack = 1800,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "任选三组三复式",
                PayBack = 600,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "任选三组三单式",
                PayBack = 600,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "任选三组六复式",
                PayBack = 300,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "任选三组六单式",
                PayBack = 300,
            });
            ssc = new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "任选三混合组选",
                PrizeClass = new Dictionary<int, decimal>(),
            };
            ssc.PrizeClass.Add(3, 600);
            ssc.PrizeClass.Add(6, 300);
            lpList.Add(ssc);
            ssc = new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "任选三组选和值",
                PrizeClass = new Dictionary<int, decimal>(),
            };
            ssc.PrizeClass.Add(3, 600);
            ssc.PrizeClass.Add(6, 300);
            lpList.Add(ssc);
            #endregion
            #region 任选四
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "任选四直选复式",
                PayBack = 18000,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "任选四直选单式",
                PayBack = 18000,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "任选四组选24",
                PayBack = 750,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "任选四组选12",
                PayBack = 1500,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "任选四组选6",
                PayBack = 3000,
            });
            lpList.Add(new LotteryPlay
            {
                BetPlayTypeCode = ++i,
                LotteryPlayName = "任选四组选4",
                PayBack = 4500,
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
        //public static List<LotteryPlay> SlpList()
        //{
        //    if (slpList.Count == 0)
        //    {
        //        slpList = LpList().Where(n => n.PrizeClass != null).ToList();
        //    }
        //    return slpList;
        //}
    }

}
