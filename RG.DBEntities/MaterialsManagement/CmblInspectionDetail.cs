using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblInspectionDetail
    {
        [Key]
        public long Mindid { get; set; }
        public long? Minid { get; set; }
        public long? PoitemId { get; set; }
        public double? MinacceptedQty { get; set; }
        public double? MinrejectedQty { get; set; }
        public string Mincomments { get; set; }

        public virtual CmblInspectionMain Min { get; set; }
        public virtual CmblPurchaseOrderItem Poitem { get; set; }
    }
}
