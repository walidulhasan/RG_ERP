using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.FiniteScheduler.Setup
{
    public class MT_MachineMaintenanceCategory_SetupService : IMT_MachineMaintenanceCategory_SetupService
    {
        private readonly IMT_MachineMaintenanceCategory_SetupRepository mT_MachineMaintenanceCategory_SetupRepository;

        public MT_MachineMaintenanceCategory_SetupService(IMT_MachineMaintenanceCategory_SetupRepository _mT_MachineMaintenanceCategory_SetupRepository)
        {
            mT_MachineMaintenanceCategory_SetupRepository = _mT_MachineMaintenanceCategory_SetupRepository;
        }
        public async Task<List<SelectListItem>> DDLGetMT_MachineMaintenanceCategory(CancellationToken cancellationToken)
        {
            return await mT_MachineMaintenanceCategory_SetupRepository.DDLGetMT_MachineMaintenanceCategory(cancellationToken);
        }
    }
}
