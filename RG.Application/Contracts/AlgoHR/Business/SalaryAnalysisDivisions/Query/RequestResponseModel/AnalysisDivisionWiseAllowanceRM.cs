using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.SalaryAnalysisDivisions.Query.RequestResponseModel
{
    public class AnalysisDivisionWiseAllowanceRM
    {
        public long EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeOldCode { get; set; }
        public string EmployeeName { get; set; }
        public string Division { get; set; }
        public DateTime ConfirmationDate { get; set; }
        public string DepartmentGroup { get; set; }
        public string Designation { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string MonthYear { get; set; }
        public string AllowanceName { get; set; }
        public decimal AllowanceAmt { get; set; }
        public decimal TotalAllowanceAmt { get; set; }
        
    }
}
