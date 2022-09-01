using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnStockAdjustment
    {
        public long Id { get; set; }
        public long AttributeInstanceId { get; set; }
        public long Quantity { get; set; }
    }
}
