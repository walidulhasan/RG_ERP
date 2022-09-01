using Microsoft.EntityFrameworkCore;
using RG.Application.Contracts.AlgoHR.Business.DivisionOtherCosts.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
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
    public class DivisionOtherCostRepository : GenericRepository<DivisionOtherCost>, IDivisionOtherCostRepository
    {
        private AlgoHRDBContext dbCon;
        public DivisionOtherCostRepository(AlgoHRDBContext context)
            : base(context)
        {
            dbCon = context;

        }
        public async Task<List<DivisionOtherCostRM>> GetMonthWiseDivisionOtherCost(int salaryAnalysisDivisionID, int month, int year, CancellationToken cancellationToken)
        {
            var prevMonth = month;
            var prevYear = year;
            
            var data = await (from s in dbCon.DivisionOtherCost
                              join h in dbCon.DivisionCostHeads on s.CostHeadID equals h.CostHeadID
                              join d in dbCon.SalaryAnalysisDivision on s.SalaryAnalysisDivisionID equals d.SalaryAnalysisDivisionID
                              where s.Month == month && s.Year == year && s.SalaryAnalysisDivisionID == salaryAnalysisDivisionID
                              select new DivisionOtherCostRM
                              {
                                  OtherCostID = s.OtherCostID,
                                  Month = s.Month,
                                  Year = s.Year,
                                  SalaryAnalysisDivisionID = s.SalaryAnalysisDivisionID,
                                  AnalysisDivision = d.AnalysisDivision,
                                  CostHeadID = s.CostHeadID,
                                  CostHead = h.CostHead,
                                  Cost = s.Cost,
                                  HasDetailReport = h.HasDetailReport
                              }).ToListAsync(cancellationToken);
            if (month == 1)
            {
                prevMonth = 12;
                prevYear = year - 1;
            }
            else
            {
                prevMonth = month - 1;
            }

            var prevData = await (from s in dbCon.DivisionOtherCost
                              join h in dbCon.DivisionCostHeads on s.CostHeadID equals h.CostHeadID
                              join d in dbCon.SalaryAnalysisDivision on s.SalaryAnalysisDivisionID equals d.SalaryAnalysisDivisionID
                              where s.Month == prevMonth && s.Year == prevYear && s.SalaryAnalysisDivisionID == salaryAnalysisDivisionID
                              select new DivisionOtherCostRM
                              {
                                  CostHead = h.CostHead,
                                  PreviousMonthCost = s.Cost
                              }).ToListAsync(cancellationToken);

            foreach (var item in data)
            {
                var prevDataItem = prevData.Where(x => x.CostHead == item.CostHead).FirstOrDefault();
                if (prevDataItem != null)
                {
                    item.PreviousMonthCost = prevDataItem.PreviousMonthCost;
                    
                    prevData.Remove(prevDataItem);
                }
                
            }
            if (prevData.Count > 0)
                data.AddRange(prevData);
            //data.AddRange(prevData.Where(p => data.All(p2 => p2.Department != p.Department)));
            return data;
        }
    }
}
