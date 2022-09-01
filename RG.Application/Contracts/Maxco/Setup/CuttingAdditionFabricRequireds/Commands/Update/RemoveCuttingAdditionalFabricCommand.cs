using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_Machine_Setups.Commands.Update;
using RG.Application.Interfaces.Services.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Setup.CuttingAdditionFabricRequireds.Commands.Update
{
    public class RemoveCuttingAdditionalFabricCommand : IRequest<RResult>
    {
        public int ID { get; set; }
    }
    public class RemoveCuttingAddigionalFabricHandelar : IRequestHandler<RemoveCuttingAdditionalFabricCommand, RResult>
    {
        private readonly ICuttingAdditionFabricRequiredService cuttingAdditionFabricRequiredService;

        public RemoveCuttingAddigionalFabricHandelar(ICuttingAdditionFabricRequiredService _cuttingAdditionFabricRequiredService)
        {
            cuttingAdditionFabricRequiredService = _cuttingAdditionFabricRequiredService;
        }
        public async Task<RResult> Handle(RemoveCuttingAdditionalFabricCommand request, CancellationToken cancellationToken)
        {
            return await cuttingAdditionFabricRequiredService.RemoveCuttingAdditionFabricRequired(request.ID, true);
        }
    }
}
