using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class apm_InvoiceAdjustment
    {
        public int ID { get; set; }
        public long? VoucherID { get; set; }
        public long? InvoiceID { get; set; }
        public double? AdjustedAmount { get; set; }
        public DateTime? EntryDate { get; set; }
    }
}
