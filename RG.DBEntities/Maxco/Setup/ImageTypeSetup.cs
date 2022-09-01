using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class ImageTypeSetup
    {
        public ImageTypeSetup()
        {
            StyleImage = new HashSet<StyleImage>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<StyleImage> StyleImage { get; set; }
    }
}
