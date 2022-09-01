using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;


namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricYarnVendorColor_Setup
    {
        public FabricYarnVendorColor_Setup()
        {
            FabricYarnSpecification = new HashSet<FabricYarnSpecification>();
            FurYarnSpecification = new HashSet<FurYarnSpecification>();
            TwillTapeYarnSpecification = new HashSet<TwillTapeYarnSpecification>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int FabricYarnVendorColorNameId { get; set; }
        public string PicturePath { get; set; }
       

        public virtual FabricYarnVendorColorNameSetup FabricYarnVendorColorName { get; set; }
        public virtual ICollection<FabricYarnSpecification> FabricYarnSpecification { get; set; }
        public virtual ICollection<FurYarnSpecification> FurYarnSpecification { get; set; }
        public virtual ICollection<TwillTapeYarnSpecification> TwillTapeYarnSpecification { get; set; }
    }
}
