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
    
    public partial class LotteryOpen
    {
        public long Id { get; set; }
        public int LotteryId { get; set; }
        public string ExpectDate { get; set; }
        public string Expect { get; set; }
        public string OpenCode { get; set; }
        public Nullable<System.DateTime> OpenTime { get; set; }
        public string ScheduleOpenCode { get; set; }
        public System.DateTime ScheduleOpenTime { get; set; }
        public int OpenStatus { get; set; }
        public int RerollCount { get; set; }
    }
}
