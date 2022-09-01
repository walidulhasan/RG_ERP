using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class APM_Invoice_Detail_robust
    {
        public decimal InvoiceID { get; set; }
        public decimal VoucherID { get; set; }
        public decimal? InvoiceEffect { get; set; }
    }
}
