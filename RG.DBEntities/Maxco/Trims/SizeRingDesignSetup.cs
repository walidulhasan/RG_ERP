using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class SizeRingDesignSetup
    {
        public SizeRingDesignSetup()
        {
            SizeRingImageSetup = new HashSet<SizeRingImageSetup>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SizeRingImageSetup> SizeRingImageSetup { get; set; }
    }
}
