using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricYarnDesignType_Setup
    {
        public FabricYarnDesignType_Setup()
        {
            FabricYarnSpecification = new HashSet<FabricYarnSpecification>();
           // GreigeFabricCodeSetup = new HashSet<GreigeFabricCodeSetup>();
        }

        public int ID { get; set; }
        public string Description { get; set; }
        public int IsTippingVelt { get; set; }

        public virtual ICollection<FabricYarnSpecification> FabricYarnSpecification { get; set; }
       // public virtual ICollection<GreigeFabricCodeSetup> GreigeFabricCodeSetup { get; set; }
    }
}
