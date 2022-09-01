using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmLcsDetailItems
    {
        [Key]
        public int LcsitemId { get; set; }
        public int? LcsmasterId { get; set; }
        public int? PoitemId { get; set; }
        public double? Lcsquantity { get; set; }
        public double? Lcsfcrate { get; set; }
        public double? LcsrevisedLcrate { get; set; }
    }
}
