using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblKnittingYarnAssignment
    {
        public long AssignmentId { get; set; }
        public long YarnKncontractId { get; set; }
        public DateTime AssignmentDate { get; set; }
        public long SubPickListId { get; set; }
    }
}
