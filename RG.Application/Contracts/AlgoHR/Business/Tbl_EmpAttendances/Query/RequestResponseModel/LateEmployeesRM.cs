using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_EmpAttendances.Query.RequestResponseModel
{
    public class LateEmployeesRM
    {
        public long EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public int DivisionID { get; set; }

        public string DivisionName { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int SectionID { get; set; }
        public string SectionName { get; set; }
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
        public int LateCount { get; set; }
        public int SearchYear { get; set; }
        public int SearchMonth { get; set; }
        public int IssuedLateCount { get; set; }
    }
}
