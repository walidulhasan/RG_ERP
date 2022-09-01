using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class TblInvoiceCurrency
    {
        public long InvoiceId { get; set; }
        public int? CurrencyId { get; set; }
        public double? Rate { get; set; }
    }
}
