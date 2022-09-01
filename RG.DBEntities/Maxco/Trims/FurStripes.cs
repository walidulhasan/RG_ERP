using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class FurStripes
    {
        public int Id { get; set; }
        public long FurId { get; set; }
        public double Width { get; set; }
        public double DistanceFromOuterEdge { get; set; }
        public int FurYarnId { get; set; }

        public virtual FurSpecification Fur { get; set; }
    }
}
