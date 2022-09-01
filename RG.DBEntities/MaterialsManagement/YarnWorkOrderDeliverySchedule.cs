using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnWorkOrderDeliverySchedule
    {
        [Key]
        public long WorkOrderDelSchdId { get; set; }
        public long? WorkOrderId { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public decimal? Weight { get; set; }
        public int? DeliveryLocationId { get; set; }

        public virtual YarnWorkOrderMaster WorkOrder { get; set; }
    }
}
