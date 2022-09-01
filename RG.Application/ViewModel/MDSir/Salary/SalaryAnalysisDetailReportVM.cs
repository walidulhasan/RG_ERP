using RG.Application.Contracts.AlgoHR.Business.DivisionOtherCosts.Queries.RequestResponseModel;
using RG.Application.Contracts.AlgoHR.Business.DivisionSalaryCosts.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.MDSir.Salary
{
    public class SalaryAnalysisDetailReportVM
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public string MonthName { get; set; }
        public decimal TotalEarning { get; set; }
        public decimal TotalCost { get; set; }
        public decimal PreviousMonthTotalEarning { get; set; }
        public decimal PreviousMonthTotalCost { get; set; }
        public decimal CurrencyRate { get; set; }
        public List<DivisionSalaryCostRM> DivisionSalaryCost { get; set; }
        public List<DivisionOtherCostRM> DivisionOtherCost { get; set; }
    }

    

}
