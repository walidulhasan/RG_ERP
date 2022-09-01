using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.DivisionOtherCosts.Queries.RequestResponseModel
{
    public class DivisionOtherCostRM
    {
        public int OtherCostID { get; set; }
        public int SalaryAnalysisDivisionID { get; set; }
        public string AnalysisDivision { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int CostHeadID { get; set; }
        public string CostHead { get; set; }
        public decimal Cost { get; set; }
        //public string PreviousMonthCostHead { get; set; }
        public decimal PreviousMonthCost { get; set; }
        public bool HasDetailReport { get; set; }
    }
}
