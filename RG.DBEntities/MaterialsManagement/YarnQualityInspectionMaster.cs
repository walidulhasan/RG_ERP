using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnQualityInspectionMaster
    {
        public YarnQualityInspectionMaster()
        {
            YarnQualityInspectionDetail = new HashSet<YarnQualityInspectionDetail>();
        }
        [Key]
        public long QualityInspId { get; set; }
        public DateTime? InspectionDate { get; set; }
        public long? TempRecId { get; set; }
        public long? Poid { get; set; }
        public long? CriteriaId { get; set; }
        public long? InspectionStatus { get; set; }
        public long? CompanyId { get; set; }
        public int? BusinessId { get; set; }

        public virtual ICollection<YarnQualityInspectionDetail> YarnQualityInspectionDetail { get; set; }
    }
}
