using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblReturnToSupplier
    {
        [Key]
        public long Rtsid { get; set; }
        public long Rtsno { get; set; }
        public long CompanyId { get; set; }
        public long UserId { get; set; }
        public int? Deleted { get; set; }
        public string Rpname { get; set; }
        public string Comments { get; set; }
        public DateTime Rtsdate { get; set; }
    }
}
