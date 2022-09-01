using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class BrandSetupBk
    {
        public long BrandId { get; set; }
        public int SupplierId { get; set; }
        public string Description { get; set; }
    }
}
