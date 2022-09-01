using MediatR;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetIndexs.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetInfos.Queries
{
    public class GetAllAssetAndDepricationInfoQuery:IRequest<List<GetAllAssetAndRelationalInfoRM>>
    {
        public int CompanyID { get; set; }
        public int FiscalYear { get; set; }
    }
    public class GetAllAssetAndDepricationInfoQueryHandler : IRequestHandler<GetAllAssetAndDepricationInfoQuery, List<GetAllAssetAndRelationalInfoRM>>
    {
        private readonly IAssetInfoService _assetInfoService;

        public GetAllAssetAndDepricationInfoQueryHandler(IAssetInfoService assetInfoService)
        {
            _assetInfoService = assetInfoService;
        }
        public async Task<List<GetAllAssetAndRelationalInfoRM>> Handle(GetAllAssetAndDepricationInfoQuery request, CancellationToken cancellationToken)
        {
            return await _assetInfoService.GetAllAssetAndDepricationInfo(request.CompanyID,request.FiscalYear,cancellationToken);
        }
    }
}
