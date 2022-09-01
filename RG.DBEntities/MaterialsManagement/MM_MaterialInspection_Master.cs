using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MM_MaterialInspection_Master
    {
        public MM_MaterialInspection_Master()
        {
              MM_PermanentReceivingMaster = new HashSet<MM_PermanentReceivingMaster>();
        }
        [Key]
        public long MIMID { get; set; }
        [ForeignKey("MM_TempReceivingMaster")]
        public long MTRMID { get; set; }
        public string MINSNO { get; set; }
        public DateTime? InspectionDate { get; set; }
        public int POID { get; set; }
        public int GRNStatus { get; set; }
        public int? OutGatePassStatus { get; set; }
        public int flag { get; set; }
        public long? CompanyID { get; set; }
        public long? BusinessID { get; set; }

        public virtual MM_TempReceivingMaster MM_TempReceivingMaster { get; set; }
        public virtual ICollection<MM_PermanentReceivingMaster> MM_PermanentReceivingMaster { get; set; }
    }
}
