using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Commands.Create
{
    public class NonReturnableGatePassCreateCommand : IRequest<RResult>
    {
        public NonReturnableGatePassDTM NonReturnableGatePass { get; set; }
    }
    public class NonReturnableGatePassCreateCommandHandler : IRequestHandler<NonReturnableGatePassCreateCommand, RResult>
    {
        private readonly IIC_GatepassMasterService iIC_GatepassMasterService;

        public NonReturnableGatePassCreateCommandHandler(IIC_GatepassMasterService _iIC_GatepassMasterService)
        {
            iIC_GatepassMasterService = _iIC_GatepassMasterService;
        }
        public async Task<RResult> Handle(NonReturnableGatePassCreateCommand request, CancellationToken cancellationToken)
        {
            return await iIC_GatepassMasterService.SaveNonReturnable(request.NonReturnableGatePass, cancellationToken);
        }
    }
}
