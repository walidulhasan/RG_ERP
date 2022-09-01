using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.MaterialsManagement.Setups.YarnRackSetups.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.YarnRackSetups.Queries
{
    public class GetFloorWiseRackInfoQuery:IRequest<List<YarnRackSetupInfoRM>>
    {
        public int BuildingFloorID { get; set; }
    }
    public class GetFloorWiseRackInfoQueryHandler : IRequestHandler<GetFloorWiseRackInfoQuery, List<YarnRackSetupInfoRM>>
    {
        private readonly IYarnRackSetupService _yarnRackSetupService;

        public GetFloorWiseRackInfoQueryHandler(IYarnRackSetupService YarnRackSetupService)
        {
            _yarnRackSetupService = YarnRackSetupService;
        }
        public async Task<List<YarnRackSetupInfoRM>> Handle(GetFloorWiseRackInfoQuery request, CancellationToken cancellationToken)
        {
            var data = await _yarnRackSetupService.GetFloorWiseRackInfo(request.BuildingFloorID, cancellationToken);
            return data;

        }
    }
}
