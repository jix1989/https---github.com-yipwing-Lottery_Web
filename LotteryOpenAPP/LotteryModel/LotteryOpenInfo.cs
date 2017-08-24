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
    
    public partial class LotteryOpenInfo
    {
        public LotteryOpenInfo()
        {
            this.BetInfo = new HashSet<BetInfo>();
        }
    
        public long Id { get; set; }
        public int LotteryId { get; set; }
        public string Expect { get; set; }
        public string OpenCode { get; set; }
        public System.DateTime OpenTime { get; set; }
        public System.DateTime OpenDate { get; set; }
    
        public virtual ICollection<BetInfo> BetInfo { get; set; }
        public virtual LotteryPrizePoolInfo LotteryPrizePoolInfo { get; set; }
        public virtual LotteryOpenInfo LotteryOpenInfo1 { get; set; }
        public virtual LotteryOpenInfo LotteryOpenInfo2 { get; set; }
        public virtual Lotterys Lotterys { get; set; }
    }
}
