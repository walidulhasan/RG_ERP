using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class UtitlityExpenditureVoucherInfo
    {
        public decimal VoucherId { get; set; }
        public int? AccountId { get; set; }
        public int? ItemId { get; set; }
        public int? StoreId { get; set; }
        public string RequisitionNumber { get; set; }
        public int? Vindex { get; set; }
        public long Vid { get; set; }
    }
}
