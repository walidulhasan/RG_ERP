using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using RG.Application.ViewModel.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.YarnRackSetups.Commands.Create
{
    public class YarnRackCreateCommand : IRequest<RResult>
    {
        public YarnRackCreateVM yarnRackCreateVM { get; set; }
    }
    public class YarnRackCreateCommandHandler : IRequestHandler<YarnRackCreateCommand, RResult>
    {
        private readonly IYarnRackSetupService _yarnRackService;

        public YarnRackCreateCommandHandler(IYarnRackSetupService yarnRackService)
        {
            _yarnRackService = yarnRackService;
        }
        public async Task<RResult> Handle(YarnRackCreateCommand request, CancellationToken cancellationToken)
        {
            return await _yarnRackService.Create(request.yarnRackCreateVM, true);
        }
    }
}
