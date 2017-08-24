using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace LotteryModel
{
    public class MyTool
    {
        /// <summary>
        /// 字符串补0
        /// </summary>
        /// <param name="no"></param>
        /// <param name="length">需要长度</param>
        /// <returns></returns>
        public static string AddZeroStr(object no, int length)
        {
            StringBuilder sb = new StringBuilder();
            var noStr = no.ToString();
            for (int i = 0; i < length - noStr.Length; i++)
            {
                sb.Append("0");
            }
            return sb.ToString() + noStr;
        }
        /// <summary>
        /// 开奖号补0
        /// </summary>
        public static string AddZeroStr(string openNum)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in openNum.Split(','))
            {
                sb.Append(AddZeroStr(item, 2) + ',');
            }
            return sb.Remove(sb.Length - 1, 1).ToString();
        }
        /// <summary>
        /// 转换单双投注文本
        /// </summary>
        /// <param name="betNum"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetBet_ZH_11X5(string betNum, int code)
        {
            switch (code)
            {
                case 13://趣味定_单双
                    StringBuilder str = new StringBuilder(); ;
                    foreach (var item in betNum.Split(' '))
                    {
                        var i = Convert.ToInt32(item);
                        str.Append(string.Format("{0}单{1}双 ", i, 5 - i));
                    }
                    return str.ToString();
                default:
                    return betNum;
            }
        }
        #region 组合计算
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
        public static int CalculateCombination(int n, int m)
        {
            if (n <= 0||m<=0) return 0;
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
        #endregion

        static List<CboItem> AccountBusinessTypeItems;
        public static List<CboItem> GetAccountBusinessTypeItems()
        {
            if (AccountBusinessTypeItems == null)
            {
                AccountBusinessTypeItems = new List<CboItem>();
                AccountBusinessTypeItems.Add(new CboItem { Id = 0, Name = "全部" });
                AccountBusinessTypeItems.Add(new CboItem { Id = (int)Enum_AccountBusinessType.Bet, Name = "投注扣款" });
                AccountBusinessTypeItems.Add(new CboItem { Id = (int)Enum_AccountBusinessType.Win, Name = "奖金派发" });
                AccountBusinessTypeItems.Add(new CboItem { Id = (int)Enum_AccountBusinessType.BackPercent, Name = "游戏返点" });
            }
            return AccountBusinessTypeItems;
        }
        public static List<LotteryPlay> GetLotteryPlayList(string LotteryType) 
        {
            List<LotteryPlay> list = new List<LotteryPlay>();
            switch (LotteryType)
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
            return list;
        }
        static List<CboItem> LotteryItems;
        public static List<CboItem> GetLotteryItems()
        {
            if (LotteryItems == null)
            {
                LotteryItems = new List<CboItem>();
                LotteryItems.Add(new CboItem { Id = 0, Name = "全部" });
                foreach (var item in EntitiesTool.GetLotteryDic())
                {
                    LotteryItems.Add(new CboItem { Id = item.Value.Id, Name = item.Value.LotteryName }); 
                }
            }
            return LotteryItems;
        }

        #region 特殊玩法转换
        static Dictionary<string, int> BetNum_TSH;
        public static string ChangeBetNumTSH(string betNum)
        {
            if (BetNum_TSH == null)
            {
                BetNum_TSH = new Dictionary<string, int>();
                #region 时时彩
                BetNum_TSH.Add("4条", 5);
                BetNum_TSH.Add("3条", 20);
                BetNum_TSH.Add("3带2", 10);
                BetNum_TSH.Add("两对", 30);
                BetNum_TSH.Add("一对", 60);
                BetNum_TSH.Add("全不同", 120);
                BetNum_TSH.Add("顺子号", 120);
                BetNum_TSH.Add("全单", 5);
                BetNum_TSH.Add("全双", 0);
                BetNum_TSH.Add("4单1双", 4);
                BetNum_TSH.Add("1单4双", 1);
                BetNum_TSH.Add("3单2双", 3);
                BetNum_TSH.Add("2单3双", 2);
                BetNum_TSH.Add("全大", 5);
                BetNum_TSH.Add("全小", 0);
                BetNum_TSH.Add("4大1小", 4);
                BetNum_TSH.Add("1大4小", 1);
                BetNum_TSH.Add("3大2小", 3);
                BetNum_TSH.Add("2大3小", 2);
                BetNum_TSH.Add("豹子", 3);
                BetNum_TSH.Add("顺子", 1);
                BetNum_TSH.Add("对子", 2);
                BetNum_TSH.Add("大", 6);
                BetNum_TSH.Add("小", 5);
                BetNum_TSH.Add("单", 1);
                BetNum_TSH.Add("双", 0);
                #endregion
                #region 十一选五
                BetNum_TSH.Add("5单0双", 5);
                BetNum_TSH.Add("0单5双", 0);
                #endregion
            }
            var betNumNew = new StringBuilder();
            foreach (var l1 in betNum.Split('|'))
            {
                foreach (var item in l1.Split(' '))
                {
                    if (BetNum_TSH.ContainsKey(item))
                    {
                        betNumNew.Append(BetNum_TSH[item]);
                    }
                    else
                    {
                        betNumNew.Append(item);
                    }
                    betNumNew.Append(' ');
                }
                betNumNew.Remove(betNumNew.Length - 1, 1);
                betNumNew.Append('|');
            }
            betNumNew.Remove(betNumNew.Length - 1, 1);
            return betNumNew.ToString();
        }
        #endregion
    }

    public class CboItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
