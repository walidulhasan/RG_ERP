using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricFinishBusinessRuleSetup
    {
        public int Id { get; set; }
        public byte FinishingId { get; set; }
        public short QualityId { get; set; }

        public virtual FabricFinishingSetup Finishing { get; set; }
    }
}
