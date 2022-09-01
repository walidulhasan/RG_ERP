using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.Application.Interfaces.Services.Embro.Setups;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Embro.Setups
{
    public class CompanyInfoService : ICompanyInfoService
    {
        private readonly ICompanyInfoRepository companyInfoRepository;

        public CompanyInfoService(ICompanyInfoRepository _companyInfoRepository)
        {
            companyInfoRepository = _companyInfoRepository;
        }
        public async Task<List<SelectListItem>> DDLCompany(CancellationToken cancellationToken)
        {
            return await companyInfoRepository.DDLCompany(cancellationToken);
        }
    }
}
