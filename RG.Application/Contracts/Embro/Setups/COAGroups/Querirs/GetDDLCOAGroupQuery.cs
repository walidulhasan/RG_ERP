using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.Embro.Setups;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.COAGroups.Querirs
{
    public class GetDDLCOAGroupQuery : IRequest<List<SelectListItem>>
    {
        public int CategoryID { get; set; }
        public string Predict { get; set; }
    }
    public class GetDDLCOAGroupQueryHandler : IRequestHandler<GetDDLCOAGroupQuery, List<SelectListItem>>
    {
        private readonly ICOAGroupService _cOAGroupService;

        public GetDDLCOAGroupQueryHandler(ICOAGroupService cOAGroupService)
        {
            _cOAGroupService = cOAGroupService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLCOAGroupQuery request, CancellationToken cancellationToken)
        {
            return await _cOAGroupService.DDLCOAGroup(request.CategoryID,request.Predict, cancellationToken);
        }
    }
}
