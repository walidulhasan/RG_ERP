using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Business.YarnRackAllocations.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.YarnRackAllocations.Commands.Create
{
    public class YarnRackAllocationCreateCommand:IRequest<RResult>
    {
        public List<YarnRackAllocationDTM> YarnRackAllocation { get; set; }
    }
    public class YarnRackAllocationCreateCommandHandler : IRequestHandler<YarnRackAllocationCreateCommand, RResult>
    {
        private readonly IYarnRackAllocationService _yarnRackAllocationService;

        public YarnRackAllocationCreateCommandHandler(IYarnRackAllocationService yarnRackAllocationService)
        {
            _yarnRackAllocationService = yarnRackAllocationService;
        }
        public async Task<RResult> Handle(YarnRackAllocationCreateCommand request, CancellationToken cancellationToken)
        {
            return await _yarnRackAllocationService.YarnRackAllocationCreate(request.YarnRackAllocation, cancellationToken);
        }
    }
}
