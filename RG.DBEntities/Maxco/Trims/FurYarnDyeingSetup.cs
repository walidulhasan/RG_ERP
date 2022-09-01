using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class FurYarnDyeingSetup
    {
        public FurYarnDyeingSetup()
        {
            FurYarnSpecification = new HashSet<FurYarnSpecification>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FurYarnSpecification> FurYarnSpecification { get; set; }
    }
}
