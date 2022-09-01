using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.MT_MachineGroup.Queries
{
    public class GetDDLMachineGroupQuery:IRequest<List<SelectListItem>>
    {

    }
    public class GetDDLMachineGroupQueryHandler : IRequestHandler<GetDDLMachineGroupQuery, List<SelectListItem>>
    {
        private readonly IMT_MachineGroupService mT_MachineGroupService;

        public GetDDLMachineGroupQueryHandler(IMT_MachineGroupService _mT_MachineGroupService)
        {
            mT_MachineGroupService = _mT_MachineGroupService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLMachineGroupQuery request, CancellationToken cancellationToken)
        {
            return await mT_MachineGroupService.GetDDLMachineGroup(cancellationToken);
        }
    }
}
