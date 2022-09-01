using MediatR;
using RG.Application.Contracts.AlgoHR.Setups.CompanyKPIParticularss.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.CompanyKPIParticularss.Queries
{
    public class GetAllCompanyKPIParticularsQuery : IRequest<List<CompanyKPIParticularsRM>>
    {
        public int KPIMonth { get; set; }
        public int KPIYear { get; set; }
    }
    public class GetAllCompanyKPIParticularsQueryHandler : IRequestHandler<GetAllCompanyKPIParticularsQuery, List<CompanyKPIParticularsRM>>
    {
        private readonly ICompanyKPIParticularsService _companyKPIParticularsService;

        public GetAllCompanyKPIParticularsQueryHandler(ICompanyKPIParticularsService companyKPIParticularsService)
        {
            _companyKPIParticularsService = companyKPIParticularsService;
        }
        public async Task<List<CompanyKPIParticularsRM>> Handle(GetAllCompanyKPIParticularsQuery request, CancellationToken cancellationToken)
        {
            return await _companyKPIParticularsService.GetAllCompanyKPIParticulars(request.KPIMonth,request.KPIYear,cancellationToken);
        }
    }
}
