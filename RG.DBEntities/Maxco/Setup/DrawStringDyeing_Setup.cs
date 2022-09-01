using RG.DBEntities.Maxco.Trims;
using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Setup
{
    public class DrawStringDyeing_Setup
    {
        public DrawStringDyeing_Setup()
        {
            DrawstringSpecification = new HashSet<DrawstringSpecification>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<DrawstringSpecification> DrawstringSpecification { get; set; }
    }
}
