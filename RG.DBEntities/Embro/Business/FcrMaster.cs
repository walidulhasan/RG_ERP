using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class FcrMaster
    {
        public int FcrmasterId { get; set; }
        public string FcrmasterNo { get; set; }
        public DateTime FcrmasterDate { get; set; }
        public decimal ChequeId { get; set; }
    }
}
