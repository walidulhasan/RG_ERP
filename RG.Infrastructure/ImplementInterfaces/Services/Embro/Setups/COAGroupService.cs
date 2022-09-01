using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.Embro.Setups.COAGroups.Querirs.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.Application.Interfaces.Services.Embro.Setups;
using RG.Application.ViewModel.Embro.Setup.COAGroupings;
using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Embro.Setups
{
    public class COAGroupService : ICOAGroupService
    {
        private readonly ICOAGroupRepository _cOAGroupingRepository;
        private readonly IMapper _mapper;

        public COAGroupService(ICOAGroupRepository cOAGroupingRepository, IMapper mapper)
        {
            _cOAGroupingRepository = cOAGroupingRepository;
            _mapper = mapper;
        }
        public async Task<RResult> Create(COAGroupingCreateVM COAGrouping, bool saveChange=true)
        {
            try
            {
                RResult result = new();
                var IsDuplicate = await _cOAGroupingRepository.IsDuplicateValue(COAGrouping);
                if (!IsDuplicate)
                {
                    var entity = _mapper.Map<COAGroupingCreateVM, COAGroup>(COAGrouping);
                    entity.IsActive = true;
                    await _cOAGroupingRepository.InsertAsync(entity, saveChange);
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

        public async Task<List<SelectListItem>> DDLCOAGroup(int categoryID, string predict, CancellationToken cancellationToken)
        {
            return await _cOAGroupingRepository.DDLCOAGroup(categoryID, predict,cancellationToken);
        }

        public IQueryable<COAGroupingRM> GetListOfCOAGroup()
        {
            return _cOAGroupingRepository.GetListOfCOAGroup();
        }

        public async Task<RResult> Remove(int id, bool saveChange)
        {
            RResult result = new();
            var entity = await _cOAGroupingRepository.GetByIdAsync(id);
            entity.IsRemoved = true;
            var obj = await _cOAGroupingRepository.UpdateAsync(entity, entity.GroupID, saveChange);
            if (obj != null)
            {
                result.result = 1;
                result.message = ReturnMessage.DeleteMessage;
            }
            else
            {
                result.result = 0;
                result.message = ReturnMessage.ErrorMessage;
            }
            return result;
        }

        public async Task<RResult> Update(COAGroupingCreateVM COAGrouping, bool saveChange)
        {
            try
            {
                RResult result = new();
                var IsDuplicate = await _cOAGroupingRepository.IsDuplicateValue(COAGrouping);
                if (!IsDuplicate)
                {
                    var dbModel = await _cOAGroupingRepository.GetByIdAsync(COAGrouping.GroupID);
                    dbModel.GroupCategoryID = COAGrouping.GroupCategoryID;
                    dbModel.GroupName = COAGrouping.GroupName;
                    dbModel.GroupCode = COAGrouping.GroupCode;
                    dbModel.GroupSerial = COAGrouping.GroupSerial;
                    await _cOAGroupingRepository.UpdateAsync(dbModel, saveChange);
                    result.result = 1;
                    result.message = ReturnMessage.UpdateMessage;
                   
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
    }
}
