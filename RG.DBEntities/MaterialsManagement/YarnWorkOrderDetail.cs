using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnWorkOrderDetail
    {
        [Key]
        public long WorkOrderDetailId { get; set; }
        public long WorkOrderId { get; set; }
        public int MrpitemCode { get; set; }
        public long AttributeInstanceId { get; set; }
        public double? Utilization { get; set; }

        public virtual YarnWorkOrderMaster WorkOrder { get; set; }
    }
}
