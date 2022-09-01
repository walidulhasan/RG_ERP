using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.MaterialsManagement.Business
{
    public interface IYarnRackAllocationRepository:IGenericRepository<YarnRackAllocation>
    {
        Task<decimal> CurrentlyAllocatedQuantity(int subRackID,CancellationToken cancellationToken);
        Task<decimal> YarnStockTransactionWiseCurrentlyAllocatedQuantity(long yarnStockTransactionID, int subRackID, CancellationToken cancellationToken);
    }
}
