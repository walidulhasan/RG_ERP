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

namespace RG.Application.Contracts.MaterialsManagement.Setups.BuildingFloorInfos.Commands.Create
{
    public class BuildingFloorInfoCreateCommand:IRequest<RResult>
    {
        public BuildingFloorInfoDTM Model { get; set; }
    }
    public class BuildingFloorInfoCreateCommandHandler : IRequestHandler<BuildingFloorInfoCreateCommand, RResult>
    {
        private readonly IBuildingFloorInfoService _buildingFloorInfoService;

        public BuildingFloorInfoCreateCommandHandler(IBuildingFloorInfoService buildingFloorInfoService)
        {
            _buildingFloorInfoService = buildingFloorInfoService;
        }
        public async Task<RResult> Handle(BuildingFloorInfoCreateCommand request, CancellationToken cancellationToken)
        {
            return await _buildingFloorInfoService.BuildingFloorInfoCreate(request.Model,true);
        }
    }
}
