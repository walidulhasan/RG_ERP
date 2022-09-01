using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.BuildingInfos.Queries
{
    public class DDLFloorTypeWiseBuildingQuery : IRequest<List<SelectListItem>>
    {
        public int FloorType { get; set; }
        public string Predict { get; set; }
    }
    public class FloorTypeWiseBuildingInfoQueryHandler : IRequestHandler<DDLFloorTypeWiseBuildingQuery, List<SelectListItem>>
    {
        private readonly IBuildingInfoService _buildingInfoService;

        public FloorTypeWiseBuildingInfoQueryHandler(IBuildingInfoService buildingInfoService)
        {
            _buildingInfoService = buildingInfoService;
        }
        public async Task<List<SelectListItem>> Handle(DDLFloorTypeWiseBuildingQuery request, CancellationToken cancellationToken)
        {
            return await _buildingInfoService.DDLFloorTypeWiseBuilding(request.FloorType, request.Predict, cancellationToken);
        }
    }
}
