using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.BuildingFloorInfos.Queries
{
    public class DDLBuildingWiseBuildingFloorQuery:IRequest<List<SelectListItem>>
    {
        public int Building { get; set; }
        public string Predict { get; set; }
        public int Floor { get; set; }
    }
    public class DDLBuildingWiseBuildingFloorQueryHandlar : IRequestHandler<DDLBuildingWiseBuildingFloorQuery, List<SelectListItem>>
    {
        private readonly IBuildingFloorInfoService _buildingFloorInfoService;

        public DDLBuildingWiseBuildingFloorQueryHandlar(IBuildingFloorInfoService buildingFloorInfoService)
        {
            _buildingFloorInfoService = buildingFloorInfoService;
        }
        public async Task<List<SelectListItem>> Handle(DDLBuildingWiseBuildingFloorQuery request, CancellationToken cancellationToken)
        {
            return await _buildingFloorInfoService.DDLBuildingWiseBuildingFloor(request.Building,request.Floor,request.Predict,cancellationToken);
        }
    }
}
