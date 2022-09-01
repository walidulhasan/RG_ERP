using MediatR;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using RG.Application.Interfaces.Services.Embro.Setups;
using RG.Application.ViewModel.MDSir.Salary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.MonthlyProductionCostAnalysiss.Query
{
    public class GetSalaryAnalysisDetailReportQuery:IRequest<SalaryAnalysisDetailReportVM>
    {
        public int SalaryAnalysisDivisionID { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
    public class GetSalaryAnalysisDetailReportQueryHandler : IRequestHandler<GetSalaryAnalysisDetailReportQuery, SalaryAnalysisDetailReportVM>
    {
        private readonly IMonthlyProductionCostAnalysisService _monthlyProductionCostAnalysisService;
        private readonly Itbl_Currency_DetailService _itbl_Currency_DetailService;

        public GetSalaryAnalysisDetailReportQueryHandler(IMonthlyProductionCostAnalysisService monthlyProductionCostAnalysisService, Itbl_Currency_DetailService itbl_Currency_DetailService)
        {
            _monthlyProductionCostAnalysisService = monthlyProductionCostAnalysisService;
            _itbl_Currency_DetailService = itbl_Currency_DetailService;
        }
        public async Task<SalaryAnalysisDetailReportVM> Handle(GetSalaryAnalysisDetailReportQuery request, CancellationToken cancellationToken)
        {
            var data = await _monthlyProductionCostAnalysisService.GetSalaryAnalysisDetailReport(request.SalaryAnalysisDivisionID, request.Month, request.Year, cancellationToken);
            data.Year = request.Year;
            data.MonthName = new DateTime(request.Year,request.Month, 1).ToString("MMMM");
            data.CurrencyRate = (await _itbl_Currency_DetailService.GetCurrencyRate(2, cancellationToken)).RateInPakRs.Value;
            return data;
        }
    }
}
