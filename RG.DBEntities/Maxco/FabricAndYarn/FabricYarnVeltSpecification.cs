using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricYarnVeltSpecification
    {
        public int Id { get; set; }
        public long FabricYarnSpecificationId { get; set; }
        public float Width { get; set; }
        public float DistnaceFromOuterEdge { get; set; }

        public virtual FabricYarnSpecification FabricYarnSpecification { get; set; }
    }
}
