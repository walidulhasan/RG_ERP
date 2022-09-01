using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricFinishingProcessSpecification
    {
        public int Id { get; set; }
        public byte FinishingProcessId { get; set; }
        public long FabricSpecificationId { get; set; }

        public virtual FabricSpecification FabricSpecification { get; set; }
    }
}
