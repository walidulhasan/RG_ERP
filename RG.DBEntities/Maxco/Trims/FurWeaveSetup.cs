using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class FurWeaveSetup
    {
        public FurWeaveSetup()
        {
            FurSpecification = new HashSet<FurSpecification>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FurSpecification> FurSpecification { get; set; }
    }
}
