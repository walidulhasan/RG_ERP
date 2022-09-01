using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DyedCuttingReceivingMaster
    {
        public long CuttingId { get; set; }
        public string CuttingNo { get; set; }
        public DateTime RecDate { get; set; }
        public long IssuanceId { get; set; }
        public int IsInspected { get; set; }
        public int? UserId { get; set; }
    }
}
