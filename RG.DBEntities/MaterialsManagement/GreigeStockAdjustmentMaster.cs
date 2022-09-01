using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class GreigeStockAdjustmentMaster
    {
        [Key]
        public int Said { get; set; }
        public string Sano { get; set; }
        public DateTime? Sadate { get; set; }
        public int? UserId { get; set; }
    }
}
