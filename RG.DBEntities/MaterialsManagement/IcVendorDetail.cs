using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class IcVendorDetail
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public long VendorId { get; set; }
    }
}
