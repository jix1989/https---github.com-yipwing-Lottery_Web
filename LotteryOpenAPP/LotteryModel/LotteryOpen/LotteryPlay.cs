using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotteryModel
{
    public class LotteryPlay
    {
        /// <summary>
        /// 代码id
        /// </summary>
        public int BetPlayTypeCode { get; set; }
        /// <summary>
        /// 玩法
        /// </summary>
        public string LotteryPlayName { get; set; }
        /// <summary>
        /// 奖级
        /// </summary>
        public Dictionary<int, decimal> PrizeClass { get; set; }
        /// <summary>
        /// 返奖金额
        /// </summary>
        public decimal PayBack { get; set; }
    }
    /// <summary>
    /// 组选类别
    /// </summary>
    public class ZXLB
    {
        public int NumType { get; set; }
        public int NumValue { get; set; }
    }

    public class LotteryPlayArithmetic
    {
        #region 通用算法
        /// <summary>
        /// 判断组选类别
        /// </summary>
        public static int pd(List<int> openCode,out List<ZXLB> list)
        {
            list = new List<ZXLB>();
            for (int i = 0; i < openCode.Count; i++)
            {
                list.Add(new ZXLB { NumType = openCode.Count(n => n == openCode[i]), NumValue = openCode[i] });
            }
            switch (openCode.Count)
            {
                case 5:
                    switch (list.Sum(n => n.NumType))
                    {
                        case 5: return 120;//单号
                        case 7: return 60;//一对
                        case 9: return 30;//两对
                        case 11: return 20;//三条
                        case 13: return 10;//三带二
                        case 17: return 5;//四条
                        case 25: return 0;//五条
                    }
                    break;
                case 4:
                    switch (list.Sum(n => n.NumType))
                    {
                        case 4: return 24;//单号
                        case 6: return 12;//一对
                        case 8: return 6;//两对
                        case 10: return 4;//三条
                    }
                    break;
                case 3:
                    switch (list.Sum(n => n.NumType))
                    {
                        case 3: return 6;//单号
                        case 5: return 3;//对子
                        case 9: return 0;//豹子
                    }
                    break;
                case 2:
                    return list.Sum(n => n.NumType) / 2;//1:11单号,2:22同号
            }
            return -1;
        }
        /// <summary>
        /// 判断大小单双
        /// </summary>
        public static bool pd_dxds(int code, List<int> bet)
        {
            var r1 = code < 6 ? 5 : 6;//小，大
            var r2 = code % 2 == 0 ? 0 : 1;//单，双
            return bet.Exists(n => n == r1 || n == r2);
        }
        /// <summary>
        /// 组选复式
        /// </summary>
        public static int zxfs(List<List<int>> b1, List<ZXLB> zxlbList, int zxlb, int zhongCount, List<int> openCode)
        {
            if (pd(openCode,out zxlbList) == zxlb)
            {
                return (from a in b1[0]
                        from b in zxlbList
                        where a == b.NumValue
                        select a).Count() >= zhongCount ? 1 : 0;
            }
            return 0;
        }
        /// <summary>
        /// 组选单式
        /// </summary>
        public static int zxds(string betNum, List<ZXLB> zxlbList, int zxlb, List<int> openCode)
        {
            if (pd(openCode, out zxlbList) == zxlb)
            {
                var str = "";
                foreach (var item in openCode.OrderBy(n => n))
                {
                    str += item;
                }
                return betNum.Contains(str) ? 1 : 0;
            }
            return 0;
        }
        /// <summary>
        /// 后三混合组选
        /// </summary>
        public static void hshhzx(int BetPlayTypeCode, string betNum, List<ZXLB> zxlbList, out int winTimes, out decimal BackMoney, List<int> openCode)
        {
            winTimes = 0; BackMoney = 0; var lb = LotteryPlayArithmetic.pd(openCode, out zxlbList);
            if (lb > 0)
            {
                var str = "";
                foreach (var item in openCode.OrderBy(n => n))
                {
                    str += item;
                }
                winTimes = betNum.Contains(str) ? 1 : 0;
                BackMoney = winTimes * LotteryInfo_SSC.LpList()[BetPlayTypeCode - 1].PrizeClass[lb];
            }
        }
        /// <summary>
        /// 后三组选和值
        /// </summary>
        public static void hszxhz(int BetPlayTypeCode, List<List<int>> b1, List<ZXLB> zxlbList, out int winTimes, out decimal BackMoney, List<int> openCode)
        {
            winTimes = 0; BackMoney = 0; var lb = LotteryPlayArithmetic.pd(openCode, out zxlbList);
            if (lb > 0)
            {
                winTimes = b1[0].Contains(openCode[0] + openCode[1] + openCode[2]) ? 1 : 0;
                BackMoney = winTimes * LotteryInfo_SSC.LpList()[BetPlayTypeCode - 1].PrizeClass[lb];
            }
        }
        #endregion
        #region 不定位
        /// <summary>
        /// 不定位
        /// </summary>
        /// <returns></returns>
        public static int bdw(List<List<int>> b1, int zhongCount, List<int> openCode)
        {
            return (from a in b1[0]
                    from b in openCode
                    where a == b
                    select a).Count() >= zhongCount ? 1 : 0;
        }
        #endregion
    }
    //public class LotteryPlay
    //{
    //    /// <summary>
    //    /// 玩法
    //    /// </summary>
    //    public string LotteryPlayName { get; set; }
    //    /// <summary>
    //    /// 代码id
    //    /// </summary>
    //    public int BetPlayTypeCode { get; set; }
    //    /// <summary>
    //    /// 奖级
    //    /// </summary>
    //    public int? SpecialValue { get; set; }
    //    /// <summary>
    //    /// 返奖金额
    //    /// </summary>
    //    public decimal PayBack { get; set; }
    //}
}
