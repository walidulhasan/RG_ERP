using MediatR;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using RG.Application.ViewModel.MDSir.Salary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.MonthlyProductionCostAnalysiss.Query
{
    public class GetMonthlyProductionCostAnalysisQuery:IRequest<List<SalaryAnalysisReportVM>>
    {
        public int Month { get; set; }
        public int Year { get; set; }
    }
    public class GetMonthlyProductionCostAnalysisQueryHandler : IRequestHandler<GetMonthlyProductionCostAnalysisQuery, List<SalaryAnalysisReportVM>>
    {
        private readonly IMonthlyProductionCostAnalysisService _monthlyProductionCostAnalysisService;

        public GetMonthlyProductionCostAnalysisQueryHandler(IMonthlyProductionCostAnalysisService monthlyProductionCostAnalysisService)
        {
            _monthlyProductionCostAnalysisService = monthlyProductionCostAnalysisService;
        }
        public async Task<List<SalaryAnalysisReportVM>> Handle(GetMonthlyProductionCostAnalysisQuery request, CancellationToken cancellationToken)
        {
            return await _monthlyProductionCostAnalysisService.GetMonthlyProductionCostAnalysis(request.Month, request.Year, cancellationToken);
        }
    }
}
