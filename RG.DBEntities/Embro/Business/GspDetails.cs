using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class GspDetails
    {
        public int GspdetailsId { get; set; }
        public int GspmasterId { get; set; }
        public int InvoiceId { get; set; }
        public string Gspno { get; set; }
        public DateTime Gspdate { get; set; }
    }
}
