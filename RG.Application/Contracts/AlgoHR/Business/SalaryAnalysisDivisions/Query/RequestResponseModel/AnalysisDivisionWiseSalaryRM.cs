using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.SalaryAnalysisDivisions.Query.RequestResponseModel
{
    public class AnalysisDivisionWiseSalaryRM
    {
        public string ReportHead { get; set; }
        public string ReportDataName { get; set; }
        public string ReportDivision { get; set; }

        public string ReportDataHead { get; set; }
        /// <summary>
        /// sp-> othrer material cost ->PONo
        /// </summary>
        public long EmployeeID { get; set; }
        public string EmployeeCode { get; set; }

        /// <summary>
        /// sp-> othrer material cost ->CompanyShortName
        /// </summary>
        public string EmployeeOldCode { get; set; }
        public string EmployeeName { get; set; }
        /// <summary>
        /// sp-> othrer material cost ->SupplierCompanyName
        /// </summary>
        public string Designation { get; set; }
        /// <summary>
        /// sp-> othrer material cost ->AttributeName
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// sp-> othrer material cost ->ItemName
        /// </summary>
        public string DepartmentGroup { get; set; }
        /// <summary>
        /// sp-> othrer material cost ->CreationDate
        /// </summary>
        public DateTime PayrollDate { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string MonthYear { get; set; }
        /// <summary>
        /// sp-> othrer material cost ->Quantity
        /// </summary>
        public decimal SalaryAmount { get; set; }
        /// <summary>
        /// sp-> othrer material cost ->Rate
        /// </summary>
        public decimal OTAmount { get; set; }
        /// <summary>
        /// sp-> othrer material cost ->TotalValue
        /// </summary>
        public decimal AllowanceAmt { get; set; }

    }
}
