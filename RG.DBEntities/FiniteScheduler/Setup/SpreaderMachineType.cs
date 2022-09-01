using RG.DBEntities.FiniteScheduler.Business;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class SpreaderMachineType
    {
        public SpreaderMachineType()
        {
            SpreaderInstance = new HashSet<SpreaderInstance>();
            SpreadingLeadTime = new HashSet<SpreadingLeadTime>();
        }

        public string SpreaderTypeName { get; set; }
        public int FamId { get; set; }
        public int FamparentId { get; set; }

        public virtual ICollection<SpreaderInstance> SpreaderInstance { get; set; }
        public virtual ICollection<SpreadingLeadTime> SpreadingLeadTime { get; set; }
    }
}
