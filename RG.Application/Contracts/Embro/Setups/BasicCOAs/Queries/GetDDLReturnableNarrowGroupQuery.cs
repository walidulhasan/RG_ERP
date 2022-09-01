using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.Embro.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.BasicCOAs.Queries
{
    public class GetDDLReturnableNarrowGroupQuery : IRequest<List<SelectListItem>>
    {
        public int CompanyID { get; set; }
    }
    public class GetDDLReturnableNarrowGroupQueryHandler : IRequestHandler<GetDDLReturnableNarrowGroupQuery, List<SelectListItem>>
    {
        private readonly IBasicCOAService basicCOAService;
        public GetDDLReturnableNarrowGroupQueryHandler(IBasicCOAService _basicCOAService)
        {
            basicCOAService = _basicCOAService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLReturnableNarrowGroupQuery request, CancellationToken cancellationToken)
        {
            return await basicCOAService.DDLGetReturnableNarrowGroup(request.CompanyID, cancellationToken);
        }
    }
}
