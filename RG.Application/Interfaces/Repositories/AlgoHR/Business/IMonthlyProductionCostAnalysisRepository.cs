using RG.Application.ViewModel.MDSir.Salary;
using RG.DBEntities.AlgoHR.Business;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AlgoHR.Business
{
    public interface IMonthlyProductionCostAnalysisRepository:IGenericRepository<MonthlyProductionCostAnalysis>
    {
        Task<List<SalaryAnalysisReportVM>> GetMonthlyProductionCostAnalysis(int month, int year, CancellationToken cancellationToken);
        Task<MonthlyProductionCostAnalysis> GetMonthlyProductionCostByAnalysisDivision(int salaryAnalysisDivisionID, int month, int year, CancellationToken cancellationToken);
    }
}
