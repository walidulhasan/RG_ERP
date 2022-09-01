using Microsoft.EntityFrameworkCore;
using RG.Application.Contracts.AlgoHR.Business.DivisionSalaryCosts.Queries.RequestResponseModel;
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
    public class DivisionSalaryCostRepository : GenericRepository<DivisionSalaryCost>, IDivisionSalaryCostRepository
    {
        private AlgoHRDBContext dbCon;
        public DivisionSalaryCostRepository(AlgoHRDBContext context)
            : base(context)
        {
            dbCon = context;

        }
        public async Task<List<DivisionSalaryCostRM>> GetMonthWiseDivisionSalaryCost(int salaryAnalysisDivisionID, int month, int year, CancellationToken cancellationToken)
        {
            var prevMonth = month;
            var prevYear = year;
            var data = await (from s in dbCon.DivisionSalaryCost
                              join d in dbCon.SalaryAnalysisDivision on s.SalaryAnalysisDivisionID equals d.SalaryAnalysisDivisionID
                              where s.Month==month && s.Year==year && s.SalaryAnalysisDivisionID==salaryAnalysisDivisionID
                              select new DivisionSalaryCostRM { 
                                  SalaryCostID=s.SalaryCostID,
                                  Month=s.Month,
                                  Year=s.Year,
                                  SalaryAnalysisDivisionID=s.SalaryAnalysisDivisionID,
                                  AnalysisDivision=d.AnalysisDivision,
                                  Department=s.Department,
                                  Manpower=s.Manpower,
                                  Salary=s.Salary,
                                  Overtime=s.Overtime,
                                  Allowance=s.Allowance,
                                  ExtraOvertime=s.ExtraOvertime
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

            var prevData = await (from s in dbCon.DivisionSalaryCost
                              join d in dbCon.SalaryAnalysisDivision on s.SalaryAnalysisDivisionID equals d.SalaryAnalysisDivisionID
                              where s.Month == prevMonth && s.Year == prevYear && s.SalaryAnalysisDivisionID == salaryAnalysisDivisionID
                              select new DivisionSalaryCostRM
                              {                                  
                                  Department = s.Department,
                                  PreviousMonthManpower = s.Manpower,
                                  PreviousMonthSalary = s.Salary,
                                  PreviousMonthOvertime = s.Overtime,
                                  PreviousMonthAllowance = s.Allowance,
                                  
                              }).ToListAsync(cancellationToken);
            foreach (var item in data)
            {
                var prevDataItem = prevData.Where(x => x.Department == item.Department).FirstOrDefault();
                if (prevDataItem!=null)
                {
                    item.PreviousMonthManpower = prevDataItem.PreviousMonthManpower;
                    item.PreviousMonthSalary = prevDataItem.PreviousMonthSalary;
                    item.PreviousMonthOvertime = prevDataItem.PreviousMonthOvertime;
                    item.PreviousMonthAllowance = prevDataItem.PreviousMonthAllowance;

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
