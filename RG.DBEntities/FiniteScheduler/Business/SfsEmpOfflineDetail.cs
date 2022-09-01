using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsEmpOfflineDetail
    {
        public int Id { get; set; }
        public int AllocationId { get; set; }
        public DateTime PunchTime { get; set; }
        public int DesignationId { get; set; }
        public int UnitId { get; set; }
        public int Division { get; set; }
        public double Qty { get; set; }
        public double Data { get; set; }
        public int? OperatorId { get; set; }

        public virtual SfsEmpOfflineAllocationMaster Allocation { get; set; }
    }
}
