using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetTypes.Query;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetTypes.Query.RequestResponseModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetTypes.Query
{
    public class GetAllAssetTypeQuery : IRequest<LoadResult>
    {
        public DataSourceLoadOptions LoadOptions { get; set; }
    }
    public class GetAllAssetTypeQueryHandler : IRequestHandler<GetAllAssetTypeQuery, LoadResult>
    {
        private readonly IAssetTypeService _assetTypeService;

        public GetAllAssetTypeQueryHandler(IAssetTypeService assetTypeService)
        {
            _assetTypeService = assetTypeService;
        }

        public async Task<LoadResult> Handle(GetAllAssetTypeQuery request, CancellationToken cancellationToken)
        {
            request.LoadOptions.PrimaryKey = new[] { "AssetTypeID" };
            request.LoadOptions.PaginateViaPrimaryKey = true;
            var dataQuery = _assetTypeService.GetAllAssetType();
            return await DataSourceLoader.LoadAsync(dataQuery, request.LoadOptions, cancellationToken);
        }
    }
}
