using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.Maxco.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Setup.Plan_DyeingProductionLocation_Setup.Queries
{
    public class GetDDLDyeingProductionLocationQuery : IRequest<List<SelectListItem>>
    {
    }

    public class GetDDLDyeingProductionLocationQueryHandler : IRequestHandler<GetDDLDyeingProductionLocationQuery, List<SelectListItem>>
    {
        private readonly IPlan_DyeingProductionLocation_SetupService _plan_DyeingProductionLocation_SetupService;

        public GetDDLDyeingProductionLocationQueryHandler(IPlan_DyeingProductionLocation_SetupService plan_DyeingProductionLocation_SetupService)
        {
            _plan_DyeingProductionLocation_SetupService = plan_DyeingProductionLocation_SetupService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLDyeingProductionLocationQuery request, CancellationToken cancellationToken)
        {
            return await _plan_DyeingProductionLocation_SetupService.DDLPlan_DyeingProductionLocation(cancellationToken);
        }
    }
}
