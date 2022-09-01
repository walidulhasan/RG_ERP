using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblStockAdjustment
    {
        [Key]
        public long AdjustmentId { get; set; }
        public int UserId { get; set; }
        public long CompanyId { get; set; }
        public int Deleted { get; set; }
        public long AdjustmentNo { get; set; }
        public int? DocumentTypeId { get; set; }
        public long? DocumentNo { get; set; }
    }
}
