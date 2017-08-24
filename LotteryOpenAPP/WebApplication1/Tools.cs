using LotteryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;

namespace WebApplication1
{
    public class Tools
    {
        
        static Dictionary<string, string> JmDic = new Dictionary<string, string>();
        #region 算注相关
        /// <summary>
        /// 计算注数和金额
        /// </summary>
        public static int Calculate(string lotteryType, int playId, string betNum, string wz, int betUnit)
        {
            var tList = new List<List<string>>();//投注号
            var wzList = new List<int>();
            var bet = 0;
            switch (lotteryType)
            {
                #region 时时彩
                case "ssc":
                    
                    if (LotteryInfo_SSC.LpList().FirstOrDefault(i => i.BetPlayTypeCode == playId).LotteryPlayName.Contains("单式"))
                    {
                        //betUnit = betNum.Trim().Split('|').Count();
                        return betUnit;
                    }
                    if (betNum.IndexOf('|') > -1)
                    {
                        tList = betNum.Split('|').Select(
                                i => i.Split(' ').ToList()
                                ).ToList();
                    }
                    else
                    {
                        tList.Add(betNum.Split(' ').ToList());
                    }
                    if (!string.IsNullOrEmpty(wz))
                    {
                        wzList = wz.Split(',').Select(w => Convert.ToInt32(w)).ToList();
                    }
                    var n = tList.Count > 0 ? tList[0].Count : 0;
                    var m = tList.Count > 1 ? tList[1].Count : 0;
                    var x = tList.Count > 1 ? tList[1].Count(w => tList[0].Contains(w)) : 0;
                    var a = tList[0].Count(w => w.Length > 0);
                    var b = tList.Count > 1 ? tList[1].Count(w => w.Length > 0) : 0;
                    var c = tList.Count > 2 ? tList[2].Count(w => w.Length > 0) : 0;
                    var d = tList.Count > 3 ? tList[3].Count(w => w.Length > 0) : 0;
                    var e = tList.Count > 4 ? tList[4].Count(w => w.Length > 0) : 0;
                    switch (playId)
                    {
                        #region 定位胆
                        case 1://定位胆
                            bet = BetCalculateTool.CalculateN(tList);
                            break;
                        #endregion
                        #region 五星
                        case 2://五星直选复式
                            bet = a * b * c * d * e;
                            break;
                        case 4://五星直选组合
                            bet = a * b * c * d * e * 5;
                            break;
                        case 5://五星组选120(全不同号)
                            bet = MyTool.CalculateCombination(5, tList.Sum(w => w.Count));
                            break;
                        case 6://五星组选60(一对)
                            bet = (n - x) * MyTool.CalculateCombination(3, m) + x * MyTool.CalculateCombination(3, m - 1);
                            break;
                        case 7://五星组选30(两对)
                            bet = (m - x) * MyTool.CalculateCombination(2, n) + x * MyTool.CalculateCombination(2, n - 1);
                            break;
                        case 8://五星组选20(三条)
                            bet = (n - x) * MyTool.CalculateCombination(2, m) + x * MyTool.CalculateCombination(2, m - 1);
                            break;
                        case 9://五星组选10(三带二)
                        //bet = (n-x)*c(1,m)+x*C(1,m-1)
                        //break;
                        case 10://五星组选5(四条)
                            bet = (n - x) * MyTool.CalculateCombination(1, m) + x * MyTool.CalculateCombination(1, m - 1);
                            break;
                        case 11://五星一帆风顺
                        case 12://五星好事成双
                        case 13://五星三星报喜
                        case 14://五星四季发财
                            bet = BetCalculateTool.CalculateN(tList);
                            break;
                        #endregion
                        #region 四星
                        case 15://四星直选复式
                            bet = a * b * c * d;
                            break;
                        case 17://四星直选组合
                            bet = a * b * c * d * 4;
                            break;
                        case 18://四星组选24(全不同号)
                            bet = MyTool.CalculateCombination(4, tList.Sum(w => w.Count));
                            break;
                        case 19://四星组选12(一对)
                            bet = (n - x) * MyTool.CalculateCombination(2, m) + x * MyTool.CalculateCombination(2, m - 1);
                            break;
                        case 20://四星组选6(两对)
                            bet = MyTool.CalculateCombination(2, tList.Sum(w => w.Count));
                            break;
                        case 21://四星组选4(三条)
                            bet = (n - x) * MyTool.CalculateCombination(1, m) + x * MyTool.CalculateCombination(1, m - 1);
                            break;
                        #endregion
                        #region 百家
                        case 22://百家重复号
                        case 23://百家顺子号
                        case 24://百家单双号
                        case 25://百家大小号
                            bet = BetCalculateTool.CalculateN(tList);
                            break;
                        #endregion
                        #region 后三
                        case 26://后三直选复式
                            bet = a * b * c;
                            break;
                        case 28://后三直选组合
                            bet = a * b * c * 3;
                            break;
                        case 29://后三直选和值
                            foreach (var item in tList[0])
                            {
                                bet += bet_zxhz(3, Convert.ToInt32(item));
                            }
                            break;
                        case 30://后三直选跨度
                            foreach (var item in tList[0])
                            {
                                bet += bet_zxkd(3, Convert.ToInt32(item));
                            }
                            break;
                        case 31://后三组三复式
                            bet = a * (a - 1);
                            break;
                        case 33://后三组六复式
                            bet = MyTool.CalculateCombination(3, a);
                            break;
                        case 36://后三组选和值
                            foreach (var item in tList[0])
                            {
                                bet += bet_zuxhz(3, Convert.ToInt32(item));
                            }
                            break;
                        case 37://后三组选包胆
                            bet = 54;
                            break;
                        case 38://后三和值尾数
                        case 39://后三特殊号
                            bet = BetCalculateTool.CalculateN(tList);
                            break;
                        #endregion
                        #region 中三
                        case 40://中三直选复式
                            bet = a * b * c;
                            break;
                        case 42://中三直选组合
                            bet = a * b * c * 3;
                            break;
                        case 43://中三直选和值
                            foreach (var item in tList[0])
                            {
                                bet += bet_zxhz(3, Convert.ToInt32(item));
                            }
                            break;
                        case 44://中三直选跨度
                            foreach (var item in tList[0])
                            {
                                bet += bet_zxkd(3, Convert.ToInt32(item));
                            }
                            break;
                        case 45://中三组三复式
                            bet = a * (a - 1);
                            break;
                        case 47://中三组六复式
                            bet = MyTool.CalculateCombination(3, a);
                            break;
                        case 50://中三组选和值
                            foreach (var item in tList[0])
                            {
                                bet += bet_zuxhz(3, Convert.ToInt32(item));
                            }
                            break;
                        case 51://中三组选包胆
                            bet = 54;
                            break;
                        case 52://中三和值尾数
                        case 53://中三特殊号
                            bet = BetCalculateTool.CalculateN(tList);
                            break;
                        #endregion
                        #region 前三
                        case 54://前三直选复式
                            bet = a * b * c;
                            break;
                        case 56://前三直选组合
                            bet = a * b * c * 3;
                            break;
                        case 57://前三直选和值
                            foreach (var item in tList[0])
                            {
                                bet += bet_zxhz(3, Convert.ToInt32(item));
                            }
                            break;
                        case 58://前三直选跨度
                            foreach (var item in tList[0])
                            {
                                bet += bet_zxkd(3, Convert.ToInt32(item));
                            }
                            break;
                        case 59://前三组三复式
                            bet = a * (a - 1);
                            break;
                        case 61://前三组六复式
                            bet = MyTool.CalculateCombination(3, a);
                            break;
                        case 64://前三组选和值
                            foreach (var item in tList[0])
                            {
                                bet += bet_zuxhz(3, Convert.ToInt32(item));
                            }
                            break;
                        case 65://前三组选包胆
                            bet = 54;
                            break;
                        case 66://前三和值尾数
                        case 67://前三特殊号
                            bet = BetCalculateTool.CalculateN(tList);
                            break;
                        #endregion
                        #region 后二
                        case 68://后二直选复式
                            bet = a * b;
                            break;
                        case 69://后二直选单式

                            break;
                        case 70://后二直选和值
                            foreach (var item in tList[0])
                            {
                                bet += bet_zxhz(2, Convert.ToInt32(item));
                            }
                            break;
                        case 71://后二直选跨度
                            foreach (var item in tList[0])
                            {
                                bet += bet_zxkd(2, Convert.ToInt32(item));
                            }
                            break;
                        case 72://后二组选复式
                            bet = MyTool.CalculateCombination(2, a);
                            break;
                        case 73://后二组选单式

                            break;
                        case 74://后二组选和值
                            foreach (var item in tList[0])
                            {
                                bet += bet_zuxhz(2, Convert.ToInt32(item));
                            }
                            break;
                        case 75://后二组选包胆
                            bet = 9;
                            break;
                        #endregion
                        #region 前二
                        case 76://前二直选复式
                            bet = a * b;
                            break;
                        case 77://前二直选单式

                            break;
                        case 78://前二直选和值
                            foreach (var item in tList[0])
                            {
                                bet += bet_zxhz(2, Convert.ToInt32(item));
                            }
                            break;
                        case 79://前二直选跨度
                            foreach (var item in tList[0])
                            {
                                bet += bet_zxkd(2, Convert.ToInt32(item));
                            }
                            break;
                        case 80://前二组选复式
                            bet = MyTool.CalculateCombination(2, a);
                            break;
                        case 81://前二组选单式

                            break;
                        case 82://前二组选和值
                            foreach (var item in tList[0])
                            {
                                bet += bet_zuxhz(2, Convert.ToInt32(item));
                            }
                            break;
                        case 83://前二组选包胆
                            bet = 9;
                            break;
                        #endregion
                        #region 不定位
                        case 84://后三一码
                        case 85://前三一码
                            bet = BetCalculateTool.CalculateN(tList);
                            break;
                        case 86://后三二码
                        case 87://前三二码
                            bet = MyTool.CalculateCombination(2, a);
                            break;
                        case 88://四星一码
                            bet = BetCalculateTool.CalculateN(tList);
                            break;
                        case 89://四星二码
                        case 90://五星二码
                            bet = MyTool.CalculateCombination(2, a);
                            break;
                        case 91://五星三码
                            bet = MyTool.CalculateCombination(3, a);
                            break;
                        #endregion
                        #region 大(6)小(5)单(1)双(0)
                        case 92://前二大小单双
                        case 93://后二大小单双
                            bet = a * b;
                            break;
                        case 94://前三大小单双
                        case 95://后三大小单双
                            bet = a * b * c;
                            break;
                        #endregion
                        #region 任选二
                        case 96://任选二直选复式
                            bet = a * (b + c + d + e) + b * (c + d + e) + c * (d + e) + d * e;
                            break;
                        case 97://任选二直选单式
                            break;
                        case 98://任选二直选和值
                            foreach (var item in tList[0])
                            {
                                bet += bet_zxhz(2, Convert.ToInt32(item));
                            }
                            bet *= MyTool.CalculateCombination(2, wzList.Count);//乘以c(2,勾选项数)
                            break;
                        case 99://任选二组选复式
                            bet = MyTool.CalculateCombination(2, tList[0].Count) * MyTool.CalculateCombination(2, wzList.Count);
                            break;
                        case 100://任选二组选单式

                            break;
                        case 101://任选二组选和值
                            foreach (var item in tList[0])
                            {
                                bet += bet_zuxhz(2, Convert.ToInt32(item));
                            }
                            bet *= MyTool.CalculateCombination(2, wzList.Count);
                            break;
                        #endregion
                        #region 任选三
                        case 102://任选三直选复式
                            bet = a * b * (c + d + e) + a * c * (d + e) + a * d * e + b * c * (d + e) + b * d * e + c * d * e;
                            break;
                        case 103://任选三直选单式
                            break;
                        case 104://任选三直选和值
                            foreach (var item in tList[0])
                            {
                                bet += bet_zxhz(3, Convert.ToInt32(item));
                            }
                            bet *= MyTool.CalculateCombination(3, wzList.Count);
                            break;
                        case 105://任选三组三复式
                            bet = a * (a - 1) * MyTool.CalculateCombination(3, wzList.Count);
                            break;
                        case 106://任选三组三单式
                            break;
                        case 107://任选三组六复式
                            bet = MyTool.CalculateCombination(3, tList[0].Count) * MyTool.CalculateCombination(3, wzList.Count);
                            break;
                        case 108://任选三组六单式
                            break;
                        case 109://任选三混合组选
                            break;
                        case 110://任选三组选和值
                            foreach (var item in tList[0])
                            {
                                bet += bet_zuxhz(3, Convert.ToInt32(item));
                            }
                            bet *= MyTool.CalculateCombination(3, wzList.Count);
                            break;
                        #endregion
                        #region 任选四
                        case 111://任选四直选复式
                            bet = a * b * c * (d + e) + a * d * e * (b + c) + b * c * d * e;
                            break;
                        case 112://任选四直选单式
                            break;
                        case 113://任选四组选24
                            bet = MyTool.CalculateCombination(4, tList.Sum(w => w.Count));
                            bet *= MyTool.CalculateCombination(4, wzList.Count);
                            break;
                        case 114://任选四组选12
                            bet = (n - x) * MyTool.CalculateCombination(2, m) + x * MyTool.CalculateCombination(2, m - 1);
                            bet *= MyTool.CalculateCombination(4, wzList.Count);
                            break;
                        case 115://任选四组选6
                            bet = MyTool.CalculateCombination(2, tList.Sum(w => w.Count));
                            bet *= MyTool.CalculateCombination(4, wzList.Count);
                            break;
                        case 116://任选四组选4
                            bet = (n - x) * MyTool.CalculateCombination(1, m) + x * MyTool.CalculateCombination(1, m - 1);
                            bet *= MyTool.CalculateCombination(4, wzList.Count);
                            break;
                        #endregion
                    }
                    break;
                #endregion
                #region 11X5
                case "11x5":
                    if (LotteryOpenTool_11x5.LpList().FirstOrDefault(i => i.BetPlayTypeCode == playId).LotteryPlayName.Contains("单式"))
                    {
                        betUnit = betNum.Trim().Split('|').Count();
                        return betUnit;
                    }
                    if (betNum.IndexOf('|') > -1)
                    {
                        tList = betNum.Split('|').Select(
                                i => i.Split(' ').ToList()
                                ).ToList();
                    }
                    else
                    {
                        tList.Add(betNum.Split(' ').ToList());
                    }
                    switch (LotteryOpenTool_11x5.LpList().FirstOrDefault(q => q.BetPlayTypeCode == playId).LotteryPlayName)
                    {
                        case "前三直选复式":
                        case "前二直选复式":
                            bet = BetCalculateTool.CalculateNoRepeatBet(tList);
                            break;
                        case "前三直选单式":
                            break;
                        case "前三组选复式":
                            bet = MyTool.CalculateCombination(3, tList[0].Count);
                            break;
                        case "前三组选单式":
                            break;
                        case "前三组选胆拖":
                            bet = getDT(3, tList); ;
                            break;
                        case "前二组选复式":
                            bet = MyTool.CalculateCombination(2, tList[0].Count);
                            break;
                        case "前二组选胆拖":
                            bet = getDT(2, tList); ;
                            break;
                        case "不定位":
                        case "定位胆":
                        case "趣味定_单双":
                        case "趣味猜_中位":
                            bet = BetCalculateTool.CalculateN(tList);
                            break;
                        case "胆拖任选二中二":
                            bet = getDT(2, tList);
                            break;
                        case "胆拖任选三中三":
                            bet = getDT(3, tList);
                            break;
                        case "胆拖任选四中四":
                            bet = getDT(4, tList);
                            break;
                        case "胆拖任选五中五":
                            bet = getDT(5, tList);
                            break;
                        case "胆拖任选六中五":
                            bet = getDT(6, tList);
                            break;
                        case "胆拖任选七中五":
                            bet = getDT(7, tList);
                            break;
                        case "胆拖任选八中五":
                            bet = getDT(8, tList);
                            break;
                        case "任选一中一":
                            bet = MyTool.CalculateCombination(1, tList[0].Count);
                            break;
                        case "任选二中二":
                            bet = MyTool.CalculateCombination(2, tList[0].Count);
                            break;
                        case "任选三中三":
                            bet = MyTool.CalculateCombination(3, tList[0].Count);
                            break;
                        case "任选四中四":
                            bet = MyTool.CalculateCombination(4, tList[0].Count);
                            break;
                        case "任选五中五":
                            bet = MyTool.CalculateCombination(5, tList[0].Count);
                            break;
                        case "任选六中五":
                            bet = MyTool.CalculateCombination(6, tList[0].Count);
                            break;
                        case "任选七中五":
                            bet = MyTool.CalculateCombination(7, tList[0].Count);
                            break;
                        case "任选八中五":
                            bet = MyTool.CalculateCombination(8, tList[0].Count);
                            break;
                    }
                    break;
                #endregion
                case "dpc":
                    break;
            }
            return bet;

        }
        #region 时时彩算法
        static int[] NumListSSC = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        /// <summary>
        /// 直选和值
        /// </summary>
        /// <returns></returns>
        static int bet_zxhz(int ws, int hezhi)
        {
            int zhu = 0;
            if (ws == 3)
            {
                var query = from a in NumListSSC
                            from b in NumListSSC
                            from c in NumListSSC
                            select new { a, b, c };
                zhu = query.Count(item => item.a + item.b + item.c == hezhi);
            }
            else
            {
                var query = from a in NumListSSC
                            from b in NumListSSC
                            select new { a, b };
                zhu = query.Count(item => item.a + item.b == hezhi);
            }
            return zhu;
        }
        /// <summary>
        /// 直选跨度
        /// </summary>
        /// <returns></returns>
        static int bet_zxkd(int ws, int kuazhi)
        {
            int zhu = 0;
            if (ws == 3)
            {
                var query = from a in NumListSSC
                            from b in NumListSSC
                            from c in NumListSSC
                            select new { a, b, c };
                foreach (var item in query)
                {
                    int[] l = { item.a, item.b, item.c };
                    l = l.OrderBy(n => n).ToArray();
                    if (l[2] - l[0] == kuazhi)
                    {
                        zhu++;
                    }
                }
            }
            else
            {
                var query = from a in NumListSSC
                            from b in NumListSSC
                            select new { a, b };
                zhu = query.Count(item => Math.Abs(item.a - item.b) == kuazhi);
            }
            return zhu;
        }
        static int[] zuxhzArray = { 1, 2, 2, 4, 5, 6, 8, 10, 11, 13, 14, 14, 15 };
        /// <summary>
        /// 组选和值
        /// </summary>
        /// <returns></returns>
        static int bet_zuxhz(int ws, int hezhi)
        {
            int zhu = 0;
            List<int> list = new List<int>();
            if (ws == 3)
            {
                if (hezhi < 14)
                {
                    zhu = zuxhzArray[hezhi - 1];
                }
                else
                {
                    zhu = zuxhzArray[27 - hezhi - 1];
                }
            }
            else
            {
                var query = from a in NumListSSC
                            from b in NumListSSC
                            where a != b
                            select new { a, b };
                zhu = query.Count(item => item.a + item.b == hezhi) / 2;
            }
            return zhu;
        }
        #endregion
        #region 11选5算法
        /// <summary>
        /// 选X中Y胆拖算法
        /// </summary>
        /// <returns></returns>
        static int getDT(int x, List<List<string>> tList)
        {
            var query = from a in tList[0]
                        from b in tList[1]
                        where a == b
                        select a;
            if (query.Count() > 0)
            {
                return -1;
            }
            if (tList[0].Count * tList[1].Count == 0)
            {
                return 0;
            }
            var n = x - tList[0].Count;
            var m = tList[1].Count;
            return MyTool.CalculateCombination(n, m);
        }
        #endregion 
        #endregion
        //public static string ToMD5(string source)
        //{
        //    source = "A1.@a%2DFA"+source;
        //    byte[] bytes = Encoding.UTF8.GetBytes(source);
        //    MD5 mD = MD5.Create();
        //    byte[] array = mD.ComputeHash(bytes);
        //    StringBuilder stringBuilder = new StringBuilder(40);
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        stringBuilder.Append(array[i].ToString("x2"));
        //    }
        //    return stringBuilder.ToString();
        //}
        public static string ToMD5(string str) 
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile("A1.@a%2DFA" + str, "MD5");
        }
        public static string GetJm()
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile("A1.@a%2DFA" + DateTime.Now.Date.Ticks, "MD5");
        }
        public static Dictionary<string, string> GetJmDic() 
        {
            var dt = DateTime.Now.Date.AddDays(1);//明天
            var key = dt.Ticks.ToString();
            if (!JmDic.ContainsKey(key))
            {
                if (JmDic.Count == 3)
                {
                    JmDic.Clear();
                }
                JmDic.Add(key, ToMD5(key));
                key = dt.AddDays(-1).Ticks.ToString();//今天
                JmDic.Add(key, ToMD5(key));
                key = dt.AddDays(-2).Ticks.ToString();//昨天
                JmDic.Add(key, ToMD5(key));
            }
            return JmDic;
        }
    }
}