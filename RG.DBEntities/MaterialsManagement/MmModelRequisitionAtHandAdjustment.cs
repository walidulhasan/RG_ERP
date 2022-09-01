using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmModelRequisitionAtHandAdjustment
    {
        public long Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public int? UserId { get; set; }
    }
}
