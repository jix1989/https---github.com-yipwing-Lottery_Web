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
    
    public partial class AccountBusiness
    {
        public long Id { get; set; }
        public int AccountId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int BusinessTypeId { get; set; }
        public Nullable<decimal> PayIn { get; set; }
        public Nullable<decimal> PayOut { get; set; }
        public decimal PayBefore { get; set; }
        public decimal PayAfter { get; set; }
        public Nullable<long> EventId { get; set; }
    
        public virtual Accounts Accounts { get; set; }
    }
}