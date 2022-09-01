using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DyedGateReceivingDetail
    {
        public int Id { get; set; }
        public int Grid { get; set; }
        public long AttributeInstanceId { get; set; }
        public string LotNo { get; set; }
        public int NoOfRolls { get; set; }
        public double Weight { get; set; }

        public virtual DyedGateReceivingMaster Gr { get; set; }
    }
}
