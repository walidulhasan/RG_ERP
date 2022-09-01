using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.Application.ViewModel.MDSir.Salary;
using RG.DBEntities.AlgoHR.Business;
using RG.Infrastructure.Persistence.AlgoHRDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Business
{
    public class MonthlyProductionCostAnalysisRepository : GenericRepository<MonthlyProductionCostAnalysis>, IMonthlyProductionCostAnalysisRepository
    {
        private readonly AlgoHRDBContext _dbCon;
        public MonthlyProductionCostAnalysisRepository(AlgoHRDBContext con) : base(con)
        {
            _dbCon = con;
        }
        public async Task<List<SalaryAnalysisReportVM>> GetMonthlyProductionCostAnalysis(int month, int year, CancellationToken cancellationToken)
        {
            var firstDate = new DateTime(year, month, 1);
            var lastDate = firstDate.AddMonths(1).AddDays(-1);

            var data = await (from mp in _dbCon.MonthlyProductionCostAnalysis
                              join sd in _dbCon.SalaryAnalysisDivision on mp.SalaryAnalysisDivisionID equals sd.SalaryAnalysisDivisionID
                              where mp.Month == month && mp.Year == year && mp.IsRemoved==false
                              select new SalaryAnalysisReportVM
                              {
                                  ID = mp.ID,
                                  SalaryAnalysisDivisionID = sd.SalaryAnalysisDivisionID,
                                  AnalysisDivision = sd.AnalysisDivision,
                                  Month = mp.Month,
                                  Year = mp.Year,
                                  Earning = mp.Earning,
                                  TotalCost = mp.TotalCost,
                                  MonthFirstDate = firstDate.ToString("dd-MMM-yyyy"),
                                  MonthLastDate = lastDate.ToString("dd-MMM-yyyy")
                              }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<MonthlyProductionCostAnalysis> GetMonthlyProductionCostByAnalysisDivision(int salaryAnalysisDivisionID, int month, int year, CancellationToken cancellationToken)
        {
            var data = await _dbCon.MonthlyProductionCostAnalysis.Where(x => x.SalaryAnalysisDivisionID == salaryAnalysisDivisionID && x.Month == month && x.Year == year && x.IsRemoved==false).FirstOrDefaultAsync(cancellationToken);
            return data;
        }
    }
}
