using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco
{
    public partial class TrimIssueMaster
    {
        public TrimIssueMaster()
        {
            TrimIssueDetail = new HashSet<TrimIssueDetail>();
        }
        public int Id { get; set; }
        public int TrimIssueMid { get; set; }
        public DateTime IssueDate { get; set; }
        public int? UnitDeptId { get; set; }
        public string OrderNo { get; set; }
        public string OutGatePass { get; set; }
        public string ReceivingPerson { get; set; }
        public int? TrimIssuePurposeId { get; set; }
        public int? ReasonId { get; set; }
        public string Destination { get; set; }
        public string VehicleNo { get; set; }

        public virtual ReasonSetup Reason { get; set; }
        public virtual TrimIssuePurposeSetup TrimIssuePurpose { get; set; }
        public virtual UnitDepartmentSetup UnitDept { get; set; }
        public virtual ICollection<TrimIssueDetail> TrimIssueDetail { get; set; }
    }
}
