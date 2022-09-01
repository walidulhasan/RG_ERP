using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.ApprovalModule.Queries
{
    public class GetDDLApprovalModuleAllQuery : IRequest<List<SelectListItem>>
    {

    }

    public class GetDDLApprovalModuleAllQueryHandler : IRequestHandler<GetDDLApprovalModuleAllQuery, List<SelectListItem>>
    {
        private readonly IApprovalModulesService _approvalModulesService;

        public GetDDLApprovalModuleAllQueryHandler(IApprovalModulesService approvalModulesService)
        {
            _approvalModulesService = approvalModulesService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLApprovalModuleAllQuery request, CancellationToken cancellationToken)
        {
            return await _approvalModulesService.DDLApprovalModules(cancellationToken);
        }
    }
}
