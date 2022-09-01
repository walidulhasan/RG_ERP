using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Setups.ApprovalConfigMasters.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.ApprovalConfigMasters.Commands.Create
{
    public class CreateApprovalConfigMasterCommand : IRequest<RResult>
    {
        public CreateApprovalConfigMasterDTM CreateApprovalConfigMasterDTM { get; set; }
    }
    public class CreateApprovalConfigMasterCommandHandler : IRequestHandler<CreateApprovalConfigMasterCommand, RResult>
    {
        private readonly IApprovalConfigMasterService _approvalConfigMasterService;

        public CreateApprovalConfigMasterCommandHandler(IApprovalConfigMasterService approvalConfigMasterService)
        {
            _approvalConfigMasterService = approvalConfigMasterService;
        }
        public async Task<RResult> Handle(CreateApprovalConfigMasterCommand request, CancellationToken cancellationToken)
        {
            return await _approvalConfigMasterService.SaveApprovalConfigMaster(request.CreateApprovalConfigMasterDTM);
        }
    }

}
