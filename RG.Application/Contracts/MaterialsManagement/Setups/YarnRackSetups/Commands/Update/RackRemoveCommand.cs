using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.YarnRackSetups.Commands.Update
{
    public class RackRemoveCommand:IRequest<RResult>
    {
        public int RackId { get; set; }
    }
    public class RackRemoveCommandHandler : IRequestHandler<RackRemoveCommand, RResult>
    {
        private readonly IYarnRackSetupService _yarnRackService;

        public RackRemoveCommandHandler(IYarnRackSetupService yarnRackService)
        {
            _yarnRackService = yarnRackService;
        }
        public async Task<RResult> Handle(RackRemoveCommand request, CancellationToken cancellationToken)
        {

            return await _yarnRackService.Remove(request.RackId, cancellationToken);
        }
    }
}
