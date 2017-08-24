using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotteryModel
{
    public enum Enum_LotteryOpenStatus
    {
        ///// <summary>
        ///// 开奖未返奖
        ///// </summary>
        //OpenedWithNoBack = -2,
        //Opened = -1,
        //Next = 1,
        Schedule = 0,
        //Wait = 0,
        Opening = 1,
        Succeed = 2,
        /// <summary>
        /// 未成功开奖
        /// </summary>
        Fail = 3,
        /// <summary>
        /// 预开奖
        /// </summary>

    }

    public enum Enum_ResultType
    {
        Wait = 0,//等待开奖
        Backing = 1,//返奖中
        False = 2,//未中奖
        True = 3,//中奖
        //True_Add=4,
        ///// <summary>
        ///// 未成功开奖
        ///// </summary>
        //Fail = 3,
        /// <summary>
        /// 追中撤单
        /// </summary>
        WinThenCancel=4,
    }

    public enum Enum_AccountBusinessType
    {
        /// <summary>
        /// 投注扣款
        /// </summary>
        Bet = 1,
        /// <summary>
        /// 奖金派发
        /// </summary>
        Win,
        /// <summary>
        /// 游戏返点
        /// </summary>
        BackPercent,
        /// <summary>
        /// 充值
        /// </summary>
        Recharge,
        /// <summary>
        /// 提现
        /// </summary>
        Withdraw,
        /// <summary>
        /// 活动赠送
        /// </summary>
        Activity,
        /// <summary>
        /// 追中撤单
        /// </summary>
        WinThenCancel,
    }

    public enum Enum_AccountStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal = 1,
        /// <summary>
        /// 锁定
        /// </summary>
        Lock
    }

    public enum Enum_BusinessType
    {
        All = 0,//全部
        TZKK,//投注扣款
        JJPF,//奖金派发
        YXFD,//游戏返点
        ZHCZ,//账户充值
        ZHTX,//账户提现
    }

    public static class EnumTool
    {
        public static string GetBetResultType(int ResultType)
        {
            string str = "";
            var t = (Enum_ResultType)ResultType;
            switch (t)
            {
                case Enum_ResultType.Backing:
                    str = "返奖中";
                    break;
                case Enum_ResultType.False:
                    str = "未中奖";
                    break;
                case Enum_ResultType.True:
                    str = "中奖";
                    break;
                case Enum_ResultType.Wait:
                    str = "等待开奖";
                    break;
            }
            return str;
        }

        public static string GetBusinessType(int BusinessType) 
        {
            string str = "";
            var t = (Enum_BusinessType)BusinessType;
            switch (t)
            {
                case Enum_BusinessType.TZKK:
                    str = "投注扣款";
                    break;
                case Enum_BusinessType.JJPF:
                    str = "奖金派发";
                    break;
                case Enum_BusinessType.YXFD:
                    str = "游戏返点";
                    break;
                case Enum_BusinessType.ZHCZ:
                    str = "账户充值";
                    break;
                case Enum_BusinessType.ZHTX:
                    str = "账户充值";
                    break;
            }
            return str;
        }
    }
}
