using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class KnittingRateSetup1
    {
        public int Id { get; set; }
        public int FabricTypeId { get; set; }
        public int FabricKnittingTypeId { get; set; }
        public double? Rate { get; set; }
        public bool? IsRateInserted { get; set; }
        public int FabricQualityId { get; set; }
    }
}
