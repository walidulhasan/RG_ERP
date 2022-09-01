using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnQualityInspectionDetail
    {
        [Key]
        public long QualityInspDetailId { get; set; }
        public long QualityInspId { get; set; }
        public string AttributeId { get; set; }
        public string AttributeValue { get; set; }
        public int? FabricGroupId { get; set; }
        public int? MasterShadeId { get; set; }
        public string ShadeColor { get; set; }

        public virtual YarnQualityInspectionMaster QualityInsp { get; set; }
    }
}
