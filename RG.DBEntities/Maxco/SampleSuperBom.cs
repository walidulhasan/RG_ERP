using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class SampleSuperBom
    {
        public SampleSuperBom()
        {
            SampleBom = new HashSet<SampleBom>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public byte Level { get; set; }
        public short SamplingItemCode { get; set; }
        public bool IsMaterial { get; set; }
        public byte? SequenceNo { get; set; }
        public int? ParentId { get; set; }

        public virtual ICollection<SampleBom> SampleBom { get; set; }
    }
}
