using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmOutGatePassDetail
    {
        public long Id { get; set; }
        public long OutGatePassId { get; set; }
        public long AttributeInstanceId { get; set; }
        public int MrpitemCode { get; set; }
        public double Quantity { get; set; }
        public int UnitId { get; set; }
    }
}
