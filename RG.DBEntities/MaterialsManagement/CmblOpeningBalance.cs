using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblOpeningBalance
    {
        [Key]
        public int Obid { get; set; }
        public DateTime Obdate { get; set; }
        public string UserId { get; set; }
        public long CompanyId { get; set; }
        public int Obno { get; set; }
        public int Deleted { get; set; }
    }
}
