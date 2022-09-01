using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.Buisness.Plan_OrderFollowups.Commands.Create;
using RG.Application.Contracts.Maxco.Setup.CuttingAdditionFabricRequireds.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Setup.CuttingAdditionFabricRequireds.Commands.Create
{
    public class CreateCuttingAdditionalFabricCommand : IRequest<RResult>
    {
        public CuttingAdditionalFabricDTM AditionalFabric { get; set; }
    }
    public class CreateCuttingAdditionalFabricCommandHandler : IRequestHandler<CreateCuttingAdditionalFabricCommand, RResult>
    {
        private readonly ICuttingAdditionFabricRequiredService cuttingAdditionFabricRequiredService;

        public CreateCuttingAdditionalFabricCommandHandler(ICuttingAdditionFabricRequiredService cuttingAdditionFabricRequiredService)
        {
            this.cuttingAdditionFabricRequiredService = cuttingAdditionFabricRequiredService;
        }
        public async  Task<RResult> Handle(CreateCuttingAdditionalFabricCommand request, CancellationToken cancellationToken)
        {
            return await cuttingAdditionFabricRequiredService.SaveAndUpdate(request.AditionalFabric);
        }
    }
}
