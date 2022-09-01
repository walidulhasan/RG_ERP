using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Business.YarnRackAllocations.Commands.DataTransferModel;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.MaterialsManagement.Business
{
    public interface IYarnRackAllocationService
    {
        Task<RResult> YarnRackAllocationCreate(List<YarnRackAllocationDTM> yarnRackAllocation, CancellationToken cancellationToken);
        Task<decimal> CurrentlyAllocatedQuantity(int subRackID, CancellationToken cancellationToken);
        Task<decimal> YarnStockTransactionWiseCurrentlyAllocatedQuantity(long yarnStockTransactionID, int subRackID, CancellationToken cancellationToken);
        Task<RResult> UpdateRackAllocationAfterIssue(List<YarnRackIssue> issuedYarn, bool saveChanges);
    }
}
