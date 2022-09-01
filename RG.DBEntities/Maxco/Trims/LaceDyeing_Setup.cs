using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class LaceDyeing_Setup
    {
        public LaceDyeing_Setup()
        {
            LaceSpecification = new HashSet<LaceSpecification>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<LaceSpecification> LaceSpecification { get; set; }
    }
}
