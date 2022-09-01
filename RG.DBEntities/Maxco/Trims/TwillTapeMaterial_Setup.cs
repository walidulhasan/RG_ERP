using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class TwillTapeMaterial_Setup
    {
        public TwillTapeMaterial_Setup()
        {
            TwillTapeImageSetup = new HashSet<TwillTapeImage_Setup>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TwillTapeImage_Setup> TwillTapeImageSetup { get; set; }
    }
}
