using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Setups.BuildingFloorInfos.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.BuildingFloorInfos.Commands.Update
{
    public class BuildingFloorInfoRemoveCommand:IRequest<RResult>
    {
        public int id { get; set; }
    }
    public class BuildingFloorInfoRemoveCommandHandler : IRequestHandler<BuildingFloorInfoRemoveCommand, RResult>
    {
        private readonly IBuildingFloorInfoService _buildingFloorInfoService;

        public BuildingFloorInfoRemoveCommandHandler(IBuildingFloorInfoService buildingFloorInfoService)
        {
            _buildingFloorInfoService = buildingFloorInfoService;
        }
        public async Task<RResult> Handle(BuildingFloorInfoRemoveCommand request, CancellationToken cancellationToken)
        {
            return await _buildingFloorInfoService.BuildingFloorInfoRemove(request.id,true);
        }
    }
}
