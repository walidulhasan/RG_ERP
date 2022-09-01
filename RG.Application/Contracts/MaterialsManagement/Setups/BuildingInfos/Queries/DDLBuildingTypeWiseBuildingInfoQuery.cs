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
    public class DDLBuildingTypeWiseBuildingInfoQuery:IRequest<List<SelectListItem>>
    {
        public int id { get; set; }
        public string predict { get; set; }
    }
    public class DDLBuildingTypeWiseBuildingInfoQueryHandler : IRequestHandler<DDLBuildingTypeWiseBuildingInfoQuery, List<SelectListItem>>
    {
        private readonly IBuildingInfoService _buildingInfoService;

        public DDLBuildingTypeWiseBuildingInfoQueryHandler(IBuildingInfoService buildingInfoService)
        {
            _buildingInfoService = buildingInfoService;
        }
        public async Task<List<SelectListItem>> Handle(DDLBuildingTypeWiseBuildingInfoQuery request, CancellationToken cancellationToken)
        {
            return await _buildingInfoService.BuildingTypeWiseBuildingInfo(request.id,request.predict,cancellationToken);
        }
    }
}
