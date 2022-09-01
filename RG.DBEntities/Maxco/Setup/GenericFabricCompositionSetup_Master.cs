using RG.DBEntities.Maxco.FabricAndYarn;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class GenericFabricCompositionSetup_Master
    {
        public GenericFabricCompositionSetup_Master()
        {
            GenericFabricCompositionSetup_Detail = new HashSet<GenericFabricCompositionSetup_Detail>();
        }
        public long Id { get; set; }
        public string Description { get; set; }
        public int IsMix { get; set; }

        public virtual ICollection<GenericFabricCompositionSetup_Detail> GenericFabricCompositionSetup_Detail { get; set; }

        public virtual FabricYarnComposition_Setup FabricYarnComposition_Setup { get; set; }

    }
}
