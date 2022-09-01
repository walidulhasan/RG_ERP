using RG.DBEntities.Maxco.Trims;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class DrawstringType_Setup
    {
        public DrawstringType_Setup()
        {
            DrawstringImage_Setup = new HashSet<DrawstringImage_Setup>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<DrawstringImage_Setup> DrawstringImage_Setup { get; set; }
    }
}
