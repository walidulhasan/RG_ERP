using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CottonInspectionQualityMaster
    {
        [Key]
        public long InspectionQualityId { get; set; }
        public long? InspectionQuantityId { get; set; }
        public string InspectionQualityNo { get; set; }
        public int? PermRecStatus { get; set; }
        public long? ContractId { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? UserId { get; set; }
    }
}
