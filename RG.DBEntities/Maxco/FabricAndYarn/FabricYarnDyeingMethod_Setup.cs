using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricYarnDyeingMethod_Setup
    {
        public FabricYarnDyeingMethod_Setup()
        {
            FabricYarnSpecification = new HashSet<FabricYarnSpecification>();
           // GreigeFabricYarnSpecification = new HashSet<GreigeFabricYarnSpecification>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FabricYarnSpecification> FabricYarnSpecification { get; set; }
       // public virtual ICollection<GreigeFabricYarnSpecification> GreigeFabricYarnSpecification { get; set; }
    }
}
