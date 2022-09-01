using RG.Application.Contracts.AlgoHR.Business.CompanyMonthlySalarys.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Business
{
    public class CompanyMonthlySalaryService : ICompanyMonthlySalaryService
    {
        private readonly ICompanyMonthlySalaryRepository _companyMonthlySalaryRepository;

        public CompanyMonthlySalaryService(ICompanyMonthlySalaryRepository companyMonthlySalaryRepository)
        {
            _companyMonthlySalaryRepository = companyMonthlySalaryRepository;
        }

        public async Task<List<CompanyMonthlySalaryRM>> GetCompanyDivisionMonthlySalary(int CompanyId, int DivisionID, int Month, int Year, CancellationToken cancellationToken)
        {
            return await _companyMonthlySalaryRepository.GetCompanyDivisionMonthlySalary(CompanyId,DivisionID, Month, Year, cancellationToken);

        }

        public async Task<List<CompanyMonthlySalaryRM>> GetCompanyMonthlySalary(int CompanyId, int Month, int Year, CancellationToken cancellationToken)
        {
            return await _companyMonthlySalaryRepository.GetCompanyMonthlySalary(CompanyId,Month,Year,cancellationToken);
        }
    }
}
