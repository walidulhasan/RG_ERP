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
    public class BuildingFloorInfoUpdateCommand:IRequest<RResult>
    {
        public BuildingFloorInfoDTM DtModelUpdate { get; set; }
    }
    public class BuildingFloorInfoUpdateCommandHandler : IRequestHandler<BuildingFloorInfoUpdateCommand, RResult>
    {
        private readonly IBuildingFloorInfoService _buildingFloorInfoService;

        public BuildingFloorInfoUpdateCommandHandler(IBuildingFloorInfoService buildingFloorInfoService)
        {
            _buildingFloorInfoService = buildingFloorInfoService;
        }
        public async Task<RResult> Handle(BuildingFloorInfoUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _buildingFloorInfoService.BuildingFloorInfoUpdate(request.DtModelUpdate,true);
        }
    }
}
