using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DyedPurchaseOrderDeliverySchedule
    {
        public long Id { get; set; }
        public long Poid { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double Weight { get; set; }
        public int DeliveryLocationId { get; set; }
    }
}
