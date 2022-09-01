using MediatR;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.YarnRackAllocations.Queries
{
    public class GetCurrentlyAllocatedQuantityQuery : IRequest<Decimal>
    {
        public int SubRackID { get; set; }
    }
    public class GetCurrentlyAllocatedQuantityQueryHandler : IRequestHandler<GetCurrentlyAllocatedQuantityQuery, decimal>
    {
        private readonly IYarnRackAllocationService _yarnRackAllocationService;

        public GetCurrentlyAllocatedQuantityQueryHandler(IYarnRackAllocationService yarnRackAllocationService)
        {
            _yarnRackAllocationService = yarnRackAllocationService;
        }
        public async Task<decimal> Handle(GetCurrentlyAllocatedQuantityQuery request, CancellationToken cancellationToken)
        {
            return await _yarnRackAllocationService.CurrentlyAllocatedQuantity(request.SubRackID, cancellationToken);
        }
    }
}
