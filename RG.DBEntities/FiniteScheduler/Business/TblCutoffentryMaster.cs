using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblCutoffentryMaster
    {
        public long Cutofffid { get; set; }
        public long? Orderid { get; set; }
        public long? Styleid { get; set; }
        public long? Colorid { get; set; }
        public string Pantonno { get; set; }
        public long? Weekno { get; set; }
        public long? Countryid { get; set; }
        public long? Sn { get; set; }
        public DateTime? Creationdate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public long? Cufoffno { get; set; }
        public long? Cuttingno { get; set; }
    }
}
