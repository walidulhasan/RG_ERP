using MediatR;
using RG.Application.Contracts.Maxco.Setup.Plan_DyeingProductionLocation_Setup.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Setup.Plan_DyeingProductionLocation_Setup.Queries
{
    public class GetDyeingProductionLocationByIDQuery :IRequest<ProductionLocationRM>
    {
        public int ProductionLocationID { get; set; }
    }
    public class GetDyeingProductionLocationByIDQueryHandler : IRequestHandler<GetDyeingProductionLocationByIDQuery, ProductionLocationRM>
    {
        private readonly IPlan_DyeingProductionLocation_SetupService _plan_DyeingProductionLocation_SetupService;

        public GetDyeingProductionLocationByIDQueryHandler(IPlan_DyeingProductionLocation_SetupService plan_DyeingProductionLocation_SetupService)
        {
            _plan_DyeingProductionLocation_SetupService = plan_DyeingProductionLocation_SetupService;
        }
        public async Task<ProductionLocationRM> Handle(GetDyeingProductionLocationByIDQuery request, CancellationToken cancellationToken)
        {
            return await _plan_DyeingProductionLocation_SetupService.GetDyeingProductionLocationByID(request.ProductionLocationID, cancellationToken);
        }
    }
}
