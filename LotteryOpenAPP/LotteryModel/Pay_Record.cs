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
    
    public partial class Pay_Record
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public string merchantId { get; set; }
        public string orderNO { get; set; }
        public decimal orderAmount { get; set; }
        public string payerName { get; set; }
        public string payerEmail { get; set; }
        public string payerTelephone { get; set; }
        public string orderDatetime { get; set; }
        public string productName { get; set; }
        public Nullable<decimal> productPrice { get; set; }
        public int productNum { get; set; }
        public string productId { get; set; }
        public string productDesc { get; set; }
        public string ext1 { get; set; }
        public string ext2 { get; set; }
        public string mchtOrderId { get; set; }
        public int pay_status { get; set; }
        public string paydatetime { get; set; }
        public System.DateTime creation_time { get; set; }
        public Nullable<int> payType { get; set; }
    }
}
