using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class MarkerMakingMarkerRange
    {
        public int Id { get; set; }
        public MarkerMakingMarkerRange()
        {
            MarkerMakingRatio = new HashSet<MarkerMakingRatio>();
        }

        public long RangeId { get; set; }
        public long MarkerId { get; set; }
        public int NoOfLayer { get; set; }
        public double? Kgs { get; set; }
        public double? Meters { get; set; }

        public virtual MarkerMakingMarker Marker { get; set; }
        public virtual ICollection<MarkerMakingRatio> MarkerMakingRatio { get; set; }
    }
}
