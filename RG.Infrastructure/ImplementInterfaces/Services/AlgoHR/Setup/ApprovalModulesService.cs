using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using RG.DBEntities.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Setup
{
    public class ApprovalModulesService : IApprovalModulesService
    {
        private readonly IApprovalModulesRepository _approvalModulesRepository;

        public ApprovalModulesService(IApprovalModulesRepository approvalModulesRepository)
        {
            _approvalModulesRepository = approvalModulesRepository;
        }
        public async Task<List<SelectListItem>> DDLApprovalModules(CancellationToken cancellationToken = default)
        {
            return await _approvalModulesRepository.DDLApprovalModules(cancellationToken);
        }

        public async Task<List<DropDownItem>> DDLCustomApprovalModules(CancellationToken cancellationToken = default)
        {
            return await _approvalModulesRepository.DDLCustomApprovalModules(cancellationToken);
        }

        public async Task<ApprovalModules> GetApprovalModulesByName(string moduleName, CancellationToken cancellationToken = default)
        {
            return await _approvalModulesRepository.FindAsync(x => x.ApprovalModuleName == moduleName && x.IsActive == true && x.IsRemoved == false);
        }
    }
}
