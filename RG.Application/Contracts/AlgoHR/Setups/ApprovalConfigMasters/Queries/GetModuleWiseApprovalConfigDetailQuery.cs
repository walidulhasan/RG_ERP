using MediatR;
using RG.Application.Common.Security;
using RG.Application.Contracts.AlgoHR.Setups.ApprovalConfigMasters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.ApprovalConfigMasters.Queries
{
    [CheckAuthorize(Policy = "Permission_FiniteScheduler_ApprovalConfiguration_GET")]
    public class GetModuleWiseApprovalConfigDetailQuery : IRequest<List<ApprovalConfigurationRM>>
    {
        public ModuleWiseApprovalConfigQM QueryModel { get; set; }
    }
    public class GetModuleWiseApprovalConfigDetailQueryHandler : IRequestHandler<GetModuleWiseApprovalConfigDetailQuery, List<ApprovalConfigurationRM>>
    {
        private readonly IApprovalConfigMasterService _approvalConfigMasterService;

        public GetModuleWiseApprovalConfigDetailQueryHandler(IApprovalConfigMasterService approvalConfigMasterService)
        {
            _approvalConfigMasterService = approvalConfigMasterService;
        }
        public async Task<List<ApprovalConfigurationRM>> Handle(GetModuleWiseApprovalConfigDetailQuery request, CancellationToken cancellationToken)
        {
            return await _approvalConfigMasterService.GetModuleWiseApprovalConfigDetail(request.QueryModel, cancellationToken);
        }
    }
}
