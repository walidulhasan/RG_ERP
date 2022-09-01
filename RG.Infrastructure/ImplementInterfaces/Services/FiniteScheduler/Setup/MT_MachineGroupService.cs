using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.FiniteScheduler.Setup
{
    public class MT_MachineGroupService : IMT_MachineGroupService
    {
        private readonly IMT_MachineGroupRepository mT_MachineGroupRepository;

        public MT_MachineGroupService(IMT_MachineGroupRepository _mT_MachineGroupRepository)
        {
            mT_MachineGroupRepository = _mT_MachineGroupRepository;
        }
        public async Task<List<SelectListItem>> GetDDLMachineGroup(CancellationToken cancellationToken)
        {
            return await mT_MachineGroupRepository.GetDDLMachineGroup(cancellationToken);
        }
    }
}
