using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmDebitNoteDetail
    {
        [Key]
        public long Dndid { get; set; }
        public long Dnid { get; set; }
        public long Iid { get; set; }

        public virtual MmDebitNote Dn { get; set; }
    }
}
