using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class BuckleMaterial_Setup
    {
        public BuckleMaterial_Setup()
        {
            BuckleImage_Setup = new HashSet<BuckleImage_Setup>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<BuckleImage_Setup> BuckleImage_Setup { get; set; }
    }
}
