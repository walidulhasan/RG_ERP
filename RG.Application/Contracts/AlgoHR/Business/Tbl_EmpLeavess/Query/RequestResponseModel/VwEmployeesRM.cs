using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_EmpLeavess.Query.RequestResponseModel
{
    public class VwEmployeesRM
    {
        public long LeaveApplicationID { get; set; }
        public long Emp_ID { get; set; }
        public char Emp_Cd { get; set; }
        public string Emp_Name { get; set; }
        public DateTime Emp_Appointment { get; set; }
        public string LeaveType { get; set; }
        public bool Leave_Approved { get; set; }
        public string Leave_Reason { get; set; }
        public string Leave_Address { get; set; }
        public DateTime Leave_From { get; set; }
        public DateTime Leave_To { get; set; }
        public int Cmp_ID { get; set; }
        public int EmbroCompanyID { get; set; }
        public int Cmp_ShortName { get; set; }
        public string Division_Name { get; set; }
        public string Dept_Name { get; set; }
        public string Section_Name { get; set; }
        public string Designation_Name { get; set; }
        public bool IsAdjusted { get; set; }
        public DateTime OriginalLeave_From { get; set; }
        public DateTime OriginalLeave_To { get; set; }
    }
}
