using LotteryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotteryGameApp
{
    public class BetCalculateTools
    {
        public static int GetBetUnit_11x5(int PlayId,string BetNum) 
        {
            var bet = 0;
            var tList =new List<string[]>();
            foreach (var item in BetNum.Split('|'))
            {
                if (item.Length == 0)
                {
                    tList.Add(null);
                }
                else 
                {
                    tList.Add(item.Split(' '));
                }
            }
            switch (PlayId)
            {
                case 1://"前三直选复式":
                case 6://"前二直选复式":
                    bet = CalculateNoRepeatBet(tList);
                    break;
                case 2://"前三直选单式":
                    bet = tList.Count();
                    break;
                case 3://"前三组选复式":
                    bet = CalculateCombination(3, tList[0].Length);
                    break;
                case 4://"前三组选单式":
                    bet = tList.Count();
                    break;
                case 5://"前三组选胆拖":
                    bet = GetDT(3,tList);
                    break;
                case 7:// 前二直选单式
                    bet = tList.Count();
                    break;
                case 8://"前二组选复式":
                    bet = CalculateCombination(2, tList[0].Length);
                    break;
                case 9://前二组选单式
                    bet = tList.Count();
                    break;
                case 10://"前二组选胆拖":
                    bet = GetDT(2, tList);
                    break;
                case 11://"不定位":
                case 12://"定位胆":
                case 13://"趣味定_单双":
                case 14://"趣味猜_中位":
                    bet = CalculateN(tList);
                    break;
                case 15://"任选一中一":
                    bet = CalculateCombination(1, tList[0].Length);
                    break;
                case 16://"任选二中二":
                    bet = CalculateCombination(2, tList[0].Length);
                    break;
                case 17://"任选三中三":
                    bet = CalculateCombination(3, tList[0].Length);
                    break;
                case 18://"任选四中四":
                    bet = CalculateCombination(4, tList[0].Length);
                    break;
                case 19://"任选五中五":
                    bet = CalculateCombination(5, tList[0].Length);
                    break;
                case 20://"任选六中五":
                    bet = CalculateCombination(6, tList[0].Length);
                    break;
                case 21://"任选七中五":
                    bet = CalculateCombination(7, tList[0].Length);
                    break;
                case 22://"任选八中五":
                    bet = CalculateCombination(8, tList[0].Length);
                    break;
                case 23://"单式任选一中一":
                    bet = tList.Count();
                    break;
                case 24://"单式任选二中二":
                    bet = tList.Count();
                    break;
                case 25://"单式任选三中三":
                    bet = tList.Count();
                    break;
                case 26://"单式任选四中四":
                    bet = tList.Count();
                    break;
                case 27://"单式任选五中五":
                    bet = tList.Count();
                    break;
                case 28://"单式任选六中五":
                    bet = tList.Count();
                    break;
                case 29://"单式任选七中五":
                    bet = tList.Count();
                    break;
                case 30://"单式任选八中五":
                    bet = tList.Count();
                    break;
                case 31://"胆拖任选二中二":
                    bet = GetDT(2, tList);
                    break;
                case 32://"胆拖任选三中三":
                    bet = GetDT(3, tList);
                    break;
                case 33://"胆拖任选四中四":
                    bet = GetDT(4, tList);
                    break;
                case 34://"胆拖任选五中五":
                    bet = GetDT(5, tList);
                    break;
                case 35://"胆拖任选六中五":
                    bet = GetDT(6, tList);
                    break;
                case 36://"胆拖任选七中五":
                    bet = GetDT(7, tList);
                    break;
                case 37://"胆拖任选八中五":
                    bet = GetDT(8, tList);
                    break;
            }
            return bet;
        }

        /// <summary>
        /// 时时彩算法
        /// </summary>
        /// <param name="WzStr">任选玩法选号位置:选万，千，百，十，个 传0,1,2,3,4</param>
        /// <returns></returns>
        public static int GetBetUnit_SSC(int PlayId,string BetNum,string WzStr) 
        {
            var bet = 0;
            var tList = new List<string[]>();
            foreach (var item in BetNum.Split('|'))
            {
                if (item.Length == 0)
                {
                    tList.Add(null);
                }
                else
                {
                    tList.Add(item.Split(' '));
                }
            }
            var wzList = WzStr.Split(',');
            var n = tList.Count > 0 ? tList[0].Length : 0;
            var m = tList.Count > 1 ? tList[1].Length : 0;
            var x = tList.Count > 1 ? tList[1].Count(w => tList[0].Contains(w)) : 0;
            var a = tList[0].Length;
            var b = tList.Count > 1 ? tList[1].Length : 0;
            var c = tList.Count > 2 ? tList[2].Length : 0;
            var d = tList.Count > 3 ? tList[3].Length : 0;
            var e = tList.Count > 4 ? tList[4].Length : 0;
            switch (PlayId)
            {
                #region 定位胆
                case 1://定位胆
                    bet = CalculateN(tList);
                    break;
                #endregion
                #region 五星
                case 2://五星直选复式
                    bet = a * b * c * d * e;
                    break;
                case 3://五星直选单式
                    bet = tList.Count;
                    break;
                case 4://五星直选组合
                    bet = a * b * c * d * e * 5;
                    break;
                case 5://五星组选120(全不同号)
                    bet = CalculateCombination(5, tList.Sum(w => w.Length));
                    break;
                case 6://五星组选60(一对)
                    bet = (n - x) * CalculateCombination(3, m) + x * CalculateCombination(3, m - 1);
                    break;
                case 7://五星组选30(两对)
                    bet = (m - x) * CalculateCombination(2, n) + x * CalculateCombination(2, n - 1);
                    break;
                case 8://五星组选20(三条)
                    bet = (n - x) * CalculateCombination(2, m) + x * CalculateCombination(2, m - 1);
                    break;
                case 9://五星组选10(三带二)
                //bet = (n-x)*c(1,m)+x*C(1,m-1)
                //break;
                case 10://五星组选5(四条)
                    bet = (n - x) * CalculateCombination(1, m) + x * CalculateCombination(1, m - 1);
                    break;
                case 11://五星一帆风顺
                case 12://五星好事成双
                case 13://五星三星报喜
                case 14://五星四季发财
                    bet = CalculateN(tList);
                    break;
                #endregion
                #region 四星
                case 15://四星直选复式
                    bet = a * b * c * d;
                    break;
                case 16://四星直选单式
                    bet = tList.Count;
                    break;
                case 17://四星直选组合
                    bet = a * b * c * d * 4;
                    break;
                case 18://四星组选24(全不同号)
                    bet = CalculateCombination(4, tList.Sum(w => w.Length));
                    break;
                case 19://四星组选12(一对)
                    bet = (n - x) * CalculateCombination(2, m) + x * CalculateCombination(2, m - 1);
                    break;
                case 20://四星组选6(两对)
                    bet = CalculateCombination(2, tList.Sum(w => w.Length));
                    break;
                case 21://四星组选4(三条)
                    bet = (n - x) * CalculateCombination(1, m) + x * CalculateCombination(1, m - 1);
                    break;
                #endregion
                #region 百家
                case 22://百家重复号
                case 23://百家顺子号
                case 24://百家单双号
                case 25://百家大小号
                    bet = CalculateN(tList);
                    break;
                #endregion
                #region 后三
                case 26://后三直选复式
                    bet = a * b * c;
                    break;
                case 27://后三直选单式
                    bet = tList.Count;
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
                    bet = CalculateCombination(3, a);
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
                    bet = CalculateN(tList);
                    break;
                #endregion
                #region 中三
                case 40://中三直选复式
                    bet = a * b * c;
                    break;
                case 41://中三直选单式
                    bet = tList.Count;
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
                    bet = CalculateCombination(3, a);
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
                    bet = CalculateN(tList);
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
                    bet = CalculateCombination(3, a);
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
                    bet = CalculateN(tList);
                    break;
                #endregion
                #region 后二
                case 68://后二直选复式
                    bet = a * b;
                    break;
                case 69://后二直选单式
                    bet = tList.Count();
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
                    bet = CalculateCombination(2, a);
                    break;
                case 73://后二组选单式
                    bet = tList.Count();
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
                    bet = tList.Count();
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
                    bet = CalculateCombination(2, a);
                    break;
                case 81://前二组选单式
                    bet = tList.Count();
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
                    bet = CalculateN(tList);
                    break;
                case 86://后三二码
                case 87://前三二码
                    bet = CalculateCombination(2, a);
                    break;
                case 88://四星一码
                    bet = CalculateN(tList);
                    break;
                case 89://四星二码
                case 90://五星二码
                    bet = CalculateCombination(2, a);
                    break;
                case 91://五星三码
                    bet = CalculateCombination(3, a);
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
                    bet = tList.Count() * CalculateCombination(2, wzList.Length);
                    break;
                case 98://任选二直选和值
                    foreach (var item in tList[0])
                    {
                        bet += bet_zxhz(2, Convert.ToInt32(item));
                    }
                    bet *= CalculateCombination(2, wzList.Length);//乘以c(2,勾选项数)
                    break;
                case 99://任选二组选复式
                    bet = CalculateCombination(2, tList[0].Length) * CalculateCombination(2, wzList.Length);
                    break;
                case 100://任选二组选单式
                    bet = tList.Count() * CalculateCombination(2, wzList.Length);
                    break;
                case 101://任选二组选和值
                    foreach (var item in tList[0])
                    {
                        bet += bet_zuxhz(2, Convert.ToInt32(item));
                    }
                    bet *= CalculateCombination(2, wzList.Length);
                    break;
                #endregion
                #region 任选三
                case 102://任选三直选复式
                    bet = a * b * (c + d + e) + a * c * (d + e) + a * d * e + b * c * (d + e) + b * d * e + c * d * e;
                    break;
                case 103://任选三直选单式
                    bet = tList.Count() * CalculateCombination(3, wzList.Length);
                    break;
                case 104://任选三直选和值
                    foreach (var item in tList[0])
                    {
                        bet += bet_zxhz(3, Convert.ToInt32(item));
                    }
                    bet *= CalculateCombination(3, wzList.Length);
                    break;
                case 105://任选三组三复式
                    bet = a * (a - 1) * CalculateCombination(3, wzList.Length);
                    break;
                case 106://任选三组三单式
                    bet = tList.Count() * CalculateCombination(3, wzList.Length);
                    break;
                case 107://任选三组六复式
                    bet = CalculateCombination(3, tList[0].Length) * CalculateCombination(3, wzList.Length);
                    break;
                case 108://任选三组六单式
                    bet = tList.Count() * CalculateCombination(3, wzList.Length);
                    break;
                case 109://任选三混合组选
                    break;
                case 110://任选三组选和值
                    foreach (var item in tList[0])
                    {
                        bet += bet_zuxhz(3, Convert.ToInt32(item));
                    }
                    bet *= CalculateCombination(3, wzList.Length);
                    break;
                #endregion
                #region 任选四
                case 111://任选四直选复式
                    bet = a * b * c * (d + e) + a * d * e * (b + c) + b * c * d * e;
                    break;
                case 112://任选四直选单式
                    bet = tList.Count() * CalculateCombination(4, wzList.Length);
                    break;
                case 113://任选四组选24
                    bet = CalculateCombination(4, tList.Sum(w => w.Length));
                    bet *= CalculateCombination(4, wzList.Length);
                    break;
                case 114://任选四组选12
                    bet = (n - x) * CalculateCombination(2, m) + x * CalculateCombination(2, m - 1);
                    bet *= CalculateCombination(4, wzList.Length);
                    break;
                case 115://任选四组选6
                    bet = CalculateCombination(2, tList.Sum(w => w.Length));
                    bet *= CalculateCombination(4, wzList.Length);
                    break;
                case 116://任选四组选4
                    bet = (n - x) * CalculateCombination(1, m) + x * CalculateCombination(1, m - 1);
                    bet *= CalculateCombination(4, wzList.Length);
                    break;
                #endregion
            }
            return bet;
        }

        static int CalculateNoRepeatBet(List<string[]> list)
        {
            int bet = 0;
            switch (list.Count)
            {
                case 2:
                    bet = (from _0 in list[0]
                           from _1 in list[1]
                           where _0 != _1
                           select _1).Count();
                    break;
                case 3:
                    bet = (from _0 in list[0]
                           from _1 in list[1]
                           from _2 in list[2]
                           where _0 != _1
                           && _0 != _2 && _1 != _2//C(2,3)=3
                           select _1).Count();
                    break;
                case 4:
                    bet = (from _0 in list[0]
                           from _1 in list[1]
                           from _2 in list[2]
                           from _3 in list[3]
                           where _0 != _1
                           && _0 != _2 && _1 != _2
                           && _0 != _3 && _1 != _3 && _2 != _3//C(2,4)=6
                           select _1).Count();
                    break;
                case 5:
                    bet = (from _0 in list[0]
                           from _1 in list[1]
                           from _2 in list[2]
                           from _3 in list[3]
                           from _4 in list[4]
                           where _0 != _1
                           && _0 != _2 && _1 != _2
                           && _0 != _3 && _1 != _3 && _2 != _3
                           && _0 != _4 && _1 != _4 && _2 != _4 && _3 != _4//C(2,5)=10
                           select _1).Count();
                    break;
            }
            return bet;
        }
        /// <summary>
        /// 组合计算字典
        /// </summary>
        static Dictionary<string, int> ccDic = new Dictionary<string, int>();
        /// <summary>
        /// 组合运算C(n,m)
        /// </summary>
        /// <param name="n">选择数</param>
        /// <param name="m">总数</param>
        /// <returns></returns>
        static int CalculateCombination(int n, int m)
        {
            if (n <= 0 || m <= 0) return 0;
            if (n == m) return 1;
            var c = n + "," + m;
            if (!ccDic.Keys.Contains(c)) //不存在则计算结果后储存字典
            {
                int r1 = m;
                int r2 = n;
                for (int i = 1; i < n; i++)
                {
                    r1 *= m - i;
                    r2 *= n - i;
                }
                ccDic.Add(c, r1 / r2);
            }
            return ccDic[c];
        }
        /// <summary>
        /// 选择n个即n注
        /// </summary>
        /// <param name="Count"></param>
        /// <returns></returns>
        static int CalculateN(List<string[]> list)
        {
            return list.Sum(n => n.Count(w => w.Length > 0));
        }
        /// <summary>
        /// 选X中Y胆拖算法
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        static int GetDT(int x,List<string[]> tList)
        {
            if (tList[0].Length * tList[1].Length == 0)
            {
                return 0;
            }
            var n = x - tList[0].Length;
            var m = tList[1].Length;
            return CalculateCombination(n, m);
        }
        #region 时时彩
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
    }
}
