using Microsoft.EntityFrameworkCore;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
using RG.DBEntities.MaterialsManagement.Business;
using RG.Infrastructure.Persistence.MaterialsManagementDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.MaterialsManagement.Business
{
    public class YarnRackAllocationRepository : GenericRepository<YarnRackAllocation>, IYarnRackAllocationRepository
    {
        private readonly MaterialsManagementDBContext _dbCon;
        private readonly ICurrentUserService _currentUserService;

        public YarnRackAllocationRepository(MaterialsManagementDBContext dbCon, ICurrentUserService currentUserService) : base(dbCon)
        {
            _dbCon = dbCon;
            _currentUserService = currentUserService;
        }

        public async Task<decimal> CurrentlyAllocatedQuantity(int subRackID, CancellationToken cancellationToken)
        {
            var allocatedQty = await _dbCon.YarnRackAllocation
                                .Where(x => x.IsActive == true && x.IsRemoved == false && x.SubRackID == subRackID && x.BalanceQuantity > 0)
                                .SumAsync(x => x.BalanceQuantity);
            return allocatedQty == null ? 0 : allocatedQty.Value;
        }

        public async Task<decimal> YarnStockTransactionWiseCurrentlyAllocatedQuantity(long yarnStockTransactionID, int subRackID, CancellationToken cancellationToken)
        {
            var allocatedQty = await _dbCon.YarnRackAllocation
                                 .Where(x => x.IsActive == true && x.IsRemoved == false && x.SubRackID == subRackID && x.YarnStockTransactionID== yarnStockTransactionID)
                                 .SumAsync(x => x.AllocatedQuantity);
            return allocatedQty;
        }
    }
}
