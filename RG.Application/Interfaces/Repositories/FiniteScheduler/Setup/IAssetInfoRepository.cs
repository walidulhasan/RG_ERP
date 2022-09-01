using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetIndexs.Queries.RequestResponseModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetInfos.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetInfos.Queries.RequestResponseModel;
using RG.Application.ViewModel.FiniteScheduler.Setup.AssetInfo;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Setup
{
     public interface IAssetInfoRepository : IGenericRepository<AssetInfo>
    {
        public Task<RResult> Create(AssetInfo entity, CancellationToken cancellationToken);
        Task<List<AssetInfoRM>> GetAllAssetWithSearchTypeAndSubType(int AssetTypeID , int AssetSubTypeID , CancellationToken cancellationToken);
        Task<AssetInfoVM> GetDataToUpdateAsset(int id, CancellationToken cancellationToken);
        Task<RResult> DeleteAssetWithChild(int iD);
        Task<List<SelectListItem>> DDLAssetNameViaAssetSubType(int AssetSubTypeID, CancellationToken cancellationToken = default);
        Task<List<GetAllAssetAndRelationalInfoRM>> GetAllAssetAndRelationalInfo(GetAllAssetAndRelationalInfoQM queryModel, CancellationToken cancellationToken);
        Task<List<GetAllAssetAndRelationalInfoRM>> GetAllAssetAndDepricationInfo(int CompanyID, int FiscalYear , CancellationToken cancellationToken);
        Task<string> GenerateAutoAssetCode(string prefix, int companyID, int assetSubTypeID);
        Task<List<SelectListItem>> DDLAssetNameWiseAssetCode(string assetName, CancellationToken cancellationToken);
        Task<List<ReportDataVM>> GetAssetReportData(int assetTypeName, int assetSubTypeID, int assetAssignedType, string assetName, DateTime? dateFrom, DateTime? dateTo
            , string code, int companyID, int divisionID, int departmentID, int buildingID, int floorID, string dynamicFilters, bool extendedFeature = false, CancellationToken cancellationToken = default);
        Task<List<string>> AssetNameAutocomplete(int assetSubTypeID, string predict, CancellationToken cancellationToken);
    }
}
