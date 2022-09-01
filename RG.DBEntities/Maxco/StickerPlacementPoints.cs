using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class StickerPlacementPoints
    {
        public int Id { get; set; }
        public int PlacementId { get; set; }
        public int? NumberPerPlacement { get; set; }
        public int StickerId { get; set; }
        public string Position { get; set; }
        public int? SideUnitId { get; set; }
        public double? SideFrom { get; set; }
        public double? SideTo { get; set; }
        public int? TopBottomUnitId { get; set; }
        public double? TopBottomFrom { get; set; }
        public double? TopBottomTo { get; set; }
    }
}
