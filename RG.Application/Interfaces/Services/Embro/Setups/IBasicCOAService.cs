using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.Embro.Setups.BasicCOAs.Queries.RequestResponseModel;
using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Embro.Setups
{
   public interface IBasicCOAService
    {
        #region Category Wise Item ACC
        //Task<List<BasicCOAViewModel>> CategoryWiseChartOfAccItems(decimal CompanyId, int CompanyWiseCategoryId, string ItemName = null);

        //Task<List<CommonAutocomplete>> CategoryWiseItem_AutoComplete(decimal CompanyId, int CompanyWiseCategoryId, string ItemName);
        #endregion Category Wise Item ACC
        Task<BasicCOARM> GetBasicCOAByID(decimal ID, CancellationToken cancellationToken = default);
        Task<List<SelectListItem>> DDLGetCompanyWiseKnitterList(int companyId);
        //Task<List<CommonAutocomplete>> GetsSupplierListAutocomplete(string itemName, decimal companyId, string CategoryName = "");
        Task<List<SelectListItem>> GetDDLCreditorsSupplior(int CompanyID = 0);
        Task<List<SelectListItem>> DDLGetCompanyWiseCostCenterList(int companyId);
        Task<List<SelectListItem>> DDLGetCostcenterWiseLocationList(decimal costCenterId);
        Task<List<SelectListItem>> DDLGetCostcenterWiseActivityList(decimal costCenterId);
        Task<List<SelectListItem>> DDLChartOfAccounts(int? ParentID, int LevelID = 0, string Predict = null, CancellationToken cancellationToken = default);
        Task<List<SelectListItem>> DDLCompanyWiseChartOfAccounts(int ParentID, int LevelID = 0, string Predict = null, CancellationToken cancellationToken = default);
        Task<List<SelectListItem>> DDLChartOfAccounts(int CompanyID, int LevelID, string Category = null, string Predict = null, CancellationToken cancellationToken = default);
        Task<List<SelectListItem>> DDLYarn_CommercialKnitters_Companywise(int CompanyID);
        Task<List<SelectListItem>> DDLGetReturnableNarrowGroup(int companyID, CancellationToken cancellationToken);
        Task<List<BasicCOADetailRM>> GetBasicCOADetailInfo(int groupCategoryID, string predict, CancellationToken cancellationToken = default);
    }
}
