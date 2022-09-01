using MediatR;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.Tbl_Company.Query
{
    public class GetEmbroToHrCompanyQuery :IRequest<List<int>>
    {
        public List<int> EmbroCountryIDList { get; set; } = new List<int>();
        public int EmbroCountryID { get; set; }
    }

    public class GetEmbroToHrCompanyQueryHandler : IRequestHandler<GetEmbroToHrCompanyQuery, List<int>>
    {
        private readonly ITbl_CompanyService _tbl_CompanyService;

        public GetEmbroToHrCompanyQueryHandler(ITbl_CompanyService tbl_CompanyService)
        {
            _tbl_CompanyService = tbl_CompanyService;

        }
        public async Task<List<int>> Handle(GetEmbroToHrCompanyQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_CompanyService.GetEmbroToHrCompany(request.EmbroCountryID, request.EmbroCountryIDList, cancellationToken);
        }
    }
}
