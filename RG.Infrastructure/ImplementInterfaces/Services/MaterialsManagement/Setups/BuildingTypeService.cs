using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Setups;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Setups
{
    public class BuildingTypeService : IBuildingTypeService
    {
        private readonly IBuildingTypeRepository _buildingTypeRepository;

        public BuildingTypeService(IBuildingTypeRepository buildingTypeRepository)
        {
            _buildingTypeRepository = buildingTypeRepository;
        }
        public async Task<List<SelectListItem>> DDLBuildingType(CancellationToken cancellationToken)
        {
            return await _buildingTypeRepository.DDLBuildingType(cancellationToken); 
        }
    }
}
