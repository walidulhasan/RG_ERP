using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.ITbl_Religion.Queries
{
    public class GetDDLReligionQuery : IRequest<List<SelectListItem>>
    {
    }
    public class GetDDLReligionQueryHandler : IRequestHandler<GetDDLReligionQuery, List<SelectListItem>>
    {
        private readonly ITbl_ReligionService _tbl_ReligionService;

        public GetDDLReligionQueryHandler(ITbl_ReligionService tbl_ReligionService)
        {
            _tbl_ReligionService = tbl_ReligionService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLReligionQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_ReligionService.DDLReligion(cancellationToken);
        }
    }
}
