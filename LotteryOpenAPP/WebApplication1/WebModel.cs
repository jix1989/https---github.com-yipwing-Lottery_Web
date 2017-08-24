using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string AccountPwd { get; set; }
        public decimal AccountBalance { get; set; }
        public int AccountParentId { get; set; }
        public string AccountNickname { get; set; }
        public decimal AgentPercentSSC { get; set; }
        public decimal AgentPercent11X5 { get; set; }
        public decimal AgentPercentDPC { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int AccountStatus { get; set; }
        public int LoginCount { get; set; }
        public Nullable<System.DateTime> LastLogin { get; set; }
        public bool BankCardLockStatus { get; set; }
        public string AccountMoneyPwd { get; set; }
    }

    public class WS_BetInfo
    {
        public string BetNum { get; set; }
        public int BetPlayTypeCode { get; set; }
        public int BetUnit { get; set; }
        public int BetTimes { get; set; }
        /// <summary>
        /// 元，角，分，厘
        /// </summary>
        public string BetMoneyMode { get; set; }
        public decimal BetMoney { get; set; }
        /// <summary>
        /// 任选玩法勾选位置0:万,1:千,2:百,3:十,4:个
        /// </summary>
        public string ChoicePosition { get; set; }
        public bool IsGetBackPercent { get; set; }
    }
    public class WS_ZHInfo:WS_BetInfo
    {
        public string Except { get; set; }
    }
    public partial class WS_BankCard
    {
        public int No { get; set; }
        public string BankName { get; set; }
        public string CardNo { get; set; }
        public System.DateTime CreatTime { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string OpenCardName { get; set; }
        public Nullable<int> CityId { get; set; }
    }

    public class Item_IdName
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Item_LoginIdDic 
    {
        public int Id { get; set; }
        public DateTime LoginTime { get; set; }
    }

    public class WS_Lotterys
    {
        public int Id { get; set; }
        public string LotteryName { get; set; }
        public string LotteryType { get; set; }
        public string LotteryCode { get; set; }
        public bool IsPrivate { get; set; }
        public Nullable<decimal> TimeStart { get; set; }
        public Nullable<decimal> TimeEnd { get; set; }
        public Nullable<decimal> BetweenMinute { get; set; }
        public Nullable<int> ExceptLength { get; set; }
        public Nullable<int> ExceptOneDay { get; set; }
    }

    public class WS_LotteryPlay
    {
        public string LotteryType { get; set; }
        public int LotteryPlayId { get; set; }
        public string LotteryPlayName { get; set; }
        public Dictionary<int,decimal> PrizeClass { get; set; }
        public Nullable<decimal> PayBack { get; set; }
    }

    public class WS_LotteryOffcialSchedule
    {
        public long Id { get; set; }
        public int LotteryId { get; set; }
        public string Expect { get; set; }
        public System.DateTime ScheduleOpenTime { get; set; }
    }

    public class WS_LotteryOpenInfo
    {
        public long Id { get; set; }
        public int LotteryId { get; set; }
        public string Expect { get; set; }
        public string OpenCode { get; set; }
        public System.DateTime OpenTime { get; set; }
        public System.DateTime OpenDate { get; set; }
    }


}