using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class Yarn_InspectionMaster
    {
        public Yarn_InspectionMaster()
        {
           // YarnIssuanceForQualityMaster = new HashSet<YarnIssuanceForQualityMaster>();
        }
        [Key]
        public long YarnInspectionID { get; set; }
        public int InspectionStatus { get; set; }
        public DateTime InspectionDate { get; set; }
        [ForeignKey("Yarn_TemporaryReceivingMaster")]
        public long YarnTempRecID { get; set; }
        public int PermReceivingDone { get; set; }
        public int OutGateDone { get; set; }
        public string ReasonDescription { get; set; }
        public int InspectionType { get; set; }
        public long Yarn_POID { get; set; }
        public long YarnGateRecID { get; set; }
        public string InspectionNo { get; set; }
        public int? QualityDone { get; set; }
        public long? CompanyID { get; set; }
        public int? BusinessID { get; set; }
        public int? Qualitystatus { get; set; }
        public int? IsuanceStatus { get; set; }

        public virtual Yarn_TemporaryReceivingMaster Yarn_TemporaryReceivingMaster { get; set; }
        //public virtual ICollection<YarnIssuanceForQualityMaster> YarnIssuanceForQualityMaster { get; set; }
    }
}
