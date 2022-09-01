using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class VelcroDyeingSetup
    {
        public VelcroDyeingSetup()
        {
            VelcroSpecification = new HashSet<VelcroSpecification>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<VelcroSpecification> VelcroSpecification { get; set; }
    }
}
