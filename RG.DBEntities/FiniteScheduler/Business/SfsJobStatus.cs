using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsJobStatus
    {
        public SfsJobStatus()
        {
            SfsJob = new HashSet<SfsJob>();
        }

        public int StatusId { get; set; }
        public string Description { get; set; }
        public string ColorCode { get; set; }

        public virtual ICollection<SfsJob> SfsJob { get; set; }
    }
}
