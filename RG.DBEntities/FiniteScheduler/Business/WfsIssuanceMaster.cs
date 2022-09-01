using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WfsIssuanceMaster
    {
        public long IssuanceId { get; set; }
        public long JobId { get; set; }
        public DateTime IssuanceDate { get; set; }
        public string Comments { get; set; }
    }
}
