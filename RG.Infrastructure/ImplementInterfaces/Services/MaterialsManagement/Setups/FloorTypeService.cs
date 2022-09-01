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
    public class FloorTypeService : IFloorTypeService
    {
        private readonly IFloorTypeRepository _floorTypeRepository;

        public FloorTypeService(IFloorTypeRepository floorTypeRepository)
        {
            _floorTypeRepository = floorTypeRepository;
        }
        public async Task<List<SelectListItem>> GetDDLFloorType(CancellationToken cancellationToken)
        {
            return await _floorTypeRepository.GetDDLFloorType(cancellationToken);
        }
    }
}
