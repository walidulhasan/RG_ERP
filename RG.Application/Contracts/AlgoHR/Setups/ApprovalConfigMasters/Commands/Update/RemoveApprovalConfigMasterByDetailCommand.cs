using MediatR;
using RG.Application.Common.Models;
using RG.Application.Common.Security;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.ApprovalConfigMasters.Commands.Update
{

    [CheckAuthorize(Policy = "Permission_FiniteScheduler_ApprovalConfiguration_Update")]
    public class RemoveApprovalConfigMasterByDetailCommand : IRequest<RResult>
    {
        public int MasterID { get; set; }
        public int DetailID { get; set; }
    }
    public class RemoveApprovalConfigMasterByDetailCommandHandler : IRequestHandler<RemoveApprovalConfigMasterByDetailCommand, RResult>
    {
        private readonly IApprovalConfigMasterService _approvalConfigMasterService;

        public RemoveApprovalConfigMasterByDetailCommandHandler(IApprovalConfigMasterService approvalConfigMasterService)
        {
            _approvalConfigMasterService = approvalConfigMasterService;
        }
        public async Task<RResult> Handle(RemoveApprovalConfigMasterByDetailCommand request, CancellationToken cancellationToken)
        {
            return await _approvalConfigMasterService.RemoveApprovalConfigMasterByDetail(request.MasterID, request.DetailID);
        }
    }
}
