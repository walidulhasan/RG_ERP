using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class JetClipPlacementPoints
    {
        public int Id { get; set; }
        public int PlacementId { get; set; }
        public int? SizeId { get; set; }
        public string Number { get; set; }
        public int JetClipId { get; set; }
    }
}
