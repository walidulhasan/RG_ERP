using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class CadcamMarkerRatio
    {
        public long Id { get; set; }
        public long? DispatchId { get; set; }
        public long? SizeId { get; set; }
        public double? MarkerRatio { get; set; }
        public double? MarkerId { get; set; }
    }
}
