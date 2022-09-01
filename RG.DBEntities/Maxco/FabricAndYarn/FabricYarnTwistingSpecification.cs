using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricYarnTwistingSpecification
    {
        public int Id { get; set; }
        public long FabricId { get; set; }
        public long Yarn1Id { get; set; }
        public long Yarn2Id { get; set; }

        public virtual FabricSpecification Fabric { get; set; }
        public virtual FabricYarnSpecification Yarn1 { get; set; }
    }
}
