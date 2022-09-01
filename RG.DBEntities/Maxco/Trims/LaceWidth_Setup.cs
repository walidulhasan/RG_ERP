using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class LaceWidth_Setup
    {
        public LaceWidth_Setup()
        {
            LaceSpecification = new HashSet<LaceSpecification>();
        }

        public int ID { get; set; }
        public double Description { get; set; }

        public virtual ICollection<LaceSpecification> LaceSpecification { get; set; }
    }
}
