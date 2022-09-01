using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblMarkerPartMaster
    {
        public long Cmpid { get; set; }
        public long? Orderid { get; set; }
        public long? Styleid { get; set; }
        public string Panton { get; set; }
        public DateTime? Cretiondate { get; set; }
        public long? Userid { get; set; }
    }
}
