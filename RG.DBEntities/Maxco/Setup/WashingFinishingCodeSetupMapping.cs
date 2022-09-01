using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class WashingFinishingCodeSetupMapping
    {
        public int Id { get; set; }
        public long WashingFinishingCodeSetupId { get; set; }
        public int ProcessId { get; set; }

        public virtual WashingFinishingCodeSetup WashingFinishingCodeSetup { get; set; }
    }
}
