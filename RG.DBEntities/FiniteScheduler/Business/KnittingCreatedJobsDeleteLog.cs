using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class KnittingCreatedJobsDeleteLog
    {
        public long? JobId { get; set; }
        public long? YarnKnittingContractId { get; set; }
        public double? Quantity { get; set; }
        public int? JobStatusId { get; set; }
        public string JobName { get; set; }
        public long? MachineId { get; set; }
        public long? StartingDayMinuteId { get; set; }
        public long? EndingDayMinuteId { get; set; }
        public DateTime? CreationDate { get; set; }
        public double? ProcessRate { get; set; }
        public string Comments { get; set; }
        public short? UserId { get; set; }
        public DateTime? DeletionDate { get; set; }
    }
}
