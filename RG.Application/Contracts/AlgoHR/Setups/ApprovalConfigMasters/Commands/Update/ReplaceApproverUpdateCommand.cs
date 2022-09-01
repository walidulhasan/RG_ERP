using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Setups.ApprovalConfigMasters.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.ApprovalConfigMasters.Commands.Update
{
    public class ReplaceApproverUpdateCommand:IRequest<RResult>
    {
        public UpdateReplaceApproverDTM ReplaceApprover { get; set; }
    }
    public class ReplaceApproverUpdateCommandHandler : IRequestHandler<ReplaceApproverUpdateCommand, RResult>
    {
        private readonly IApprovalConfigMasterService _approvalConfigMasterService;

        public ReplaceApproverUpdateCommandHandler(IApprovalConfigMasterService approvalConfigMasterService)
        {
            _approvalConfigMasterService = approvalConfigMasterService;
        }
        public async Task<RResult> Handle(ReplaceApproverUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _approvalConfigMasterService.ReplaceApprover(request.ReplaceApprover, cancellationToken);
        }
    }
}
