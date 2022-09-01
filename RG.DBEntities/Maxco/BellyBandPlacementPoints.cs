using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class BellyBandPlacementPoints
    {
        public long Id { get; set; }
        public long PlacementId { get; set; }
        public long BellyBandId { get; set; }
    }
}
