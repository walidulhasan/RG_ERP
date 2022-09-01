using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblIwadjustmentMaster
    {
        [Key]
        public long IwadjustmentId { get; set; }
        public long IwadjustmentNo { get; set; }
        public long CompanyId { get; set; }
        public int UserId { get; set; }
        public DateTime IwadjustmentDate { get; set; }
        public string IwadjComments { get; set; }
        public int Deleted { get; set; }
    }
}
