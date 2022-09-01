using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class KnittingMachineJobsDeleteLog
    {
        public long? LoadId { get; set; }
        public long? MachineId { get; set; }
        public long? DayMinuteId { get; set; }
        public long? KnittingJobId { get; set; }
        public int? Status { get; set; }
        public string Comments { get; set; }
        public short? UserId { get; set; }
        public DateTime? DeletionDate { get; set; }
    }
}
