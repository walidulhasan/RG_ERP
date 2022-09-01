using RG.Application.Contracts.AlgoHR.Business.CompanyMonthlySalarys.Queries.RequestResponseModel;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Business
{
    public  interface ICompanyMonthlySalaryService
    {
        Task<List<CompanyMonthlySalaryRM>> GetCompanyMonthlySalary(int CompanyId, int Month, int Year, CancellationToken cancellationToken);
        Task<List<CompanyMonthlySalaryRM>> GetCompanyDivisionMonthlySalary(int CompanyId, int DivisionID, int Month, int Year, CancellationToken cancellationToken);

    }
}
