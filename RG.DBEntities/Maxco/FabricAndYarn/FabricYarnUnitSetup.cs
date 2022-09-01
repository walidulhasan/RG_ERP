using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricYarnUnitSetup
    {
        public FabricYarnUnitSetup()
        {
            FabricYarnCostingSetup = new HashSet<FabricYarnCosting_Setup>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FabricYarnCosting_Setup> FabricYarnCostingSetup { get; set; }
    }
}
