using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_EmpLeavess.Query.RequestResponseModel
{
    public class SearchedLeaveListRM
    {
        public long LeaveApplicationID { get; set; }
        public long? EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string DivisionName { get; set; }
        public string DepartmentName { get; set; }
        public string Designation { get; set; }
        public int? LeaveID { get; set; }
        public string LeaveType { get; set; }
        public string LeaveFrom { get; set; }
        public string LeaveTo { get; set; }
        public string LeaveReason { get; set; }
        public int ApprovalMasterID { get; set; }
        public int ApprovalDetailID { get; set; }
        public int ApprovalLevel { get; set; }
        public string ApproverEmployeeCode { get; set; }
        public string ApproverEmployeeName { get; set; }
        public bool? IsChecked { get; set; }

        public string FirstApprover { get; set; }
        public bool? FirstApproverIsChecked { get; set; }
        public string SecondApprover { get; set; }
        public bool? SecondApproverIsChecked { get; set; }
        public string ThirdApprover { get; set; }
        public bool? ThirdApproverIsChecked { get; set; }
        public string FourthApprover { get; set; }
        public bool? FourthApproverIsChecked { get; set; }
        public string LeaveStatus { get; set; }
    }
}
