using AutoMapper;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Business.YarnRackAllocations.Commands.DataTransferModel;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Business
{
    public class YarnRackAllocationService : IYarnRackAllocationService
    {
        private readonly IYarnRackAllocationRepository _yarnRackAllocationRepository;
        private readonly IMapper _mapper;

        public YarnRackAllocationService(IYarnRackAllocationRepository yarnRackAllocationRepository,IMapper mapper)
        {
            _yarnRackAllocationRepository = yarnRackAllocationRepository;
            _mapper = mapper;
        }
        public async Task<decimal> CurrentlyAllocatedQuantity(int subRackID, CancellationToken cancellationToken)
        {
            return await _yarnRackAllocationRepository.CurrentlyAllocatedQuantity(subRackID, cancellationToken);
        }

        public async Task<RResult> UpdateRackAllocationAfterIssue(List<YarnRackIssue> issuedYarn, bool saveChanges=true)
        {
            RResult rResult = new();
            foreach (var item in issuedYarn)
            {
                var entity = await _yarnRackAllocationRepository.GetByIdAsync(item.RackAllocationID);
                entity.BalanceQuantity -= item.IssueQuantity;
                await _yarnRackAllocationRepository.UpdateAsync(entity, saveChanges);                
            }
            rResult.result = 1;
            rResult.message = ReturnMessage.InsertMessage;
            return rResult;
            
        }

        public async Task<RResult> YarnRackAllocationCreate(List<YarnRackAllocationDTM> yarnRackAllocation, CancellationToken cancellationToken)
        {
            RResult result = new();
            try
            {
                var entities = _mapper.Map<List<YarnRackAllocationDTM>, List<YarnRackAllocation>>(yarnRackAllocation);

                var entitiesToInsert = entities.Where(x => x.RackAllocationID == 0).ToList();
                var entitiesToUpdate = entities.Where(x => x.RackAllocationID > 0).ToList();
                await _yarnRackAllocationRepository.InsertAsync(entitiesToInsert, true);
                foreach (var itemToUpdate in entitiesToUpdate)
                {
                    var dbEntity = await _yarnRackAllocationRepository.GetByIdAsync(itemToUpdate.RackAllocationID);
                    dbEntity.AllocatedQuantity = itemToUpdate.AllocatedQuantity;
                    dbEntity.BalanceQuantity = itemToUpdate.BalanceQuantity;
                    await _yarnRackAllocationRepository.UpdateAsync(dbEntity, true);
                }



                result.result = 1;
                result.message = ReturnMessage.InsertMessage;

            }
            catch (Exception e)
            {
                result.result = 0;
                result.message = ReturnMessage.ErrorMessage;
            }
            return result;

        }

        public async Task<decimal> YarnStockTransactionWiseCurrentlyAllocatedQuantity(long yarnStockTransactionID, int subRackID, CancellationToken cancellationToken)
        {
            return await _yarnRackAllocationRepository.YarnStockTransactionWiseCurrentlyAllocatedQuantity(yarnStockTransactionID, subRackID, cancellationToken);
        }
    }
}
