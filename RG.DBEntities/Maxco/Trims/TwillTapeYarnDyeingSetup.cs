using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class TwillTapeYarnDyeingSetup
    {
        public TwillTapeYarnDyeingSetup()
        {
            TwillTapeYarnSpecification = new HashSet<TwillTapeYarnSpecification>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TwillTapeYarnSpecification> TwillTapeYarnSpecification { get; set; }
    }
}
