using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Embro.Business
{
    public partial class APM_Invoice_Detail
    {
        [Key,Column(Order =0)]
        public decimal InvoiceID { get; set; }
        [Key, Column(Order = 1)]
        public decimal VoucherID { get; set; }
        public decimal? InvoiceEffect { get; set; }

        public virtual APM_Invoice_Main APM_Invoice_Main { get; set; }
        public virtual Voucher Voucher { get; set; }
    }
}
