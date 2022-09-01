using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WashingActivity
    {
        public long WashingActivityId { get; set; }
        public string WashingActivityName { get; set; }
        public DateTime WashingActivityDate { get; set; }
    }
}
