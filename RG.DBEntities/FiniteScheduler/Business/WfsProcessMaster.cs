using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WfsProcessMaster
    {
        public WfsProcessMaster()
        {
            WfsJobMaster = new HashSet<WfsJobMaster>();
            WfsProcessDetail = new HashSet<WfsProcessDetail>();
        }

        public long ProcessMasterId { get; set; }
        public int ProcessId { get; set; }
        public string ProcessName { get; set; }
        public int? ProcessSequence { get; set; }
        public long ReceivingMasterId { get; set; }
        public int MachineTypeId { get; set; }

        public virtual ICollection<WfsJobMaster> WfsJobMaster { get; set; }
        public virtual ICollection<WfsProcessDetail> WfsProcessDetail { get; set; }
    }
}
