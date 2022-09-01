using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricYarnQuality_Setup
    {
        public FabricYarnQuality_Setup()
        {
            FabricYarnCostingSetup = new HashSet<FabricYarnCosting_Setup>();
            FabricYarnSpecification = new HashSet<FabricYarnSpecification>();
        }

        public int ID { get; set; }
        public string Description { get; set; }
        public int? IsDeleted { get; set; }

        public virtual ICollection<FabricYarnCosting_Setup> FabricYarnCostingSetup { get; set; }
        public virtual ICollection<FabricYarnSpecification> FabricYarnSpecification { get; set; }
    }
}
