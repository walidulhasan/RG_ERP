using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricTieSpotDyeColorsSetup
    {
        public long Id { get; set; }
        public long ColorSetId { get; set; }
        public string Color { get; set; }
    }
}
