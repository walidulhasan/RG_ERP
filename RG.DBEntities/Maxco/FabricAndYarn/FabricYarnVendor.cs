using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricYarnVendor
    {
        public int ID { get; set; }
        public int VendorID { get; set; }
        public int FabricYarnID { get; set; }
        public double Price { get; set; }

        public virtual FabricYarnCosting_Setup FabricYarn { get; set; }
        //public virtual FabricSimpleYarnVendorSetup Vendor { get; set; }
    }
}
