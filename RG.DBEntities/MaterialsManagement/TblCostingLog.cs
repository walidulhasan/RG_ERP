using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class TblCostingLog
    {
        public int VerNo { get; set; }
        public long OrderId { get; set; }
        public long StyleId { get; set; }
        public DateTime CostingDate { get; set; }
        public object CostingData { get; set; }
    }
}
