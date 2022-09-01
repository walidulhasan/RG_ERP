using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MM_PartialRequisition_Detail
    {
        [Key]
        public long ReqDetailID { get; set; }
        [ForeignKey("MM_PartialRequisition_Master")]
        public long? ReqMasterID { get; set; }
        public long? AttributeInstanceID { get; set; }
        public decimal? ReqQuantity { get; set; }
        public int? UnitID { get; set; }
        public long? ModelID { get; set; }
        public int? MRPItemCode { get; set; }
        public string MRPItemName { get; set; }
        public string SizeRearks { get; set; }
        public virtual MM_PartialRequisition_Master MM_PartialRequisition_Master { get; set; }
    }
}
