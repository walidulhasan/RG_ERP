using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricFinishingPropertiesSetup
    {
        public FabricFinishingPropertiesSetup()
        {
            FabricFinishingPropertiesValueSetup = new HashSet<FabricFinishingPropertiesValueSetup>();
        }

        public byte FinishingId { get; set; }
        public byte Id { get; set; }
        public string Description { get; set; }

        public virtual FabricFinishingSetup Finishing { get; set; }
        public virtual ICollection<FabricFinishingPropertiesValueSetup> FabricFinishingPropertiesValueSetup { get; set; }
    }
}
