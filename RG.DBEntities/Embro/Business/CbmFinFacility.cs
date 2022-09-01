using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class CbmFinFacility
    {
        public decimal FinFacilityId { get; set; }
        public string FinFacilityName { get; set; }
        public string FinFacilityDesc { get; set; }
        public string Type { get; set; }

        public virtual BasicCOA BasicCOA { get; set; }
    }
}
