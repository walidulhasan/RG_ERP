using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class StringPlacementPoints
    {
        public int Id { get; set; }
        public int? PlacementId { get; set; }
        public int? SizeId { get; set; }
        public int? Number { get; set; }
        public int? StringId { get; set; }
    }
}
