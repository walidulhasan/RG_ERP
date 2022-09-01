using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco
{
    public partial class GreigeFabricTippingVeltSpecification
    {
        public GreigeFabricTippingVeltSpecification()
        {
            GreigeFabricTiipingColor = new HashSet<GreigeFabricTiipingColor>();
            GreigeFabricTippingYarn = new HashSet<GreigeFabricTippingYarn>();
        }

        public int Id { get; set; }
        public double? Width { get; set; }
        public double? DistanceFromOuterEdge { get; set; }
        public byte TippingVeltNo { get; set; }
        public int GreigeFabricSpecificationId { get; set; }
        public bool? IsTipping { get; set; }
        public double? FoldingDistance { get; set; }

        public virtual GreigeFabricCode_Setup GreigeFabricSpecification { get; set; }
        public virtual ICollection<GreigeFabricTiipingColor> GreigeFabricTiipingColor { get; set; }
        public virtual ICollection<GreigeFabricTippingYarn> GreigeFabricTippingYarn { get; set; }
    }
}
