using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotteryModel
{
    public static class BetCalculateTool
    {
        public static List<BetModel> AllBetList = new List<BetModel>();
        /// <summary>
        /// 选择n个即n注
        /// </summary>
        /// <param name="Count"></param>
        /// <returns></returns>
        public static int CalculateN(List<List<string>> list) 
        {
            //int Count = 0;
            //foreach (var item in list)
            //{
            //    Count += item.Count;
            //}
            //return Count;
            return list.Sum(n => n.Count(w=>w.Length>0));
        }
        /// <summary>
        /// 选择n个即n注
        /// </summary>
        /// <param name="Count"></param>
        /// <returns></returns>
        public static int CalculateN_DWD(List<List<string>> list)
        {
            int Count = 0;
            foreach (var item in list)
            {
                Count += item.Count;
            }
            return Count;
        }
        /// <summary>
        /// 非重复组合计算(例:十一选五 三码)
        /// </summary>
        /// <param name="choiceList"></param>
        /// <returns></returns>
        public static int CalculateNoRepeatBet(params string[][] list)
        {
            int bet = list.Length;
            switch (list.Length)
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

        public static int CalculateNoRepeatBet(List<List<string>> list)
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
        /// 将每行选号集合拼接为字符串
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string GetBetNo(params List<string>[] list) 
        {
            StringBuilder No = new StringBuilder();
            foreach (var item in list)
            {
                foreach (var i in item.OrderBy(n=>n))
                {
                    No.Append(i+' ');
                }
                No.Length -= 1;
                No.Append('|');
            }
            No.Length -= 1;
            return No.ToString();
        }

        public static int GetTotalBet(List<List<string>> list,string lpCode) 
        {
            int bet = 0;
            if (lpCode.Contains("组选"))
            {

            }
            else 
            {
                bet = CalculateNoRepeatBet(list);
            }
            return bet;
        }

        public static string GetTotalMoney(int betTotal,int bs,int cboIndex)
        {
            decimal money = 2 * betTotal * bs;
            switch (cboIndex)
            {
                case 1:
                    money = money / 10;
                    break;
                case 2:
                    money = money / 100;
                    break;
                case 3:
                    money = money / 1000;
                    break;
            }
            return string.Format("选择{0}注，共￥{1}元", betTotal, money);
        }
    }

    public class BetModel 
    {
        /// <summary>
        /// 玩法名：五星组选复式，前三直选单式等
        /// </summary>
        public string PlayName { get; set; }
        /// <summary>
        /// 玩法名代码:5xUF(五星组选复式)，Q3ID前三直选单式等
        /// </summary>
        public string PlayCode { get; set; }

        public int BetCount { get; set; }
    }
}
