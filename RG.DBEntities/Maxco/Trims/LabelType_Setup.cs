using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class LabelType_Setup
    {
        public LabelType_Setup()
        {
            LabelImageSetup = new HashSet<LabelImage_Setup>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<LabelImage_Setup> LabelImageSetup { get; set; }
    }
}
