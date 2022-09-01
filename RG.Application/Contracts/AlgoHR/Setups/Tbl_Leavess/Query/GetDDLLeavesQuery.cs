using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.Tbl_Leavess.Query
{
    public class GetDDLLeavesQuery : IRequest<List<SelectListItem>>
    {
    }
    public class GetDDLLeavesQueryHandler : IRequestHandler<GetDDLLeavesQuery, List<SelectListItem>>
    {
        private readonly ITbl_LeavesService _tbl_LeavesService;

        public GetDDLLeavesQueryHandler(ITbl_LeavesService tbl_LeavesService)
        {
            _tbl_LeavesService = tbl_LeavesService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLLeavesQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_LeavesService.DDLLeaves(cancellationToken);
        }
    }
}
