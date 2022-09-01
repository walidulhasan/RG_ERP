using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricYarnVendorColorNameSetup
    {
        public FabricYarnVendorColorNameSetup()
        {
            FabricYarnVendorColorSetup = new HashSet<FabricYarnVendorColor_Setup>();
            GreigeFabricYarnSpecification = new HashSet<GreigeFabricYarnSpecification>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public short FabricYarnVendorId { get; set; }

        public virtual ICollection<FabricYarnVendorColor_Setup> FabricYarnVendorColorSetup { get; set; }
        public virtual ICollection<GreigeFabricYarnSpecification> GreigeFabricYarnSpecification { get; set; }
    }
}
