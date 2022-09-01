using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class FurMaterialSetup
    {
        public FurMaterialSetup()
        {
            FurImageSetup = new HashSet<FurImageSetup>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FurImageSetup> FurImageSetup { get; set; }
    }
}
