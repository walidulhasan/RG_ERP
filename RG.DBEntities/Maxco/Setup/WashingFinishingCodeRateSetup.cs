using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class WashingFinishingCodeRateSetup
    {
        public long Id { get; set; }
        public string CodeId { get; set; }
        public int? FabricTypeId { get; set; }
        public int? FabricQualityId { get; set; }
        public double Rate { get; set; }
    }
}
