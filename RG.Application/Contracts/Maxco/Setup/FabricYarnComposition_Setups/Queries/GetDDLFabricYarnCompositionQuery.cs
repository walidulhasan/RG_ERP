using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Setup.FabricYarnComposition_Setups.Queries
{
    public class GetDDLFabricYarnCompositionQuery:IRequest<List<SelectListItem>>
    {
    }
    public class GetDDLFabricYarnCompositionQueryHandler : IRequestHandler<GetDDLFabricYarnCompositionQuery, List<SelectListItem>>
    {
        private readonly IFabricYarnComposition_SetupService _fabricYarnComposition_SetupService;

        public GetDDLFabricYarnCompositionQueryHandler(IFabricYarnComposition_SetupService fabricYarnComposition_SetupService)
        {
            _fabricYarnComposition_SetupService = fabricYarnComposition_SetupService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLFabricYarnCompositionQuery request, CancellationToken cancellationToken)
        {
            return await _fabricYarnComposition_SetupService.DDLFabricYarnComposition(cancellationToken);
        }
    }
}
