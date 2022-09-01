using MediatR;
using RG.Application.Common.Utilities;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.Tbl_Company.Query
{
  public  class GetDDLCompanyLookUpQuery :IRequest<List<IdNamePairRM>>
    {
        public int CompanyID { get; set; } = 0;
    }

    public class GetDDLCompanyLookUpQueryHandler : IRequestHandler<GetDDLCompanyLookUpQuery,List<IdNamePairRM>>
    {
        private readonly ITbl_CompanyService _tbl_CompanyService;

        public GetDDLCompanyLookUpQueryHandler(ITbl_CompanyService tbl_CompanyService)
        {
            _tbl_CompanyService = tbl_CompanyService;
        }
        public async Task<List<IdNamePairRM>> Handle(GetDDLCompanyLookUpQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_CompanyService.GetDDLEmbroCompanyLookUp(request.CompanyID, cancellationToken);
        }
    }
}
