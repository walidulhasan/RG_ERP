using RG.DBEntities.Maxco.Trims;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class DrawstringMaterial_Setup
    {
        public DrawstringMaterial_Setup()
        {
            DrawstringImage_Setup = new HashSet<DrawstringImage_Setup>();
            DrawstringSpecification = new HashSet<DrawstringSpecification>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<DrawstringImage_Setup> DrawstringImage_Setup { get; set; }
        public virtual ICollection<DrawstringSpecification> DrawstringSpecification { get; set; }
    }
}
