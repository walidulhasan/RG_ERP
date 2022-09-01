using Microsoft.AspNetCore.Mvc.Rendering;
using RG.DBEntities.FiniteScheduler.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Setup
{
    public interface IMT_MachineGroupRepository : IGenericRepository<MT_MachineGroup>
    {
        Task<List<SelectListItem>> GetDDLMachineGroup(CancellationToken cancellationToken);
    }
}
