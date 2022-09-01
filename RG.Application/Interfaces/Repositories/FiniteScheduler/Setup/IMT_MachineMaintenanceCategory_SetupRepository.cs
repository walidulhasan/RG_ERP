using Microsoft.AspNetCore.Mvc.Rendering;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Setup
{
   public interface IMT_MachineMaintenanceCategory_SetupRepository:IGenericRepository<MT_MachineMaintenanceCategory_Setup>
    {
        Task<List<SelectListItem>> DDLGetMT_MachineMaintenanceCategory(CancellationToken cancellationToken);
    }
}
