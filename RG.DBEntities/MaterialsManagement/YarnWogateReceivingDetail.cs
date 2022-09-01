using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnWogateReceivingDetail
    {
        public long YarnGateRecDetailId { get; set; }
        public long? YarnGateRecId { get; set; }
        public int? MrpitemCode { get; set; }
        public long? AttributeInstanceId { get; set; }
        public double? ReceivingQty { get; set; }
        public int? UnitId { get; set; }
        public double? Rate { get; set; }
        public int? RateUnitId { get; set; }
        public long? YarnWorecDetailId { get; set; }
    }
}
