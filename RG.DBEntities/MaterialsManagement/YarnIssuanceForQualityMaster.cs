using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnIssuanceForQualityMaster
    {
        [Key]
        public long YarnQltyIssuanceId { get; set; }
        public long YarnInspectionId { get; set; }
        public long Poid { get; set; }
        public long YarnTempRecId { get; set; }
        public DateTime IssuanceDate { get; set; }
        public string ContactPerson { get; set; }
        public string ReferenceNo { get; set; }
        public long? CriteriaId { get; set; }
        public long? QltyLabId { get; set; }

        public virtual Yarn_InspectionMaster YarnInspection { get; set; }
    }
}
