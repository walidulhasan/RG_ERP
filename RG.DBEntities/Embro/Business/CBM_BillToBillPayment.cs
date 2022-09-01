using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Embro.Business
{
    public class CBM_BillToBillPayment
    {
        public long ID { get; set; }
        public long? VoucherID { get; set; }
        public long? AdjustmentVoucherID { get; set; }
        public long? InvoiceID { get; set; }
        public decimal? AdjustedAmount { get; set; }
        public decimal? PaidAmount { get; set; }
        public DateTime? EntryTime { get; set; }
    }
}
