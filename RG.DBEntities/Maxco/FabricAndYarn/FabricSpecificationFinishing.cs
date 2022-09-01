using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricSpecificationFinishing
    {
        public int Id { get; set; }
        public long FabricSpecificationId { get; set; }
        public byte FinishingId { get; set; }

        public virtual FabricSpecification FabricSpecification { get; set; }
        public virtual FabricFinishingSetup Finishing { get; set; }
    }
}
