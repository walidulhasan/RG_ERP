using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Business
{
    public partial class CollectionModel_PriceList
    {
        public int Id { get; set; }
        public int CollectionId { get; set; }
        public long StyleId { get; set; }
        public double? CostRs { get; set; }
        public double? CostEuro { get; set; }
        public double? GenExp { get; set; }
        public double? Profit { get; set; }
        public double? Royalty { get; set; }
        public double? TotalExpPrice { get; set; }
        public double? InvoicePrice { get; set; }
        public int? InvoicePriceCurrencyId { get; set; }
        public DateTime? InvoicePriceEntryDate { get; set; }
        public int? InvoicePriceUserId { get; set; }

        public virtual Style Style { get; set; }
    }
}
