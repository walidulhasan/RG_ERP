using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.DBEntities.AlgoHR.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Setup
{
    public interface IApprovalModulesService
    {
        Task<ApprovalModules> GetApprovalModulesByName(string moduleName, CancellationToken cancellationToken = default);
        Task<List<SelectListItem>> DDLApprovalModules(CancellationToken cancellationToken = default);
        Task<List<DropDownItem>> DDLCustomApprovalModules(CancellationToken cancellationToken = default);
    }
}
