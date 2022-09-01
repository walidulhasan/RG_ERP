using MediatR;
using RG.Application.Contracts.Maxco.Setup.Plan_ArtWork_Setup.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Setup.Plan_ArtWork_Setup.Queries
{
    public  class GetPlanArtByIDQuery:IRequest<PlanArtRM>
    {
        public int ArtID { get; set; }
    }

    public class GetPlanArtByIDQueryHandler : IRequestHandler<GetPlanArtByIDQuery, PlanArtRM>
    {
        private readonly IPlan_ArtWork_SetupService _plan_ArtWork_SetupService;

        public GetPlanArtByIDQueryHandler(IPlan_ArtWork_SetupService plan_ArtWork_SetupService)
        {
            _plan_ArtWork_SetupService = plan_ArtWork_SetupService;
        }
        public async Task<PlanArtRM> Handle(GetPlanArtByIDQuery request, CancellationToken cancellationToken)
        {
            return await _plan_ArtWork_SetupService.GetArtWorkByID(request.ArtID, cancellationToken);
        }
    }
}
