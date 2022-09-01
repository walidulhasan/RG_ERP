using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsEmployeeLineAllocationDetail
    {
        public long Id { get; set; }
        public long AllocationId { get; set; }
        public long OperationId { get; set; }
        public long MachineId { get; set; }
        public int InstanceNo { get; set; }
        public string EmployeeCode { get; set; }
        public string MachineBarcode { get; set; }
        public DateTime? PunchTime { get; set; }
        public long? SequenceNo { get; set; }
        public int? OperatorId { get; set; }

        public virtual SfsEmployeeLineAllocation Allocation { get; set; }
    }
}
