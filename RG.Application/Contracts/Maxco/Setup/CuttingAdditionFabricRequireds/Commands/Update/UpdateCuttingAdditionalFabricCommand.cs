using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.Setup.CuttingAdditionFabricRequireds.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Setup.CuttingAdditionFabricRequireds.Commands.Update
{
    public class UpdateCuttingAdditionalFabricCommand : IRequest<RResult>
    {
        public CuttingAdditionalFabricDTM cuttingAdditionalFabricDTM { get; set; }
        public bool UpdateChange { get; set; }
    }
    public class UpdateCuttingAdditionalFabricCommandHelnlar : IRequestHandler<UpdateCuttingAdditionalFabricCommand, RResult>
    {
        private readonly ICuttingAdditionFabricRequiredService cuttingAdditionFabricRequiredService;

        public UpdateCuttingAdditionalFabricCommandHelnlar(ICuttingAdditionFabricRequiredService _cuttingAdditionFabricRequiredService)
        {
            cuttingAdditionFabricRequiredService = _cuttingAdditionFabricRequiredService;
        }
        public async Task<RResult> Handle(UpdateCuttingAdditionalFabricCommand request, CancellationToken cancellationToken)
        {
            return await cuttingAdditionFabricRequiredService.SaveAndUpdate(request.cuttingAdditionalFabricDTM);
        }
    }
}
