using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmModelRequisitionAtHandAdjustmentDetail
    {
        public MmModelRequisitionAtHandAdjustmentDetail()
        {
            MmModelRequisitionAtHandAdjustmentDetailChild = new HashSet<MmModelRequisitionAtHandAdjustmentDetailChild>();
        }

        public long Id { get; set; }
        public long MasterId { get; set; }
        public long OrderId { get; set; }
        public long ModelId { get; set; }
        public long ObjectId { get; set; }
        public long AttributeInstanceId { get; set; }
        public double Quantity { get; set; }

        public virtual ICollection<MmModelRequisitionAtHandAdjustmentDetailChild> MmModelRequisitionAtHandAdjustmentDetailChild { get; set; }
    }
}
