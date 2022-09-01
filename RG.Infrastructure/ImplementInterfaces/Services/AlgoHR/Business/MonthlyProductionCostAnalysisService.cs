using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using RG.Application.ViewModel.MDSir.Salary;
using RG.DBEntities.AlgoHR.Business;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Business
{
    public class MonthlyProductionCostAnalysisService : IMonthlyProductionCostAnalysisService
    {
        private readonly IMonthlyProductionCostAnalysisRepository _monthlyProductionCostAnalysisRepository;
        private readonly IDivisionSalaryCostRepository _divisionSalaryCostRepository;
        private readonly IDivisionOtherCostRepository _divisionOtherCostRepository;

        public MonthlyProductionCostAnalysisService(IMonthlyProductionCostAnalysisRepository monthlyProductionCostAnalysisRepository
            ,IDivisionSalaryCostRepository divisionSalaryCostRepository, IDivisionOtherCostRepository divisionOtherCostRepository)
        {
            _monthlyProductionCostAnalysisRepository = monthlyProductionCostAnalysisRepository;
            _divisionSalaryCostRepository = divisionSalaryCostRepository;
            _divisionOtherCostRepository = divisionOtherCostRepository;
        }
        public async Task<List<SalaryAnalysisReportVM>> GetMonthlyProductionCostAnalysis(int month, int year, CancellationToken cancellationToken)
        {
            return await _monthlyProductionCostAnalysisRepository.GetMonthlyProductionCostAnalysis(month, year, cancellationToken);
        }
        public async Task<MonthlyProductionCostAnalysis> GetMonthlyProductionCostByAnalysisDivision(int salaryAnalysisDivisionID,int month, int year, CancellationToken cancellationToken)
        {
            return await _monthlyProductionCostAnalysisRepository.GetMonthlyProductionCostByAnalysisDivision(salaryAnalysisDivisionID,month, year, cancellationToken);
        }

        public async Task<SalaryAnalysisDetailReportVM> GetSalaryAnalysisDetailReport(int salaryAnalysisDivisionID, int month, int year, CancellationToken cancellationToken)
        {
            var prevMonth = month;
            var prevYear = year;
            if (month == 1)
            {
                prevMonth = 12;
                prevYear = year - 1;
            }
            else
            {
                prevMonth = month - 1;
            }
            var earningData = await GetMonthlyProductionCostByAnalysisDivision(salaryAnalysisDivisionID, month, year, cancellationToken);
            var prevEarningData = await GetMonthlyProductionCostByAnalysisDivision(salaryAnalysisDivisionID, prevMonth, prevYear, cancellationToken);
            
            SalaryAnalysisDetailReportVM data = new()
            {
                TotalEarning= earningData!=null? earningData.Earning:0,
                TotalCost = earningData!=null? earningData.TotalCost:0,
                PreviousMonthTotalEarning = prevEarningData != null ? prevEarningData.Earning : 0,
                PreviousMonthTotalCost = prevEarningData != null ? prevEarningData.TotalCost : 0,
                DivisionSalaryCost = await _divisionSalaryCostRepository.GetMonthWiseDivisionSalaryCost(salaryAnalysisDivisionID, month, year, cancellationToken),
                DivisionOtherCost = await _divisionOtherCostRepository.GetMonthWiseDivisionOtherCost(salaryAnalysisDivisionID, month, year, cancellationToken)
            };
            return data;
                 
        }
    }
}
