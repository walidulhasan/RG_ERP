using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnQualityInspectionCriteriaMaster
    {
        public YarnQualityInspectionCriteriaMaster()
        {
            YarnQualityInspectionCriteriaDetail = new HashSet<YarnQualityInspectionCriteriaDetail>();
        }
        [Key]
        public long CriteriaId { get; set; }
        public long AttributeInstanceId { get; set; }
        public string CriteriaName { get; set; }

        public virtual ICollection<YarnQualityInspectionCriteriaDetail> YarnQualityInspectionCriteriaDetail { get; set; }
    }
}
