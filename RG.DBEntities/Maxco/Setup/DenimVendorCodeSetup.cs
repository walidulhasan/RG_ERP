using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class DenimVendorCodeSetup
    {
        public int Id { get; set; }
        public int DenimVendorId { get; set; }
        public string VendorCode { get; set; }

        public virtual DenimVendorSetup DenimVendor { get; set; }
    }
}
