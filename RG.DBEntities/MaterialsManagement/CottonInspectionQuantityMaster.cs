using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CottonInspectionQuantityMaster
    {
        [Key]
        public long InspectionQuantityId { get; set; }
        public long Trid { get; set; }
        public string InspectionQuantityNo { get; set; }
        public int InspectionQualityStatus { get; set; }
        public long ContractId { get; set; }
        public DateTime CreationDate { get; set; }
        public int? UserId { get; set; }
    }
}
