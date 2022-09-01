using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class ChordholderSizeSetup
    {
        public ChordholderSizeSetup()
        {
            ChordHolderSpecification = new HashSet<ChordHolderSpecification>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ChordHolderSpecification> ChordHolderSpecification { get; set; }
    }
}
