using MediatR;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetLocations.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetLocations.Queries
{
    public class GetAssetLoactionByIDQuery:IRequest<AssetLocationRM>
    {
        public int id { get; set; }
    }
    public class GetAssetLoactionByIDQueryHandler : IRequestHandler<GetAssetLoactionByIDQuery, AssetLocationRM>
    {
        private readonly IAssetLocationService _assetLocationService;

        public GetAssetLoactionByIDQueryHandler(IAssetLocationService assetLocationService)
        {
            _assetLocationService = assetLocationService;
        }
        public async Task<AssetLocationRM> Handle(GetAssetLoactionByIDQuery request, CancellationToken cancellationToken)
        {
            return await _assetLocationService.GetAssetLoactionByID(request.id,cancellationToken);
        }
    }
}
