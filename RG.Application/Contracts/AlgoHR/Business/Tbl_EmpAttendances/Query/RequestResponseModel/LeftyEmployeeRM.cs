using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_EmpAttendances.Query.RequestResponseModel
{
    public class LeftyEmployeeRM
    {
        public long EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string AlgoCode { get; set; }
        public string EmployeeName { get; set; }
        public string Emp_Appointment { get; set; }
        public string DepartmentName { get; set; }
        public string DesignationName { get; set; }
        public string SectionName { get; set; }
        public string DivisionName { get; set; }
        public string AbsentFromDate { get; set; }
        public int NoOfAbsentDays { get; set; }

    }
}
