using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetSubTypes.Query
{
    public class GetDDLAssetTypeWiseAssetSubTypeQuery:IRequest<List<SelectListItem>>
    {
        public int AssetTypeID { get; set; }
        public string Predict { get; set; }
    }
    public class GetDDLAssetTypeWiseAssetSubTypeQueryHandler : IRequestHandler<GetDDLAssetTypeWiseAssetSubTypeQuery, List<SelectListItem>>
    {
        private readonly IAssetSubTypeService _assetSubTypeService;

        public GetDDLAssetTypeWiseAssetSubTypeQueryHandler(IAssetSubTypeService assetSubTypeService)
        {
            _assetSubTypeService = assetSubTypeService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLAssetTypeWiseAssetSubTypeQuery request, CancellationToken cancellationToken)
        {
            return await _assetSubTypeService.DDLAssetTypeWiseAssetSubType(request.AssetTypeID,request.Predict,cancellationToken);
        }
    }
}
