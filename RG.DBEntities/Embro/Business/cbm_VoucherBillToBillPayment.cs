using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class cbm_VoucherBillToBillPayment
    {
        public long ID { get; set; }
        public decimal? VoucherID { get; set; }
        public long? AdjustmentVoucherID { get; set; }
        public decimal? PaidAmount { get; set; }
        public DateTime? EntryTime { get; set; }
        public virtual Voucher Voucher { get; set; }
    }
}
