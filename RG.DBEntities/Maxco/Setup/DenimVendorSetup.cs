using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class DenimVendorSetup
    {
        public DenimVendorSetup()
        {
            DenimVendorCodeSetup = new HashSet<DenimVendorCodeSetup>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int? FabricCategoryId { get; set; }

        public virtual ICollection<DenimVendorCodeSetup> DenimVendorCodeSetup { get; set; }
    }
}
