using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class Results
    {
        public string Style { get; set; }
        public double? Color { get; set; }
        public string Size { get; set; }
        public double? Quantity { get; set; }
        public double? ComboId { get; set; }
    }
}
