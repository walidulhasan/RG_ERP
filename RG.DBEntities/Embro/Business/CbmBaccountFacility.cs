using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class CbmBaccountFacility
    {
        public decimal? BaccountId { get; set; }
        public string FinFacilityId { get; set; }
        public decimal? Limit { get; set; }
        public decimal? Rate { get; set; }
        public string Collateral { get; set; }
        public string Remarks { get; set; }
        public DateTime? RepaymentDate { get; set; }
        public DateTime? RenewalDate { get; set; }

        public virtual BasicCOA BasicCOA { get; set; }
    }
}
