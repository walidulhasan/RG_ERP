using MediatR;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetInfos.Queries
{
    public class AssetNameAutocompleteQuery : IRequest<List<string>>
    {
        public int AssetSubTypeID { get; set; }
        public string Predict { get; set; }
    }
    public class AssetNameAutocompleteQueryHandler : IRequestHandler<AssetNameAutocompleteQuery, List<string>>
    {
        private readonly IAssetInfoService _assetInfosService;

        public AssetNameAutocompleteQueryHandler(IAssetInfoService assetInfosService)
        {
            _assetInfosService = assetInfosService;
        }
        public async Task<List<string>> Handle(AssetNameAutocompleteQuery request, CancellationToken cancellationToken)
        {
            return await _assetInfosService.AssetNameAutocomplete(request.AssetSubTypeID, request.Predict, cancellationToken);
        }
    }
}
