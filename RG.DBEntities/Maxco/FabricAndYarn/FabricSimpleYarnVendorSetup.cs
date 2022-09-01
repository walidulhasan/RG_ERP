using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricSimpleYarnVendorSetup
    {
        public FabricSimpleYarnVendorSetup()
        {
            FabricYarnVendor = new HashSet<FabricYarnVendor>();
        }

        public short Id { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int? Coaid { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string SalesTaxRegNumber { get; set; }
        public string Ntnnumber { get; set; }
        public bool? Distributor { get; set; }

        public virtual ICollection<FabricYarnVendor> FabricYarnVendor { get; set; }
    }
}
