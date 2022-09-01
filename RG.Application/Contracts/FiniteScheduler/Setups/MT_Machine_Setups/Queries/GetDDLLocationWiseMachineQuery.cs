using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.MT_Machine_Setups.Queries
{
    public class GetDDLLocationWiseMachineQuery:IRequest<List<SelectListItem>>
    {
        public int LocationID { get; set; }
    }
    public class GetDDLLocationWiseMachineQueryHandler : IRequestHandler<GetDDLLocationWiseMachineQuery, List<SelectListItem>>
    {
        private readonly IMT_Machine_SetupService mT_Machine_SetupService;

        public GetDDLLocationWiseMachineQueryHandler(IMT_Machine_SetupService _mT_Machine_SetupService)
        {
            mT_Machine_SetupService = _mT_Machine_SetupService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLLocationWiseMachineQuery request, CancellationToken cancellationToken)
        {
            return await mT_Machine_SetupService.DDLLocationWiseMachine(request.LocationID, cancellationToken);
        }
    }
}
