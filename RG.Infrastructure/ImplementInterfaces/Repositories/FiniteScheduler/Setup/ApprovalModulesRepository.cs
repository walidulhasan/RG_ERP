using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.DBEntities.FiniteScheduler.Setup;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.Setup
{
    public class ApprovalModulesRepository : GenericRepository<ApprovalModules>, IApprovalModulesRepository
    {
        private readonly FiniteSchedulerDBContext _dbCon;

        public ApprovalModulesRepository( FiniteSchedulerDBContext dbCon):base(dbCon)
        {
            _dbCon = dbCon;

        }
        public async Task<List<SelectListItem>> DDLApprovalModules(CancellationToken cancellationToken = default)
        {
            return await _dbCon.ApprovalModules.Where(b => b.IsRemoved == false && b.IsActive == true)
                .Select(s => new SelectListItem()
                {
                    Text = s.ApprovalModuleName,
                    Value = s.ApprovalModuleID.ToString()                    
                }).ToListAsync(cancellationToken);
        }

        public async Task<List<DropDownItem>> DDLCustomApprovalModules(CancellationToken cancellationToken = default)
        {
            return await _dbCon.ApprovalModules.Where(b => b.IsRemoved == false && b.IsActive == true)
                .Select(s => new DropDownItem()
                {
                    Text = s.ApprovalModuleName,
                    Value = s.ApprovalModuleID.ToString(),
                    Custom1= s.IsMasterConfigNeeded.ToString()
                }).ToListAsync(cancellationToken);
        }

        
    }
}
