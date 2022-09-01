using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class GenericFabricCompositionSetup_Detail 
    {
        public long ID{ get; set; }
        [ForeignKey("GenericFabricCompositionSetup_Master")]
        public long FabricMasterID { get; set; }
        public long FabricRatioID { get; set; }
        public double RatioValue { get; set; }

        public GenericFabricCompositionSetup_Master GenericFabricCompositionSetup_Master { get; set; }
    }
}
