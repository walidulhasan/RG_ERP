using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class HangTagType_Setup
    {
        public HangTagType_Setup()
        {
            HangTagImageSetup = new HashSet<HangTagImage_Setup>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<HangTagImage_Setup> HangTagImageSetup { get; set; }
    }
}
