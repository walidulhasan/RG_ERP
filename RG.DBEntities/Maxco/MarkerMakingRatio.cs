using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class MarkerMakingRatio
    {
        public int Id { get; set; }
        public long RangeId { get; set; }
        public int Ratio { get; set; }
        public long SizeId { get; set; }
        public int Quantity { get; set; }
        public long? ShellColorSetId { get; set; }
        public long? FabricId { get; set; }

        public virtual MarkerMakingMarkerRange Range { get; set; }
    }
}
