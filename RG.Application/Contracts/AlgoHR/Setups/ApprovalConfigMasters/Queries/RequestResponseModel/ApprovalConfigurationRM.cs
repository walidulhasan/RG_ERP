using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.ApprovalConfigMasters.Queries.RequestResponseModel
{
   public class ApprovalConfigurationRM
    {
        public int ConfigMasterID { get; set; }
        public string ModuleName { get; set; }
        public int ConfigDetailID { get; set; }
        public int ApprovalLevel { get; set; }
        public int ApproverCompanyID { get; set; }
        public string ApproverCompany { get; set; }
        public int ApproverOfficeDivisionID { get; set; }
        public string ApproverOfficeDivision { get; set; }
        public int ApproverDepartmentID { get; set; }
        public string ApproverDepartment { get; set; }
        public int ApproverSectionID { get; set; }
        public string ApproverSection { get; set; }
        public int ApproverJobTitleID { get; set; }
        public string ApproverJobTitle { get; set; }
        public int ApproverEmployeeID { get; set; }
        public string ApproverEmployee { get; set; }
    }
}
