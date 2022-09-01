using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblKnittingLoads
    {
        public long LoadId { get; set; }
        public long MachineId { get; set; }
        public long DayMinuteId { get; set; }
        public long KnittingJobId { get; set; }
        public int Status { get; set; }
    }
}
