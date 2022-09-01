using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DyedStockAdjustmentMaster
    {
        [Key]
        public long Said { get; set; }
        public string Sano { get; set; }
        public DateTime Sadate { get; set; }
        public long? UserId { get; set; }
    }
}
