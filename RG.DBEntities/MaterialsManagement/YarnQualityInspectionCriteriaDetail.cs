using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnQualityInspectionCriteriaDetail
    {
        [Key]
        public long DetailId { get; set; }
        public long? CriteriaId { get; set; }
        public long? AttributeId { get; set; }
        public string AttributeValue { get; set; }

        public virtual YarnQualityInspectionCriteriaMaster Criteria { get; set; }
    }
}
