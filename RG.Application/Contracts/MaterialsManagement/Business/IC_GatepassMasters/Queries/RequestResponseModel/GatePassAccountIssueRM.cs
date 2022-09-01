using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries.RequestResponseModel
{
    public class GatePassAccountIssueRM
    {
        public byte? CategoryID { get; set; }
        public long GatePassID { get; set; }
        public string CategoryName { get; set; }
        public string SerialNo { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedTime { get; set; }
        public string Department { get; set; }
        public string CreatedBy { get; set; }
        public string Status { get; set; }
        public bool? IsApprovedByAccounts { get; set; }
        public string AccountsApprovedBy { get; set; }
        public string AccountsApprovalDate { get; set; }
        public int CA_UserID { get; set; }
        public string CreatedEmployee { get; set; }
        public string CreatedEmployeeDept { get; set; }
        public string CreatedEmployeeDesig { get; set; }
    }
}
