using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class InvoicePriceVersion
    {
        public int Id { get; set; }
        public int VersionNo { get; set; }
        public int StyleId { get; set; }
        public double TotalExpPrice { get; set; }
        public double InvoicePrice { get; set; }
        public int InvoicePriceCurrencyId { get; set; }
        public DateTime InvoicePriceEntryDate { get; set; }
        public int? InvoicePriceUserId { get; set; }
    }
}
