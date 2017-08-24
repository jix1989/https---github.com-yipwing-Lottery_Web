using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotteryModel
{
    public class AgentCalculateTool
    {
       
        public static object GetAgentBackMoney(decimal percent)
        {
            var query = (from a in LotteryOpenTool_11x5.LpList()
                         select new
                         {
                             a.LotteryPlayName,
                             a.PayBack,
                             PayBack2 = Math.Ceiling(GetAgentBackMoney_11x5(a.PayBack, percent) * 1000) / 1000,
                         }).ToList();
            return query;
        }
        #region 十一选五
        /// <summary>
        /// 奖金模式
        /// </summary>
        static int jjms_11x5 = 1811;
        static Dictionary<string, decimal> AgentBackMoneyDic_11x5 = new Dictionary<string, decimal>();
        static Dictionary<string, decimal> AgentBackMoneyDic2_11x5 = new Dictionary<string, decimal>();
        public static decimal GetAgentBackMoney_11x5(decimal payBack, decimal percent)
        {
            var key = payBack + "," + percent;
            if (!AgentBackMoneyDic_11x5.Keys.Contains(key))//若不再字典则计算和添加
            {
                var value = Math.Round((payBack + payBack * percent * new decimal(19.8) / jjms_11x5), 2);
                AgentBackMoneyDic_11x5.Add(key, value);
            }
            return AgentBackMoneyDic_11x5[key];
        }
        public static decimal GetAgentBackMoney_11x5(int code, decimal percent)
        {
            var key = code + "," + percent;
            if (!AgentBackMoneyDic2_11x5.Keys.Contains(key)) //若不再字典则计算和添加
            {
                var j = LotteryOpenTool_11x5.LpList().FirstOrDefault(n => n.BetPlayTypeCode == code);
                if (j == null) return 0;
                AgentBackMoneyDic2_11x5.Add(key, GetAgentBackMoney_11x5(j.PayBack, percent));
            }
            return AgentBackMoneyDic2_11x5[key];

        }
        #endregion

        #region 时时彩
        static Dictionary<string, decimal> AgentBackMoneyDic_SSC = new Dictionary<string, decimal>();
        static Dictionary<string, decimal> AgentBackMoneyDic2_SSC = new Dictionary<string, decimal>();
        /// <summary>
        /// 奖金模式
        /// </summary>
        static int jjms_SSC = 1800;
        public static decimal GetAgentBackMoney_SSC(decimal payBack, decimal percent)
        {
            var key = payBack + "," + percent;
            if (!AgentBackMoneyDic_SSC.Keys.Contains(key))//若不再字典则计算和添加
            {
                var value = Math.Round((payBack + payBack * percent * new decimal(20) / jjms_SSC), 2);
                AgentBackMoneyDic_SSC.Add(key, value);
            }
            return AgentBackMoneyDic_SSC[key];
        }
        public static decimal GetAgentBackMoney_SSC(int code, decimal percent)
        {
            var key = code + "," + percent;
            if (!AgentBackMoneyDic2_SSC.Keys.Contains(key)) //若不再字典则计算和添加
            {
                var j = LotteryInfo_SSC.LpList().FirstOrDefault(n => n.BetPlayTypeCode == code);
                if (j == null) return 0;
                AgentBackMoneyDic2_SSC.Add(key, GetAgentBackMoney_SSC(j.PayBack, percent));
            }
            return AgentBackMoneyDic2_SSC[key];
        }
        #endregion

        #region 3D
        static Dictionary<string, decimal> AgentBackMoneyDic_3D = new Dictionary<string, decimal>();
        static Dictionary<string, decimal> AgentBackMoneyDic2_3D = new Dictionary<string, decimal>();
        /// <summary>
        /// 奖金模式
        /// </summary>
        static int jjms_3D = 1800;
        public static decimal GetAgentBackMoney_3D(decimal payBack, decimal percent)
        {
            var key = payBack + "," + percent;
            if (!AgentBackMoneyDic_3D.Keys.Contains(key))//若不再字典则计算和添加
            {
                var value = Math.Round((payBack + payBack * percent * new decimal(20) / jjms_3D), 2);
                AgentBackMoneyDic_3D.Add(key, value);
            }
            return AgentBackMoneyDic_3D[key];
        }
        public static decimal GetAgentBackMoney_3D(int code, decimal percent)
        {
            var key = code + "," + percent;
            if (!AgentBackMoneyDic2_3D.Keys.Contains(key)) //若不再字典则计算和添加
            {
                var j = LotteryOpenTool_3D.LpList().FirstOrDefault(n => n.BetPlayTypeCode == code);
                if (j == null) return 0;
                AgentBackMoneyDic2_3D.Add(key, GetAgentBackMoney_3D(j.PayBack, percent));
            }
            return AgentBackMoneyDic2_3D[key];
        }
        #endregion
    }
}
