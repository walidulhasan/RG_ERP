using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.Embro.Setups.LoanTypes.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.Application.Interfaces.Services.Embro.Setups;
using RG.Application.ViewModel.Embro.Setup.LoanType;
using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Embro.Setups
{
    public class LoanTypeService : ILoanTypeService
    {
        private readonly ILoanTypeRepository _loanTypeRepository;
        private readonly IMapper _mapper;

        public LoanTypeService(ILoanTypeRepository loanTypeRepository, IMapper mapper)
        {
            _loanTypeRepository = loanTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<SelectListItem>> DDLLoanTypeName(CancellationToken cancellationToken)
        {
            return await _loanTypeRepository.DDLLoanTypeName(cancellationToken);
        }

        public async Task<RResult> Remove(int id, bool saveChange)
        {
            RResult result = new();
            var entity = await _loanTypeRepository.GetByIdAsync(id);
            entity.IsRemoved = true;
            var obj = await _loanTypeRepository.UpdateAsync(entity, entity.ID, saveChange);
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

        public async Task<RResult> SaveAndUpdate(LoanTypeCreateVM model)
        {
            try
            {
                var entity = _mapper.Map<LoanTypeCreateVM, LoanType>(model);
                entity.IsActive = true;
                RResult result = new RResult();
                //var IsDuplicate = await _loanTypeRepository.IsDuplicateValue(model);
                //if (!IsDuplicate)
                //{
                    if (model.ID == 0)
                    {
                        var tableCurrentId = await _loanTypeRepository.MaxTableId();
                        entity.ID = tableCurrentId;
                        var obj = await _loanTypeRepository.InsertAsync(entity, true);
                        if (obj != null)
                        {
                            result.result = 1;
                            result.message = "Successfully Insert Loan Type.";
                        }
                        else
                        {
                            result.result = 0;
                            result.message = "Somthing is Missing!!!";
                        }
                    }
                    else
                    {
                        var dbEntity = await _loanTypeRepository.GetByIdAsync(entity.ID);
                        dbEntity.LoanTypeName = entity.LoanTypeName;
                        dbEntity.LoanTypeShortName = entity.LoanTypeShortName;
                        await _loanTypeRepository.UpdateAsync(dbEntity, model.ID, true);
                        result.result = 1;
                        result.message = "Successfully Update Loan Type.";
                    }
                    return result;
                //}
                //else
                //{
                //    result.result = 0;
                //    result.message = "Duplicate data found";
                //}
                //return result;

            }
            catch (Exception e)
            {
                throw;
            }
            
        }

        IQueryable<LoanTypeRM> ILoanTypeService.GetAllGridData()
        {
            return _loanTypeRepository.GetAllGridData();
        }
    }
}
