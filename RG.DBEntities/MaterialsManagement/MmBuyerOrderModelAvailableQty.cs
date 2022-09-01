using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmBuyerOrderModelAvailableQty
    {
        public long Id { get; set; }
        public long? AttributeInstanceId { get; set; }
        public int? BuyerId { get; set; }
        public int? OrderId { get; set; }
        public int? ModelId { get; set; }
        public double? AvailableQuantity { get; set; }
    }
}
