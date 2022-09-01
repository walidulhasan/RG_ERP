using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class TblOrderColorCostingCache
    {
        public long Id { get; set; }
        public long? OrderId { get; set; }
        public string Color { get; set; }
        public double? Costing { get; set; }
    }
}
