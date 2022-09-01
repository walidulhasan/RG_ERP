using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricTieSpotDyeColors
    {
        public int Id { get; set; }
        public long ColorSetId { get; set; }
        public string Color { get; set; }

        public virtual FabricSpecificationColor ColorSet { get; set; }
    }
}
