using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class ViwRfp
    {
        public decimal Rfpid { get; set; }
        public string Rfpnum { get; set; }
        public DateTime? Rfpdate { get; set; }
        public decimal? SupplierId { get; set; }
        public decimal? NetAmount { get; set; }
        public decimal InvoiceId { get; set; }
    }
}
