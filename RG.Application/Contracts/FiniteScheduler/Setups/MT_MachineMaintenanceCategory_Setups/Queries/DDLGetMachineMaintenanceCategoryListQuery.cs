using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.MT_MachineMaintenanceCategory_Setups.Queries
{
  public  class DDLGetMachineMaintenanceCategoryListQuery:IRequest<List<SelectListItem>>
    {

    }
    public class DDLGetMachineMaintenanceCategoryListQueryHandler : IRequestHandler<DDLGetMachineMaintenanceCategoryListQuery, List<SelectListItem>>
    {
        private readonly IMT_MachineMaintenanceCategory_SetupService mT_MachineMaintenanceCategory_SetupService;

        public DDLGetMachineMaintenanceCategoryListQueryHandler(IMT_MachineMaintenanceCategory_SetupService _mT_MachineMaintenanceCategory_SetupService)
        {
            mT_MachineMaintenanceCategory_SetupService = _mT_MachineMaintenanceCategory_SetupService;
        }
        public async Task<List<SelectListItem>> Handle(DDLGetMachineMaintenanceCategoryListQuery request, CancellationToken cancellationToken)
        {
            return await mT_MachineMaintenanceCategory_SetupService.DDLGetMT_MachineMaintenanceCategory(cancellationToken);
        }
    }
}
