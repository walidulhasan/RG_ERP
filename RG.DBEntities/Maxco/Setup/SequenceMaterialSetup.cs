using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class SequenceMaterialSetup
    {
        public SequenceMaterialSetup()
        {
            SequenceImageSetup = new HashSet<SequenceImageSetup>();
            SequenceMaterial = new HashSet<SequenceMaterial>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SequenceImageSetup> SequenceImageSetup { get; set; }
        public virtual ICollection<SequenceMaterial> SequenceMaterial { get; set; }
    }
}
