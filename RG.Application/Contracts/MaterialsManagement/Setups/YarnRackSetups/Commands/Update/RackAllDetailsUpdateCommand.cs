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

namespace RG.Application.Contracts.MaterialsManagement.Setups.YarnRackSetups.Commands.Update
{
    public class RackAllDetailsUpdateCommand : IRequest<RResult>
    {
        public YarnRackCreateVM yarnRackCreateVM { get; set; }
    }
    public class RackAllDetailsUpdateCommandHanaler : IRequestHandler<RackAllDetailsUpdateCommand, RResult>
    {
        private readonly IYarnRackSetupService _yarnRackService;

        public RackAllDetailsUpdateCommandHanaler(IYarnRackSetupService yarnRackService)
        {
            _yarnRackService = yarnRackService;
        }
        public async Task<RResult> Handle(RackAllDetailsUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _yarnRackService.UpdateRackAllDetail(request.yarnRackCreateVM, cancellationToken);

        }
    }
}
