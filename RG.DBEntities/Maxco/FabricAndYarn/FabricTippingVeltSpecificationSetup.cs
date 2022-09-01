using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricTippingVeltSpecificationSetup
    {
        public long Id { get; set; }
        public double? Width { get; set; }
        public double? DistanceFromOuterEdge { get; set; }
        public int TippingVeltNo { get; set; }
        public long FabricSpecificationId { get; set; }
        public bool? IsTipping { get; set; }
    }
}
