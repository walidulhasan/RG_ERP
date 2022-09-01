using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class TwillTapeStripes
    {
        public int Id { get; set; }
        public long TwillTapeId { get; set; }
        public double Width { get; set; }
        public double DistanceFromOuterEdge { get; set; }
        public int TwillTapeYarnId { get; set; }

        public virtual TwillTapeSpecification TwillTape { get; set; }
    }
}
