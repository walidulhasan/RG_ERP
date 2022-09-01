using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class YarnIssueMaster
    {
        public YarnIssueMaster()
        {
            YarnIssueDetail = new HashSet<YarnIssueDetail>();
        }
        [Key]
        public int YarnIssueMid { get; set; }
        public DateTime IssueDate { get; set; }
        public string GatePassNo { get; set; }
        public string ReceivingPerson { get; set; }
        public string Remarks { get; set; }
        public int? Knitter { get; set; }
        public string KnittingContractNo { get; set; }
        public string InspectionLab { get; set; }
        public string ReasonId { get; set; }
        public string Source { get; set; }
        public string FabricInformation { get; set; }
        public string ProgramNo { get; set; }
        public string VehicleNo { get; set; }
        public string DriverName { get; set; }

        public virtual ICollection<YarnIssueDetail> YarnIssueDetail { get; set; }
    }
}
