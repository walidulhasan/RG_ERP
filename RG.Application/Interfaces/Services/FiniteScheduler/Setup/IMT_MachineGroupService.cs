using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.FiniteScheduler.Setup
{
    public interface IMT_MachineGroupService
    {
        Task<List<SelectListItem>> GetDDLMachineGroup(CancellationToken cancellationToken);
    }
}
