using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.MDSir.Salary
{
    public class SalaryAnalysisReportVM
    {
        public int ID { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string MonthFirstDate { get; set; }
        public string MonthLastDate { get; set; }
        public int SalaryAnalysisDivisionID { get; set; }
        public string AnalysisDivision { get; set; }
        public decimal Earning { get; set; }
        public decimal TotalCost { get; set; }
    }
}
