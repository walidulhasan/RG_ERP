using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblKnittingJobsOld
    {
        public long JobId { get; set; }
        public long YarnKnittingContractId { get; set; }
        public double Quantity { get; set; }
        public int JobStatusId { get; set; }
        public string JobName { get; set; }
        public long? MachineId { get; set; }
        public string StartTime { get; set; }
        public string StartDate { get; set; }
        public string EndTime { get; set; }
        public long? StartWcdayId { get; set; }
        public int? StartMinuteId { get; set; }
        public long? EndWcdayId { get; set; }
        public int? EndMinuteId { get; set; }
        public DateTime? CreationDate { get; set; }
        public double? ProcessRate { get; set; }
    }
}
