using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.DivisionSalaryCosts.Queries.RequestResponseModel
{
    public class DivisionSalaryCostRM
    {
        public int SalaryCostID { get; set; }
        public int SalaryAnalysisDivisionID { get; set; }
        public string AnalysisDivision { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string Department { get; set; }
        public int Manpower { get; set; }
        public decimal Salary { get; set; }
        public decimal Overtime { get; set; }
        public decimal Allowance { get; set; }
        public decimal? ExtraOvertime { get; set; }
        public decimal Total { get { return Salary + Overtime + Allowance; } }
        public int PreviousMonthManpower { get; set; }
        public decimal PreviousMonthSalary { get; set; }
        public decimal PreviousMonthOvertime { get; set; }
        public decimal PreviousMonthAllowance { get; set; }
        public decimal PreviousMonthTotal { get { return PreviousMonthSalary + PreviousMonthOvertime + PreviousMonthAllowance; } }
    }
}
