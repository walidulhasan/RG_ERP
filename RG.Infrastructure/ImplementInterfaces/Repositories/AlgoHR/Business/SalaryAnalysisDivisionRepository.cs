using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Contracts.AlgoHR.Business.SalaryAnalysisDivisions.Query.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.DBEntities.AlgoHR.Business;
using RG.Infrastructure.Persistence.AlgoHRDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Business
{
    public class SalaryAnalysisDivisionRepository : GenericRepository<SalaryAnalysisDivision>, ISalaryAnalysisDivisionRepository
    {
        private AlgoHRDBContext dbCon;
        public SalaryAnalysisDivisionRepository(AlgoHRDBContext context)
            : base(context)
        {
            dbCon = context;

        }
        public async Task<List<SelectListItem>> DDLSalaryAnalysisDivision(CancellationToken cancellationToken)
        {
            var data = await dbCon.SalaryAnalysisDivision
                .Select(x => new SelectListItem
                {
                    Text = x.AnalysisDivision,
                    Value = x.SalaryAnalysisDivisionID.ToString()
                }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<AnalysisDivisionWiseAllowanceRM>> GetAnalysisDivisionWiseAllowance(string analysisDivision, string departmentGroup, int year, int month, CancellationToken cancellationToken)
        {
            List<AnalysisDivisionWiseAllowanceRM> data = new();
            try
            {
                await dbCon.LoadStoredProc("rpt.USP_AnalysisDivisionWiseAllowance")
                    .WithSqlParam("AnalysisDivision", analysisDivision)
                    .WithSqlParam("DepartmentGroup ", departmentGroup)                    
                    .WithSqlParam("Year", year)
                    .WithSqlParam("Month", month)
                                  .ExecuteStoredProcAsync((handler) =>
                                  {
                                      data = handler.ReadToList<AnalysisDivisionWiseAllowanceRM>() as List<AnalysisDivisionWiseAllowanceRM>;
                                  });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return data;
        }

        public async Task<List<AnalysisDivisionWiseSalaryRM>> GetAnalysisDivisionWiseSalary(string analysisDivision, string departmentGroup, int year, int month, CancellationToken cancellationToken)
        {
            List<AnalysisDivisionWiseSalaryRM> data = new();
            try
            {

                await dbCon.LoadStoredProc("rpt.USP_AnalysisDivisionWiseSalary")
                   .WithSqlParam("AnalysisDivision", analysisDivision)
                    .WithSqlParam("DepartmentGroup ", departmentGroup)
                    .WithSqlParam("Year", year)
                    .WithSqlParam("Month", month)
                                  .ExecuteStoredProcAsync((handler) =>
                                  {
                                      data = handler.ReadToList<AnalysisDivisionWiseSalaryRM>() as List<AnalysisDivisionWiseSalaryRM>;
                                  });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return data;
        }
    }
}
