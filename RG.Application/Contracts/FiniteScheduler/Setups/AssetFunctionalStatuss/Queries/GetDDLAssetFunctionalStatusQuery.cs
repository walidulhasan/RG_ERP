using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetFunctionalStatuss.Queries
{
    public class GetDDLAssetFunctionalStatusQuery : IRequest<List<SelectListItem>>
    {
    }
    public class GetDDLAssetFunctionalStatusQueryHandler : IRequestHandler<GetDDLAssetFunctionalStatusQuery, List<SelectListItem>>
    {
        private readonly IAssetFunctionalStatusService _assetFunctionalStatusService;

        public GetDDLAssetFunctionalStatusQueryHandler(IAssetFunctionalStatusService assetFunctionalStatusService)
        {
            _assetFunctionalStatusService = assetFunctionalStatusService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLAssetFunctionalStatusQuery request, CancellationToken cancellationToken)
        {
            return await _assetFunctionalStatusService.DDLAssetFunctionalStatus(cancellationToken);
        }
    }
}
