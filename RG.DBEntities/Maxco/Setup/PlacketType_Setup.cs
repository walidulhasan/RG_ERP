using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Trims;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class PlacketType_Setup
    {
        public PlacketType_Setup()
        {
            FabricTrimSpecification = new HashSet<FabricTrimSpecification>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FabricTrimSpecification> FabricTrimSpecification { get; set; }
    }
}
