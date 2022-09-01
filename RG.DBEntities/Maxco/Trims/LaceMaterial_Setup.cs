using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class LaceMaterial_Setup
    {
        public LaceMaterial_Setup()
        {
            LaceImage_Setup = new HashSet<LaceImage_Setup>();
            LaceSpecification = new HashSet<LaceSpecification>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<LaceImage_Setup> LaceImage_Setup { get; set; }
        public virtual ICollection<LaceSpecification> LaceSpecification { get; set; }
    }
}
