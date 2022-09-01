using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CottonOpeningBalanceMaster
    {
        [Key]
        public long Obid { get; set; }
        public string Obno { get; set; }
        public DateTime? Obdate { get; set; }
        public string PocontractNo { get; set; }
    }
}
