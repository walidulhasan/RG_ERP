using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.FiniteScheduler.Setup.ApprovalConfiguration
{
   public class ApprovalConfigDetailVM
    {
        public int ConfigDetailID { get; set; }
        public int ConfigMasterID { get; set; }
        public int? ApprovalLevel { get; set; }
        public int? ApproverCompanyID { get; set; }
        public int? ApproverOfficeID { get; set; }
        public int? ApproverOfficeDivisionID { get; set; }
        public int? ApproverDepartmentID { get; set; }
        public int? ApproverSectionID { get; set; }
        public int ApproverJobTitleID { get; set; }
        public int? ApproverEmployeeID { get; set; }
        public bool? IsApproverInSelfOffice { get; set; }
    }
}
