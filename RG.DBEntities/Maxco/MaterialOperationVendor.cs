using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class MaterialOperationVendor
    {   [Key]
        public short MaterialOperationId { get; set; }
        public short VendorId { get; set; }

        public virtual MaterialOperation_Setup MaterialOperation { get; set; }
        public virtual Vendor_setup Vendor { get; set; }
    }
}
