using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.Embro.Setups;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.CompanyInfos.Queries
{
    public class GetDDLCompanyInfoQuery : IRequest<List<SelectListItem>>
    {
    }
    public class GetDDLCompanyInfoQueryHandler : IRequestHandler<GetDDLCompanyInfoQuery, List<SelectListItem>>
    {
        private readonly ICompanyInfoService companyInfoService;
        public GetDDLCompanyInfoQueryHandler(ICompanyInfoService _companyInfoService)
        {
            companyInfoService = _companyInfoService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLCompanyInfoQuery request, CancellationToken cancellationToken)
        {
            return await companyInfoService.DDLCompany(cancellationToken);
        }
    }
}
