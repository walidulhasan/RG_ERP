using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class ChordholderMaterialSetup
    {
        public ChordholderMaterialSetup()
        {
            ChordholderImageSetup = new HashSet<ChordholderImageSetup>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ChordholderImageSetup> ChordholderImageSetup { get; set; }
    }
}
