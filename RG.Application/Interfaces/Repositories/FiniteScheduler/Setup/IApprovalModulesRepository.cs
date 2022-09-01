using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Setup
{
    public interface IApprovalModulesRepository :IGenericRepository<ApprovalModules>
    {
       
        Task<List<SelectListItem>> DDLApprovalModules(CancellationToken cancellationToken = default);
        Task<List<DropDownItem>> DDLCustomApprovalModules(CancellationToken cancellationToken = default);
    }
}
