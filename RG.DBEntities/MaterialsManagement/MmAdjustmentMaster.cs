using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmAdjustmentMaster
    {
        public long AdjustmentId { get; set; }
        public string AdjustmentNoteNo { get; set; }
        public DateTime? AdjustmentDate { get; set; }
        public int? UserId { get; set; }
    }
}
