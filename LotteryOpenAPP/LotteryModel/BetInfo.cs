//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace LotteryModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class BetInfo
    {
        public long Id { get; set; }
        public int AccountId { get; set; }
        public Nullable<long> LotteryOpenId { get; set; }
        public int ResultType { get; set; }
        public string BetNum { get; set; }
        public int BetPlayTypeCode { get; set; }
        public int BetUnit { get; set; }
        public decimal BetMoney { get; set; }
        public int BetTimes { get; set; }
        public decimal BackMoney { get; set; }
        public int WinUnit { get; set; }
        public Nullable<decimal> WinMoney { get; set; }
        public decimal GetBackPercent { get; set; }
        public decimal MaxBackMoney { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<System.DateTime> BackTime { get; set; }
        public string ChoicePosition { get; set; }
        public bool IsGetBackPercent { get; set; }
        public int LotteryId { get; set; }
        public string LotteryExcept { get; set; }
        public string AddNumNo { get; set; }
        public Nullable<bool> IsWinCancel { get; set; }
    
        public virtual Accounts Accounts { get; set; }
        public virtual LotteryOpenInfo LotteryOpenInfo { get; set; }
    }
}