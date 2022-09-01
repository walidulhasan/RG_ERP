using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.Tbl_Location.Queries
{
    public class GetDDLTbl_LocationCompanyWiseQuery : IRequest<List<SelectListItem>>
    {
        public int CompanyID { get; set; }
    }

    public class GetDDLTbl_LocationCompanyWiseQueryHandler : IRequestHandler<GetDDLTbl_LocationCompanyWiseQuery, List<SelectListItem>>
    {
        private readonly ITbl_LocationService _tbl_LocationService;

        public GetDDLTbl_LocationCompanyWiseQueryHandler(ITbl_LocationService tbl_LocationService)
        {
            _tbl_LocationService = tbl_LocationService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLTbl_LocationCompanyWiseQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_LocationService.DDLLocation(request.CompanyID, cancellationToken);
        }
    }
}
