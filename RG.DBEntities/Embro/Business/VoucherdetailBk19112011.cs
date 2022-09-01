using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class VoucherdetailBk19112011
    {
        public decimal VoucherId { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public int? LocationId { get; set; }
        public string Status { get; set; }
        public long? Costcenter { get; set; }
        public long? Activity { get; set; }
        public int? Vindex { get; set; }
        public long Vid { get; set; }
        public long? EntryType { get; set; }
    }
}
