using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotteryModel
{
    public class WS_BetInfoDgv
    {
        public long Id { get; set; }
        public string AccountName { get; set; }
        public int LotteryId { get; set; }
        public string LotteryName { get; set; }
        public string LotteryExcept { get; set; }
        public string PlayName { get; set; }
        public int ResultType { get; set; }
        public string ResultTypeStr { get; set; }
        public string BetNum { get; set; }
        public int BetUnit { get; set; }
        public decimal BetMoney { get; set; }
        public int BetTimes { get; set; }
        public decimal BackMoney { get; set; }
        public int WinUnit { get; set; }
        public Nullable<decimal> WinMoney { get; set; }
        public decimal GetBackPercent { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<System.DateTime> BackTime { get; set; }
        public string ChoicePosition { get; set; }
        public bool IsGetBackPercent { get; set; }
        public string OpenCode { get; set; }
        public string IsChaseNumber { get; set; }
    }
    public class WS_AccountBusiness
    {
        public long Id { get; set; }
        //public int AccountId { get; set; }
        public string AccountName { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int BusinessTypeId { get; set; }
        public string BusinessTypeStr { get; set; }
        public Nullable<decimal> PayIn { get; set; }
        public Nullable<decimal> PayOut { get; set; }
        public decimal PayBefore { get; set; }
        public decimal PayAfter { get; set; }
        public Nullable<long> EventId { get; set; }
    }

    public class WS_Accounts_Agent
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public decimal AccountBalance { get; set; }
        public int AccountParentId { get; set; }
        public string AccountParentName { get; set; }
        public decimal AgentPercentSSC { get; set; }
        public System.DateTime CreateTime { get; set; }
        public string AccountStatus { get; set; }
        public int LoginCount { get; set; }
    }
}
