using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CottonItemProperties
    {
        public long Id { get; set; }
        public string ItemName { get; set; }
        public long AttributeInstanceId { get; set; }
        public double SafetyStock { get; set; }
        public int Sku { get; set; }
    }
}
