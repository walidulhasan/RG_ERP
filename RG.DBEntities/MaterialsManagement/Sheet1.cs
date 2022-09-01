using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class Sheet1
    {
        public double? ItemId { get; set; }
        public string Type { get; set; }
        public string Classification { get; set; }
        public string ItemDescription { get; set; }
        public string HscodeEffective { get; set; }
        public double? Cd { get; set; }
        public double? Sd { get; set; }
        public double? Vat { get; set; }
        public double? Ait { get; set; }
        public double? Atv { get; set; }
        public double? Rd { get; set; }
        public double? Ttl { get; set; }
    }
}
