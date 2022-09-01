using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricYarnDyeing_Setup
    {
        public FabricYarnDyeing_Setup()
        {
            FabricYarnSpecification = new HashSet<FabricYarnSpecification>();
          //  FabricYarnVendorSetup = new HashSet<FabricYarnVendorSetup>();
            GreigeFabricYarnSpecification = new HashSet<GreigeFabricYarnSpecification>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FabricYarnSpecification> FabricYarnSpecification { get; set; }
      //  public virtual ICollection<FabricYarnVendorSetup> FabricYarnVendorSetup { get; set; }
        public virtual ICollection<GreigeFabricYarnSpecification> GreigeFabricYarnSpecification { get; set; }
    }
}
