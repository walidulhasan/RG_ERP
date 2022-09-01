using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.Maxco.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Setup.Plan_ArtWork_Setup.Queries
{
    public class GetDDLArtWorkQueries : IRequest<List<SelectListItem>>
    {
    }
    public class GetDDLArtWorkQueriesHandler : IRequestHandler<GetDDLArtWorkQueries, List<SelectListItem>>
    {
        private readonly IPlan_ArtWork_SetupService _plan_ArtWork_SetupService;

        public GetDDLArtWorkQueriesHandler(IPlan_ArtWork_SetupService plan_ArtWork_SetupService)
        {
            _plan_ArtWork_SetupService = plan_ArtWork_SetupService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLArtWorkQueries request, CancellationToken cancellationToken)
        {
            return await _plan_ArtWork_SetupService.DDLArtWork(cancellationToken);
        }
    }
}
