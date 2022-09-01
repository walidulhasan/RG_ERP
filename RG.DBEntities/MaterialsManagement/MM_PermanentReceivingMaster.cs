using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MM_PermanentReceivingMaster
    {
        [Key]
        public long PermRecMID { get; set; }
        public DateTime? PermRecDate { get; set; }
        [ForeignKey("MM_MaterialInspection_Master")]
        public long MIMID { get; set; }
        public int Status { get; set; }
        public string PermRecNo { get; set; }
        public long? POID { get; set; }
        public int flag { get; set; }
        public long? CompanyID { get; set; }
        public long? BusinessID { get; set; }

        public virtual MM_MaterialInspection_Master MM_MaterialInspection_Master { get; set; }
    }
}
