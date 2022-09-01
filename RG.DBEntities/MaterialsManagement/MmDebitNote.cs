using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmDebitNote
    {
        public MmDebitNote()
        {
            MmDebitNoteDetail = new HashSet<MmDebitNoteDetail>();
        }
        [Key]
        public long Dnid { get; set; }
        public string Dnno { get; set; }
        public int Status { get; set; }

        public virtual ICollection<MmDebitNoteDetail> MmDebitNoteDetail { get; set; }
    }
}
