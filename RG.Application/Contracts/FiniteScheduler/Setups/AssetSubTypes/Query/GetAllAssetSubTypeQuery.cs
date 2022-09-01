using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetSubTypes.Query
{
    public class GetAllAssetSubTypeQuery : IRequest<LoadResult>
    {
        public DataSourceLoadOptions LoadOptions { get; set; }
    }
    public class GetAllAssetSubTypeQueryHandler : IRequestHandler<GetAllAssetSubTypeQuery, LoadResult>
    {
        private readonly IAssetSubTypeService _assetSubTypeService;

        public GetAllAssetSubTypeQueryHandler(IAssetSubTypeService assetSubTypeService)
        {
            _assetSubTypeService = assetSubTypeService;
        }
        public async Task<LoadResult> Handle(GetAllAssetSubTypeQuery request, CancellationToken cancellationToken)
        {
            request.LoadOptions.PrimaryKey = new[] { "AssetSubTypeID" };
            request.LoadOptions.PaginateViaPrimaryKey = true;
            var dataQuery = _assetSubTypeService.GetAllAssetSubType();
            return await DataSourceLoader.LoadAsync(dataQuery, request.LoadOptions, cancellationToken);
        }
    }
}
