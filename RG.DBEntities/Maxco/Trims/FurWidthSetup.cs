using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class FurWidthSetup
    {
        public FurWidthSetup()
        {
            FurSpecification = new HashSet<FurSpecification>();
        }

        public byte Id { get; set; }
        public double Description { get; set; }

        public virtual ICollection<FurSpecification> FurSpecification { get; set; }
    }
}
