using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CottonPermanentReceivingMaster
    {
        [Key]
        public long PermRecId { get; set; }
        public long InspectionQualityId { get; set; }
        public DateTime CreationDate { get; set; }
        public long ContractId { get; set; }
        public int UserId { get; set; }
    }
}
