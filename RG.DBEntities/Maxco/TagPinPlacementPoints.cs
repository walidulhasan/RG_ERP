using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TagPinPlacementPoints
    {
        public int Id { get; set; }
        public int PlacementId { get; set; }
        public int Size { get; set; }
        public int TagPinId { get; set; }
    }
}
