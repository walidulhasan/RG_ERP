using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricFeederStripeSpecificationSetup
    {
        public long Id { get; set; }
        public long YarnSpecificationId { get; set; }
        public byte StripeNo { get; set; }
    }
}
