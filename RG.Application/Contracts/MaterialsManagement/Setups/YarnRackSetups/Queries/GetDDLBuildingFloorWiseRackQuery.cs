using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.YarnRackSetups.Queries
{
    public class GetDDLBuildingFloorWiseRackQuery : IRequest<List<SelectListItem>>
    {
        public int BuildingFloorID { get; set; }
    }
    public class GetDDLBuildingFloorWiseRackQueryHandler : IRequestHandler<GetDDLBuildingFloorWiseRackQuery, List<SelectListItem>>
    {
        private readonly IYarnRackSetupService _yarnRackSetupService;

        public GetDDLBuildingFloorWiseRackQueryHandler(IYarnRackSetupService yarnRackSetupService)
        {
            _yarnRackSetupService = yarnRackSetupService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLBuildingFloorWiseRackQuery request, CancellationToken cancellationToken)
        {
            return await _yarnRackSetupService.DDLBuildingFloorWiseRack(request.BuildingFloorID, cancellationToken);
        }
    }
}
