using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Setups.BuildingFloorInfos.Commands.DataTransferModel;
using RG.Application.Contracts.MaterialsManagement.Setups.BuildingFloorInfos.Queries.RequestResponseModel;
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
    public class BuildingFloorInfoService : IBuildingFloorInfoService
    {
        private readonly IBuildingFloorInfoRepository _buildingFloorInfoRepository;
        private readonly IMapper _mapper;

        public BuildingFloorInfoService(IBuildingFloorInfoRepository buildingFloorInfoRepository, IMapper mapper)
        {
            _buildingFloorInfoRepository = buildingFloorInfoRepository;
            _mapper = mapper;
        }

        public async Task<RResult> BuildingFloorInfoCreate(BuildingFloorInfoDTM DTmodel, bool saveChange)
        {
            try
            {
                RResult result = new();
                if (DTmodel!=null)
                {
                    var entity = _mapper.Map<BuildingFloorInfoDTM, BuildingFloorInfo>(DTmodel);
                    await _buildingFloorInfoRepository.InsertAsync(entity, saveChange);
                    result.result = 1;
                    result.message = "Data Save Successfully!!";
                }
                else
                {
                    result.result = 0;
                    result.message = "Duplicate data found";
                }
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<RResult> BuildingFloorInfoRemove(int BuildingFloorID, bool saveChange)
        {
            try
            {
                RResult result = new();
                if (BuildingFloorID>0)
                {
                    var dbModel = await _buildingFloorInfoRepository.GetByIdAsync(BuildingFloorID);
                    dbModel.IsRemoved = true;
                    await _buildingFloorInfoRepository.UpdateAsync(dbModel, saveChange);
                    result.result = 1;
                    result.message = ReturnMessage.DeleteMessage;
                }
                else
                {
                    result.result = 0;
                    result.message = "data can't found";
                }
                return result;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<RResult> BuildingFloorInfoUpdate(BuildingFloorInfoDTM DTmodelUpdate, bool saveChange)
        {
            try
            {
                RResult result = new();
                if (DTmodelUpdate!=null)
                {
                    var dbModel = await _buildingFloorInfoRepository.GetByIdAsync(DTmodelUpdate.BuildingFloorID);
                    dbModel.BuildingID = DTmodelUpdate.BuildingID;
                    dbModel.FloorName = DTmodelUpdate.FloorName;
                    dbModel.FloorShortName = DTmodelUpdate.FloorShortName;
                    dbModel.FloorSerial = DTmodelUpdate.FloorSerial;
                    dbModel.FloorDescription = DTmodelUpdate.FloorDescription;
                    dbModel.FloorTypeID = DTmodelUpdate.FloorTypeID;
                    await _buildingFloorInfoRepository.UpdateAsync(dbModel, saveChange);
                    result.result = 1;
                    result.message = ReturnMessage.UpdateMessage;

                }
                else
                {
                    result.result = 0;
                    result.message = " data can't found";
                }
                return result;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<List<SelectListItem>> DDLBuildingWiseBuildingFloor(int Building, int FloorType, string predict, CancellationToken cancellationToken)
        {
            return await _buildingFloorInfoRepository.DDLBuildingWiseBuildingFloor(Building, FloorType, predict, cancellationToken);
        }

        public IQueryable<BuildingFloorInfoRM> GetListOfBuildingFloorInfo()
        {
            return _buildingFloorInfoRepository.GetListOfBuildingFloorInfo();
        }
    }
}
