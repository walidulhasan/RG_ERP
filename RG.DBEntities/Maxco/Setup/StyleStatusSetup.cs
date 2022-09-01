using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class StyleStatusSetup
    {
        public StyleStatusSetup()
        {
            StyleStatusUrl = new HashSet<StyleStatusUrl>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<StyleStatusUrl> StyleStatusUrl { get; set; }
    }
}
