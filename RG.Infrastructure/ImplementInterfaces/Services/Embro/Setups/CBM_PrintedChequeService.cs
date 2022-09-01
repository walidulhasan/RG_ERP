using RG.Application.Common.Models;
using RG.Application.Contracts.Embro.Setups.CBM_PrintedCheques.Commands.DataTransferModel;
using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.Application.Interfaces.Services.Embro.Setups;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Embro.Setups
{
    public class CBM_PrintedChequeService : ICBM_PrintedChequeService
    {
        private readonly ICBM_PrintedChequeRepository _cBM_PrintedChequeRepository;

        public CBM_PrintedChequeService(ICBM_PrintedChequeRepository cBM_PrintedChequeRepository)
        {
            _cBM_PrintedChequeRepository = cBM_PrintedChequeRepository;
        }
        public async Task<RResult> UpdateChequeStatus(List<UpdateChequeStatusDTM> SelectedData, bool saveChanges = true)
        {
            RResult result = new();
            try
            {
                foreach (var item in SelectedData)
                {
                    var entity = await _cBM_PrintedChequeRepository.GetByIdAsync(item.ChqID);
                    entity.Status = item.UpdatedStatusID;
                    entity.TransactionDate = item.ClearingDate;
                    await _cBM_PrintedChequeRepository.UpdateAsync(entity, saveChanges);
                }
                result.result = 1;
                result.message = ReturnMessage.UpdateMessage;
            }
            catch (Exception e)
            {
                throw;
            }
            return result;
        }
    }
}
