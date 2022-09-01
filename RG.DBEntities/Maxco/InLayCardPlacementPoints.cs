using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class InLayCardPlacementPoints
    {
        public int Id { get; set; }
        public int InLayCardId { get; set; }
        public int PlacementId { get; set; }
    }
}
