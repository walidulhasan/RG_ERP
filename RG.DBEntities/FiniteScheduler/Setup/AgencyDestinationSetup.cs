using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class AgencyDestinationSetup
    {
        public int Id { get; set; }
        public int FromMrpitemCode { get; set; }
        public int ToMrpitemCode { get; set; }
        public int? IsFlow { get; set; }
    }
}
