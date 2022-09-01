using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricTippingVeltSpecification
    {
        public FabricTippingVeltSpecification()
        {
            FabricTippingColor = new HashSet<FabricTippingColor>();
            FabricTippingYarn = new HashSet<FabricTippingYarn>();
        }

        public int Id { get; set; }
        public double? Width { get; set; }
        public double? DistanceFromOuterEdge { get; set; }
        public byte TippingVeltNo { get; set; }
        public long FabricSpecificationId { get; set; }
        public bool? IsTipping { get; set; }
        public double? FoldingDistance { get; set; }

        public virtual FabricSpecification FabricSpecification { get; set; }
        public virtual ICollection<FabricTippingColor> FabricTippingColor { get; set; }
        public virtual ICollection<FabricTippingYarn> FabricTippingYarn { get; set; }
    }
}
