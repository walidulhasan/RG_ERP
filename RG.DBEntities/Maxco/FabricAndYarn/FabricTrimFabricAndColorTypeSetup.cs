using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricTrimFabricAndColorTypeSetup
    {
        public FabricTrimFabricAndColorTypeSetup()
        {
            CollarSpecification = new HashSet<CollarSpecification>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<CollarSpecification> CollarSpecification { get; set; }
    }
}
