using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricFinishingPropertiesValueSetup
    {
        public FabricFinishingPropertiesValueSetup()
        {
            FabricSelectedFinishingPropertiesValue = new HashSet<FabricSelectedFinishingPropertiesValue>();
        }

        public short Id { get; set; }
        public byte FabricFinishingPropertiesId { get; set; }
        public string Description { get; set; }

        public virtual FabricFinishingPropertiesSetup FabricFinishingProperties { get; set; }
        public virtual ICollection<FabricSelectedFinishingPropertiesValue> FabricSelectedFinishingPropertiesValue { get; set; }
    }
}
