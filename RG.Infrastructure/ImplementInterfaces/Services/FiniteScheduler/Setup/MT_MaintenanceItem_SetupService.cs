using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceItem_Setups.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceItem_Setups.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using RG.Application.ViewModel.FiniteScheduler.Setup.MaintenanceItem;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.FiniteScheduler.Setup
{
    public class MT_MaintenanceItem_SetupService : IMT_MaintenanceItem_SetupService
    {
        private readonly IMT_MaintenanceItem_SetupRepository mT_MaintenanceItem_SetupRepository;
        private readonly IMapper mapper;

        public MT_MaintenanceItem_SetupService(IMT_MaintenanceItem_SetupRepository _mT_MaintenanceItem_SetupRepository,
            IMapper _mapper)
        {
            mT_MaintenanceItem_SetupRepository = _mT_MaintenanceItem_SetupRepository;
            mapper = _mapper;
        }
        public async Task<List<SelectListItem>> DDLGetMT_MaintenanceItemList(int itemCategoryID, CancellationToken cancellationToken)
        {
            return await mT_MaintenanceItem_SetupRepository.DDLGetMT_MaintenanceItemList(itemCategoryID, cancellationToken);
        }

        public IQueryable<MaintenanceItemRM> GetListOFMaintenanceItem(int ItemCategoryID)
        {
            return mT_MaintenanceItem_SetupRepository.GetListOFMaintenanceItem(ItemCategoryID);
        }

        public async Task<RResult> RemoveMaintenanceItem(int itemID, bool saveChange)
        {
            var entity = await mT_MaintenanceItem_SetupRepository.GetByIdAsync(itemID);
            entity.IsRemoved = true;
            return await mT_MaintenanceItem_SetupRepository.UpdateMT_MaintenanceItem(entity, saveChange);
        }

        public async Task<RResult> SaveMT_MaintenanceItem(MT_MaintenanceItem_SetupDTM model, bool saveChange)
        {
            var rResult = await mT_MaintenanceItem_SetupRepository.CheckDuplicateMaintenanceItem(model.ItemName);
            if (!rResult.isDuplicate)
            {
                var dbModel = mapper.Map<MT_MaintenanceItem_SetupDTM, MT_MaintenanceItem_Setup>(model);
                return await mT_MaintenanceItem_SetupRepository.SaveMT_MaintenanceItem(dbModel, saveChange);
            }
            else
            {
                rResult.result = 0;
                rResult.message = ReturnMessage.DuplicateMessage;
                return rResult;
            }
        }

        public async Task<RResult> UpdateMT_MaintenanceItem(MT_MaintenanceItem_SetupDTM model, bool saveChange)
        {
            var rResult = await mT_MaintenanceItem_SetupRepository.CheckDuplicateMaintenanceItem(model.ItemName,model.ID);
            if (!rResult.isDuplicate)
            {
                var dbModel = await mT_MaintenanceItem_SetupRepository.GetByIdAsync(model.ID);
            dbModel.ItemName = model.ItemName;
            dbModel.ItemCategoryID = model.ItemCategoryID;
            return await mT_MaintenanceItem_SetupRepository.UpdateMT_MaintenanceItem(dbModel, saveChange);
            }
            else
            {
                rResult.result = 0;
                rResult.message = ReturnMessage.DuplicateMessage;
                return rResult;
            }
        }
    }
}
