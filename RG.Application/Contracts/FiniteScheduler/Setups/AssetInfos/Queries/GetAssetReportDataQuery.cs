using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using RG.Application.ViewModel.FiniteScheduler.Setup.AssetInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetInfos.Queries
{
    public class GetAssetReportDataQuery:IRequest<List<ReportDataVM>>
    {
        public int AssetTypeName { get; set; }
        public int AssetSubTypeID { get; set; }


        public int AssetAssignedType { get; set; }
        public string AssetName { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Code { get; set; }
        public int CompanyID { get; set; }
        public int DivisionID { get; set; }
        public int DepartmentID { get; set; }
        public int BuildingID { get; set; }
        public int FloorID { get; set; }
        public bool ExtendedFeature { get; set; } = false;
        public string DynamicFilters { get; set; }
    }
    public class GetAssetReportDataQueryHandler : IRequestHandler<GetAssetReportDataQuery, List<ReportDataVM>>
    {
        private readonly IAssetInfoService _assetInfoService;

        public GetAssetReportDataQueryHandler(IAssetInfoService assetInfoService)
        {
            _assetInfoService = assetInfoService;
        }
        public async Task<List<ReportDataVM>> Handle(GetAssetReportDataQuery request, CancellationToken cancellationToken)
        {
            return await _assetInfoService.GetAssetReportData(request.AssetTypeName, request.AssetSubTypeID,
                request.AssetAssignedType
                ,request.AssetName
                ,request.DateFrom,request.DateTo,request.Code,request.CompanyID,request.DivisionID,request.DepartmentID
                ,request.BuildingID,request.FloorID, request.DynamicFilters,request.ExtendedFeature, cancellationToken);
        }
    }
}
