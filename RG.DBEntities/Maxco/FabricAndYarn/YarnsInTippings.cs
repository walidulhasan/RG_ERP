using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class YarnsInTippings
    {
        public int Id { get; set; }
        public int FabricTippingId { get; set; }
        public int TwistLevelId { get; set; }
    }
}
