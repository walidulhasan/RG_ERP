using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class HeadPinPlacementPoints
    {
        public int Id { get; set; }
        public string PlacementId { get; set; }
        public int Number { get; set; }
        public int? SizeId { get; set; }
        public int? HeadPinId { get; set; }
    }
}
