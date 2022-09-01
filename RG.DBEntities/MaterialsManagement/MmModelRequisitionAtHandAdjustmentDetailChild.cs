using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmModelRequisitionAtHandAdjustmentDetailChild
    {
        [Key]
        public long DetailId { get; set; }
        public string Ponumber { get; set; }
        public double Quantity { get; set; }
        public long AttributeInstanceId { get; set; }

        public virtual MmModelRequisitionAtHandAdjustmentDetail Detail { get; set; }
    }
}
