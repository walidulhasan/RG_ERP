using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblRecievingwithPo
    {
        [Key]
        public long Prid { get; set; }
        public DateTime? Prdate { get; set; }
        public string Prno { get; set; }
        public long? CompId { get; set; }
        public long? Poid { get; set; }
        public long? Minid { get; set; }
        public int? UserId { get; set; }
        public int? Deleted { get; set; }

        public virtual CmblInspectionMain Min { get; set; }
        public virtual CMBL_PurchaseOrder Po { get; set; }
    }
}
