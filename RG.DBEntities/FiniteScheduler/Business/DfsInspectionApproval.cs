using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class DfsInspectionApproval
    {
        public int InspectionApprovalId { get; set; }
        public string InspectionApprovalNo { get; set; }
        public DateTime InspectionApprovalDate { get; set; }
        public int UserId { get; set; }
        public int ConformationId { get; set; }
        public int LotId { get; set; }
        public int AgencyId { get; set; }
        public int Status { get; set; }
    }
}
