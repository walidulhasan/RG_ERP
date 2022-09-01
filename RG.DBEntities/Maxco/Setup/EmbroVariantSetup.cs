using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class EmbroVariantSetup
    {
        public EmbroVariantSetup()
        {
            EmbroSpecification = new HashSet<EmbroSpecification>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<EmbroSpecification> EmbroSpecification { get; set; }
    }
}
