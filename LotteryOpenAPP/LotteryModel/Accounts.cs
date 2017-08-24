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
    
    public partial class Accounts
    {
        public Accounts()
        {
            this.AccountBusiness = new HashSet<AccountBusiness>();
            this.BetInfo = new HashSet<BetInfo>();
            this.BankCard = new HashSet<BankCard>();
        }
    
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
        public string Email { get; set; }
    
        public virtual ICollection<AccountBusiness> AccountBusiness { get; set; }
        public virtual ICollection<BetInfo> BetInfo { get; set; }
        public virtual ICollection<BankCard> BankCard { get; set; }
    }
}