using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class FcrDetails
    {
        public int FcrdetailsId { get; set; }
        public int FcrmasterId { get; set; }
        public int InvoiceId { get; set; }
        public string Fcrno { get; set; }
        public DateTime Fcrdate { get; set; }
    }
}
