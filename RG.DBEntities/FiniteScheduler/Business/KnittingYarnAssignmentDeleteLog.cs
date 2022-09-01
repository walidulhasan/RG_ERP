using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class KnittingYarnAssignmentDeleteLog
    {
        public long? AssignmentId { get; set; }
        public long? YarnKncontractId { get; set; }
        public DateTime? AssignmentDate { get; set; }
        public long? SubPickListId { get; set; }
        public string Comments { get; set; }
        public short? UserId { get; set; }
        public DateTime? DeletionDate { get; set; }
    }
}
