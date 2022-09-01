using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class GreigeOpeningBalanceMaster
    {
        [Key]
        public long Obid { get; set; }
        public string Obno { get; set; }
        public DateTime? Obdate { get; set; }
    }
}
