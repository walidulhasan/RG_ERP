using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Commands.Update
{
    public class ApprovedGatePassUpdateCommand : IRequest<RResult>
    {
        public long GatePassID { get; set; }
    }
    public class ApprovedGatePassUpdateCommandHandler : IRequestHandler<ApprovedGatePassUpdateCommand, RResult>
    {
        private readonly IIC_GatepassMasterService iC_GatepassMasterService;

        public ApprovedGatePassUpdateCommandHandler(IIC_GatepassMasterService _iC_GatepassMasterService)
        {
            iC_GatepassMasterService = _iC_GatepassMasterService;
        }
        public async Task<RResult> Handle(ApprovedGatePassUpdateCommand request, CancellationToken cancellationToken)
        {
            return await iC_GatepassMasterService.ApprovedGatePass(request.GatePassID, cancellationToken);
        }
    }
}
