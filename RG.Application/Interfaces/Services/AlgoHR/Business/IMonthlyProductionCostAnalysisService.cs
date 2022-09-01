using RG.Application.ViewModel.MDSir.Salary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Business
{
    public interface IMonthlyProductionCostAnalysisService
    {
        Task<List<SalaryAnalysisReportVM>> GetMonthlyProductionCostAnalysis(int month, int year, CancellationToken cancellationToken);
        Task<SalaryAnalysisDetailReportVM> GetSalaryAnalysisDetailReport(int salaryAnalysisDivisionID, int month, int year, CancellationToken cancellationToken);

    }
}
