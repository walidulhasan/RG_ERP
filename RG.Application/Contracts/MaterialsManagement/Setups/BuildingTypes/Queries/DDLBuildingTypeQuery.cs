using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.BuildingTypes.Queries
{
    public class DDLBuildingTypeQuery:IRequest<List<SelectListItem>>
    {
    }
    public class DDLBuildingTypeQueryHandler : IRequestHandler<DDLBuildingTypeQuery, List<SelectListItem>>
    {
        private readonly IBuildingTypeService _buildingTypeService;

        public DDLBuildingTypeQueryHandler(IBuildingTypeService buildingTypeService)
        {
            _buildingTypeService = buildingTypeService;
        }
        public async Task<List<SelectListItem>> Handle(DDLBuildingTypeQuery request, CancellationToken cancellationToken)
        {
            return await _buildingTypeService.DDLBuildingType(cancellationToken);
        }
    }
}
