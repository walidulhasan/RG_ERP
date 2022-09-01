using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WashingActivityProcess
    {
        public long? FabricCategoryId { get; set; }
        public long? ActivityId { get; set; }
        public long? ProcessId { get; set; }
        public long? SetupCodeId { get; set; }
    }
}
