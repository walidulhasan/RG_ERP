using MediatR;
using RG.Application.Contracts.MaterialsManagement.Setups.BuildingInfos.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.BuildingInfos.Queries
{
    public class BuildingFloorWiseBuildingInfoQuery : IRequest<BuildingInfoRM>
    {
        public int BuildingfloorID { get; set; }
    }
    public class BuildingFloorWiseBuildingInfoQueryHandler : IRequestHandler<BuildingFloorWiseBuildingInfoQuery, BuildingInfoRM>
    {
        private readonly IBuildingInfoService _buildingInfoService;

        public BuildingFloorWiseBuildingInfoQueryHandler(IBuildingInfoService buildingInfoService)
        {
            _buildingInfoService = buildingInfoService;
        }
        public async Task<BuildingInfoRM> Handle(BuildingFloorWiseBuildingInfoQuery request, CancellationToken cancellationToken)
        {
            var data = await _buildingInfoService.BuildingFloorWiseBuildingInfo(request.BuildingfloorID, cancellationToken);
            return data;

        }
    }
}
