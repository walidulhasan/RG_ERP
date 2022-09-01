using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.Maxco.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Setup.FabricYarnCount_Setups.Queries
{
    public class GetDDLFabricYarnCountQuery : IRequest<List<SelectListItem>>
    {
        public bool DescriptionInBothTextValue { get; set; } = false;
    }
    public class GetDDLFabricYarnCountQueryHandler : IRequestHandler<GetDDLFabricYarnCountQuery, List<SelectListItem>>
    {
        private readonly IFabricYarnCount_SetupService _fabricYarnCount_SetupService;

        public GetDDLFabricYarnCountQueryHandler(IFabricYarnCount_SetupService fabricYarnCount_SetupService)
        {
            _fabricYarnCount_SetupService = fabricYarnCount_SetupService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLFabricYarnCountQuery request, CancellationToken cancellationToken)
        {
            return await _fabricYarnCount_SetupService.DDLFabricYarnCount(request.DescriptionInBothTextValue, cancellationToken);
        }
    }
}
