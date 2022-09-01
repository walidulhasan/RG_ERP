using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Setups.YarnRackSetups.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Setups;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using RG.Application.ViewModel.MaterialsManagement.Setup;
using RG.DBEntities.MaterialsManagement.Setup;
using RG.Infrastructure.ImplementInterfaces.Repositories.MaterialsManagement.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Setups
{
    public class YarnRackSetupService : IYarnRackSetupService
    {
        private readonly IMapper _mapper;
        private readonly IYarnRackSetupRepository _yarnRackRepository;
        private readonly IYarnSubRackSetupRepository _yarnSubRackSetupRepository;

        public YarnRackSetupService(IMapper mapper, IYarnRackSetupRepository yarnRackRepository, IYarnSubRackSetupRepository yarnSubRackSetupRepository)
        {
            _mapper = mapper;
            _yarnRackRepository = yarnRackRepository;
            _yarnSubRackSetupRepository = yarnSubRackSetupRepository;
        }
        public async Task<RResult> Create(YarnRackCreateVM model, bool saveChange = true)
        {
            try
            {
                RResult result = new();
                var entity = _mapper.Map<YarnRackCreateVM, YarnRackSetup>(model);

                entity.IsActive = true;
                entity.YarnSubRackSetup.ForEach(x => { x.IsActive = true; });
                var obj = await _yarnRackRepository.InsertAsync(entity, saveChange);
                if (obj != null)
                {
                    result.result = 1;
                    result.message = ReturnMessage.InsertMessage;

                }
                else
                {
                    result.result = 0;
                    result.message = ReturnMessage.ErrorMessage;
                }
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<List<SelectListItem>> DDLBuildingFloorWiseRack(int buildingFloorID, CancellationToken cancellationToken)
        {
            return await _yarnRackRepository.DDLBuildingFloorWiseRack(buildingFloorID, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLLotNowithRackWiseLotno(int RackID,string predict, CancellationToken cancellationToken)
        {
            return await _yarnRackRepository.DDLLotNowithRackWiseLotno(RackID,predict, cancellationToken);
        }

        public async Task<YarnRackCreateVM> GetDataToUpdate(int id, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _yarnRackRepository.GetByIdAsync(id, cancellationToken);

                var model = _mapper.Map<YarnRackSetup, YarnRackCreateVM>(entity);
                model.YarnSubRackSetup = await _yarnSubRackSetupRepository.SubRackEdit(id, cancellationToken);
                return model;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<List<YarnRackSetupInfoRM>> GetFloorWiseRackInfo(int buildingFloorID, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _yarnRackRepository.GetFloorWiseRackInfo(buildingFloorID, cancellationToken);
                var returnData = _mapper.Map<List<YarnRackSetup>, List<YarnRackSetupInfoRM>>(data);
                return returnData;
            }
            catch (Exception e)
            {

                throw;
            }
           
        }

        public async Task<RResult> Remove(int rackID, CancellationToken cancellationToken)
        {
            return await _yarnRackRepository.Remove(rackID, cancellationToken);
        }

        public async Task<RResult> UpdateRackAllDetail(YarnRackCreateVM model, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<YarnRackCreateVM, YarnRackSetup>(model);
            return await _yarnRackRepository.UpdateRackAllDetail(entity, cancellationToken);
        }
    }
}
