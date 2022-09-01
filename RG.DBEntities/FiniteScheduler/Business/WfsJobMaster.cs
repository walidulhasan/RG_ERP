using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WfsJobMaster
    {
        public WfsJobMaster()
        {
            WfsJobChallan = new HashSet<WfsJobChallan>();
        }

        public long JobId { get; set; }
        public DateTime CreationDate { get; set; }
        public long ProcessMasterId { get; set; }
        public int? JobSequence { get; set; }
        public int JobStatusId { get; set; }
        public string ColorCode { get; set; }
        public int? StartDayId { get; set; }
        public int? StartTimeId { get; set; }
        public int? EndDayId { get; set; }
        public int? EndTimeId { get; set; }

        public virtual WfsProcessMaster ProcessMaster { get; set; }
        public virtual ICollection<WfsJobChallan> WfsJobChallan { get; set; }
    }
}
