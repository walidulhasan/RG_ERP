using MediatR;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.YarnRackAllocations.Queries
{
    public class GetYarnStockTransactionWiseCurrentlyAllocatedQuantityQuery : IRequest<Decimal>
    {
        public long YarnStockTransactionID { get; set; }
        public int SubRackID { get; set; }
    }
    public class GetYarnStockTransactionWiseCurrentlyAllocatedQuantityQueryHandler : IRequestHandler<GetYarnStockTransactionWiseCurrentlyAllocatedQuantityQuery, decimal>
    {
        private readonly IYarnRackAllocationService _yarnRackAllocationService;

        public GetYarnStockTransactionWiseCurrentlyAllocatedQuantityQueryHandler(IYarnRackAllocationService yarnRackAllocationService)
        {
            _yarnRackAllocationService = yarnRackAllocationService;
        }
        public async Task<decimal> Handle(GetYarnStockTransactionWiseCurrentlyAllocatedQuantityQuery request, CancellationToken cancellationToken)
        {
            return await _yarnRackAllocationService.YarnStockTransactionWiseCurrentlyAllocatedQuantity(request.YarnStockTransactionID, request.SubRackID, cancellationToken);
        }
       
    }
}
