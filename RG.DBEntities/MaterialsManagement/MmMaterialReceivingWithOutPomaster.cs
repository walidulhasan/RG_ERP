using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmMaterialReceivingWithOutPomaster
    {
        [Key]
        public int RecWithOutPoid { get; set; }
        public int PspoId { get; set; }
        public DateTime? RecWithOutPodate { get; set; }

        public virtual MmPreSystemPos Pspo { get; set; }
    }
}
