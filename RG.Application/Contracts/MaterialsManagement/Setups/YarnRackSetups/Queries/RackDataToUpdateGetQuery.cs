using MediatR;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using RG.Application.ViewModel.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.YarnRackSetups.Queries
{
    public class RackDataToUpdateGetQuery : IRequest<YarnRackCreateVM>
    {
        public int rackID { get; set; }
    }
    public class RackDataToUpdateGetQueryHandler : IRequestHandler<RackDataToUpdateGetQuery, YarnRackCreateVM>
    {
        private readonly IYarnRackSetupService _yarnRackSetupService;

        public RackDataToUpdateGetQueryHandler(IYarnRackSetupService yarnRackSetupService)
        {
            _yarnRackSetupService = yarnRackSetupService;
        }
        public async Task<YarnRackCreateVM> Handle(RackDataToUpdateGetQuery request, CancellationToken cancellationToken)
        {
            return await _yarnRackSetupService.GetDataToUpdate(request.rackID, cancellationToken);
        }
    }
}
