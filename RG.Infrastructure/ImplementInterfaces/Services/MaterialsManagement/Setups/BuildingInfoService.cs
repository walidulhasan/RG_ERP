using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.MaterialsManagement.Setups.BuildingInfos.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Setups;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Setups
{
    public class BuildingInfoService : IBuildingInfoService
    {
        private readonly IBuildingInfoRepository _buildingInfoRepository;
        private readonly IMapper _mapper;

        public BuildingInfoService(IBuildingInfoRepository buildingInfoRepository, IMapper mapper)
        {
            _buildingInfoRepository = buildingInfoRepository;
            _mapper = mapper;
        }

        public async Task<BuildingInfoRM> BuildingFloorWiseBuildingInfo(int budlingFloorID, CancellationToken cancellationToken)
        {
            var data = await _buildingInfoRepository.BuildingFloorWiseBuildingInfo(budlingFloorID, cancellationToken);
            var returnData = _mapper.Map<BuildingInfo, BuildingInfoRM>(data);
            return returnData;
        }

        public async Task<List<SelectListItem>> BuildingTypeWiseBuildingInfo(int ID, string predict, CancellationToken cancellationToken)
        {
            return await _buildingInfoRepository.BuildingTypeWiseBuildingInfo(ID,predict,cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLFloorTypeWiseBuilding(int FloorType, string predict, CancellationToken cancellationToken)
        {
            return await _buildingInfoRepository.DDLFloorTypeWiseBuilding(FloorType, predict, cancellationToken);
        }
    }
}
