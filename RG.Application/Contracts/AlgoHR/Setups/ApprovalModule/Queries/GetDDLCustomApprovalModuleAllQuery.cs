using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.ApprovalModule.Queries
{
    public class GetDDLCustomApprovalModuleAllQuery : IRequest<List<DropDownItem>>
    {
    }
    public class GetDDLCustomApprovalModuleAllQueryHandler : IRequestHandler<GetDDLCustomApprovalModuleAllQuery, List<DropDownItem>>
    {
        private readonly IApprovalModulesService _approvalModulesService;

        public GetDDLCustomApprovalModuleAllQueryHandler(IApprovalModulesService approvalModulesService)
        {
            _approvalModulesService = approvalModulesService;
        }

        public async Task<List<DropDownItem>> Handle(GetDDLCustomApprovalModuleAllQuery request, CancellationToken cancellationToken)
        {
            return await _approvalModulesService.DDLCustomApprovalModules(cancellationToken);
        }
    }
}