using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class BuckleSize_Setup
    {
        public BuckleSize_Setup()
        {
            BuckleSpecification = new HashSet<BuckleSpecification>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<BuckleSpecification> BuckleSpecification { get; set; }
    }
}
