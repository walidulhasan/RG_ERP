using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class WoWorkOrderMaster
    {
        public int Id { get; set; }
        public int WorkOrderId { get; set; }
        public long AttributeInstanceId { get; set; }
        public int? UnitId { get; set; }
        public long? OrderId { get; set; }
        public int? ObjectId { get; set; }
        public int? RequisitionId { get; set; }
        public int? MrpitemCode { get; set; }
        public int? IsMrpbased { get; set; }
        public long? ModelId { get; set; }
        public string TrimColor { get; set; }
        public int? TrimColorId { get; set; }
    }
}
