using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnWeighingInspectionDetail
    {
        [Key]
        public long YarnWeighDetailId { get; set; }
        public long? YarnWeighInspId { get; set; }
        public decimal? Weight { get; set; }

        public virtual Yarn_WeighingInspectionMaster YarnWeighInsp { get; set; }
    }
}
