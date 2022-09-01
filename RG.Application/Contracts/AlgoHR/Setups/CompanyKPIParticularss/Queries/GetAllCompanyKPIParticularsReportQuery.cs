using MediatR;
using RG.Application.Contracts.AlgoHR.Setups.CompanyKPIParticularss.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.CompanyKPIParticularss.Queries
{
    public class GetAllCompanyKPIParticularsReportQuery:IRequest<List<CompanyKPIReportRM>>
    {
        public int KPIMonth { get; set; }
        public int KPIYear { get; set; }
        public int ForLastYears { get; set; } = 0;
    }
    public class GetAllCompanyKPIParticularsReportQueryHandler : IRequestHandler<GetAllCompanyKPIParticularsReportQuery, List<CompanyKPIReportRM>>
    {
        private readonly ICompanyKPIParticularsService _companyKPIParticularsService;

        public GetAllCompanyKPIParticularsReportQueryHandler(ICompanyKPIParticularsService companyKPIParticularsService)
        {
            _companyKPIParticularsService = companyKPIParticularsService;
        }
        public async Task<List<CompanyKPIReportRM>> Handle(GetAllCompanyKPIParticularsReportQuery request, CancellationToken cancellationToken)
        {
            return await _companyKPIParticularsService.GetAllCompanyKPIParticularsReport(request.KPIMonth, request.KPIYear, request.ForLastYears, cancellationToken);
        }
    }
}
