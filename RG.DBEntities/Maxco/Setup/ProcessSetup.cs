using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class ProcessSetup
    {
        public int Id { get; set; }
        public int ProcessId { get; set; }
        public string ProcessName { get; set; }
        public double StandardLabourRatePerMinute { get; set; }
        public string Currency { get; set; }
        public int? GeId { get; set; }
        public int? Active { get; set; }
    }
}
