using System;
using System.Collections.Generic;

using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class WovenComposition_Setup
    {
        public WovenComposition_Setup()
        {
            FabricSpecification = new HashSet<FabricSpecification>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FabricSpecification> FabricSpecification { get; set; }
    }
}
