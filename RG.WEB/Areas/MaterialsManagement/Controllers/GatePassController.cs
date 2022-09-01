using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Common.Models;
using RG.Application.Common.Utilities;
using RG.Application.Constants;
using RG.Application.Contracts.AOP.Business.Tbl_Issuance_Detailss.Queries;
using RG.Application.Contracts.AOP.Business.Tbl_Issuance_Masters.Queries;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Commands.Create;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Commands.DataTransferModel;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Commands.Update;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries.RequestResponseModel;
using RG.Application.Contracts.MaterialsManagement.Business.IC_ReturnableRecieveGatePassDetails.Commands.Create;
using RG.Application.Contracts.MaterialsManagement.Business.IC_ReturnableRecieveGatePassDetails.Commands.DataTransferModel;
using RG.Application.Contracts.MaterialsManagement.Business.Yarn_AllocationToKnitters.Queries;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_DocumentCategoriess.Queries;
using RG.Application.Contracts.Maxco.Buisness.Style.Queries;
using RG.Application.Contracts.Maxco.Setup.Buyer_Setup.Queries;
using RG.Application.Enums;
using RG.Application.ViewModel.MaterialsManagement.Business.GatePass;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RG.WEB.Areas.MaterialsManagement.Controllers
{
    [Area("MaterialsManagement")]
    [Route("MaterialsManagement/[controller]/[action]")]
    public class GatePassController : BaseController
    {
        private readonly IDropdownService dropdownService;
        private readonly ICurrentUserService currentUserService;

        public GatePassController(IDropdownService _dropdownService, ICurrentUserService _currentUserService)
        {
            dropdownService = _dropdownService;
            currentUserService = _currentUserService;
        }
        #region Action
        public async Task<IActionResult> Index()
        {
            var model = new GateControlVM
            {
                CategoryList = dropdownService.RenderDDL(await Mediator.Send(new GetDDLICDocumentCategoriesQuery()), true),
                StatusList = DDLStatus(),
                StartDate = DateTime.Now.ToString("dd-MMM-yyyy"),
                EndDate = DateTime.Now.ToString("dd-MMM-yyyy")
            };
            return View(model);

        }
        public async Task<IActionResult> Create()
        {

            var model = new GatePassCreateVM()
            {
                CategoryList = dropdownService.RenderDDL(await Mediator.Send(new GetDDLICDocumentCategoriesQuery()), true),

            };
            return View(model);
        }
        public async Task<IActionResult> Edit(long gatePassID, byte categoryID)
        {
            var isSuperAdmin = Convert.ToBoolean(User.FindFirstValue(SessionKey.IsSuperAdmin));
            var isGatePassApproved = await Mediator.Send(new GetIsApprovedGatePassQuery { GatePassID = gatePassID });
            if (!isSuperAdmin && isGatePassApproved)
            {
                var model = new GateControlVM
                {
                    CategoryList = dropdownService.RenderDDL(await Mediator.Send(new GetDDLICDocumentCategoriesQuery()), true),
                    StatusList = DDLStatus(),
                    StartDate = DateTime.Now.AddMonths(-1).ToString("dd-MMM-yyyy"),
                    EndDate = DateTime.Now.ToString("dd-MMM-yyyy"),
                };
                return RedirectToAction("Index");
            }
            else
            {
                var model = new GatePassCreateVM()
                {
                    CategoryList = dropdownService.RenderDDL(await Mediator.Send(new GetDDLICDocumentCategoriesQuery()), true),
                    CategoryID = categoryID,
                    GatePassID = gatePassID
                };
                return View(model);
            }
            
            
        }
        public ActionResult CallViewComponents(string categoryName, int gatePassID = 0)
        {
            var viewComponentName = "";
            var reqData = new GatePassAllCategoryVCQM()
            {
                UserID = currentUserService.AlgoUserID,
                GatePassID = gatePassID
            };
            if (categoryName == IC_DocumentCategoriesCC.SampleGmts)
            {
                viewComponentName = "SampleGmts";
            }
            else if (categoryName == IC_DocumentCategoriesCC.LocalSales)
            {
                viewComponentName = "LocalSales";
            }
            else if (categoryName == IC_DocumentCategoriesCC.NonReturnable)
            {
                viewComponentName = "NonReturnable";
            }
            else if (categoryName == IC_DocumentCategoriesCC.Returnable)
            {
                viewComponentName = "Returnable";
            }
            else if (categoryName == IC_DocumentCategoriesCC.ExportSales)
            {
                viewComponentName = "ExportSales";
            }
            else if (categoryName == IC_DocumentCategoriesCC.ScrapSales)
            {
                viewComponentName = "ScrapSales";
            }

            return ViewComponent(viewComponentName, reqData);
        }

        public IActionResult GatePassChallan(int gatePassID, int categoryID, int reportType)
        {
            var model = new GatePassChallanMasterVM { GatePassID = gatePassID, CategoryID = (byte)categoryID, ReportType = reportType };
            var viewComponentName = "GatePassChallan";
            return ViewComponent(viewComponentName, model);
        }
        public IActionResult DeliveryChallan(int gatePassID)
        {
            var viewComponentName = "DeliveryChallan";
            return ViewComponent(viewComponentName, gatePassID);
        }
        #endregion Action

        #region Sample Gmt
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> SaveSampleGatePass(SampleGatePassDTM sampleDTM)
        {
            var rResult = new RResult();
            rResult = await Mediator.Send(new SampleGatePassCreateCommand { SampleGatePass = sampleDTM });
            return Json(rResult);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> UpdateSampleGatePass(SampleGatePassDTM sampleDTM)
        {
            var rResult = new RResult();
            var isSuperAdmin = Convert.ToBoolean(User.FindFirstValue(SessionKey.IsSuperAdmin));
            var isGatePassApproved = await Mediator.Send(new GetIsApprovedGatePassQuery { GatePassID = sampleDTM.ID });
            if (!isSuperAdmin && isGatePassApproved)
            {
                rResult.result = 0;
                rResult.message = "Gate Pass Already Approved";
            }
            else
            {
                rResult = await Mediator.Send(new SampleGatePassUpdateCommand { SampleGatePass = sampleDTM });                
            }
            return Json(rResult);
        }
        #endregion Sample Gmt

        #region Local Sales
        [HttpPost]
        public async Task<JsonResult> SaveLocalSalesGatePass(LocalSalesGatePassDTM localSalesDTM)
        {
            var rResult = new RResult();
            rResult = await Mediator.Send(new LocalSalesGatePassCreateCommand { LocalSalesGatePass = localSalesDTM });
            return Json(rResult);
        }
        [HttpPost]
        public async Task<JsonResult> UpdateLocalSalesGatePass(LocalSalesGatePassDTM localSalesDTM)
        {
            var rResult = new RResult();
            var isSuperAdmin = Convert.ToBoolean(User.FindFirstValue(SessionKey.IsSuperAdmin));
            var isGatePassApproved = await Mediator.Send(new GetIsApprovedGatePassQuery { GatePassID = localSalesDTM.ID });
            if (!isSuperAdmin && isGatePassApproved)
            {
                rResult.result = 0;
                rResult.message = "Gate Pass Already Approved";
            }
            else
            {
                rResult = await Mediator.Send(new LocalSalesGatePassUpdateCommand { LocalSalesGatePass = localSalesDTM });
            }
            return Json(rResult);
        }
        #endregion Local Sales

        #region Non-Returnable
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> SaveNonReturnableGatePass(NonReturnableGatePassDTM nonReturnableDTM)
        {
            var rResult = new RResult();
            rResult = await Mediator.Send(new NonReturnableGatePassCreateCommand { NonReturnableGatePass = nonReturnableDTM });
            return Json(rResult);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> UpdateNonReturnableGatePass(NonReturnableGatePassDTM nonReturnableDTM)
        {
            var rResult = new RResult();
            var isSuperAdmin = Convert.ToBoolean(User.FindFirstValue(SessionKey.IsSuperAdmin));
            var isGatePassApproved = await Mediator.Send(new GetIsApprovedGatePassQuery { GatePassID = nonReturnableDTM.ID });
            if (!isSuperAdmin && isGatePassApproved)
            {
                rResult.result = 0;
                rResult.message = "Gate Pass Already Approved";
            }
            else
            {
                rResult = await Mediator.Send(new NonReturnableGatePassUpdateCommand { NonReturnableGatePass = nonReturnableDTM });
            }
            return Json(rResult);
        }
        #endregion Non-Returnable

        #region Returnable
        [HttpPost]
        public async Task<JsonResult> SaveReturnableGatePass(ReturnableGatePassDTM returnableDTM)
        {
            var rResult = new RResult();
            rResult = await Mediator.Send(new ReturnableGatePassCreateCommand { ReturnableGatePass = returnableDTM });
            return Json(rResult);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> UpdateReturnableGatePass(ReturnableGatePassDTM returnableDTM)
        {
            var rResult = new RResult();
            var isSuperAdmin = Convert.ToBoolean(User.FindFirstValue(SessionKey.IsSuperAdmin));
            var isGatePassApproved = await Mediator.Send(new GetIsApprovedGatePassQuery { GatePassID = returnableDTM.ID });
            if (!isSuperAdmin && isGatePassApproved)
            {
                rResult.result = 0;
                rResult.message = "Gate Pass Already Approved";
            }
            else
            {
                rResult = await Mediator.Send(new ReturnableGatePassUpdateCommand { ReturnableGatePass = returnableDTM });
            }
            return Json(rResult);
        }


        #endregion Returnable

        #region Export Sales
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> SaveExportSalesGatePass(ExportSalesGatePassDTM exportSalesDTM)
        {
            var rResult = new RResult();
            rResult = await Mediator.Send(new ExportSalesGatePassCreateCommand { ExportSalesGatePass = exportSalesDTM });
            return Json(rResult);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> UpdateExportSalesGatePass(ExportSalesGatePassDTM exportSalesDTM)
        {
            var rResult = new RResult();
            var isSuperAdmin = Convert.ToBoolean(User.FindFirstValue(SessionKey.IsSuperAdmin));
            var isGatePassApproved = await Mediator.Send(new GetIsApprovedGatePassQuery { GatePassID = exportSalesDTM.ID });
            if (!isSuperAdmin && isGatePassApproved)
            {
                rResult.result = 0;
                rResult.message = "Gate Pass Already Approved";
            }
            else
            {
                rResult = await Mediator.Send(new ExportSalesGatePassUpdateCommand { ExportSalesGatePass = exportSalesDTM });
            }
            return Json(rResult);
        }
        #endregion Export Sales

        #region Scrap Sales
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> SaveScrapSalesGatePass(ScrapSalesGatePassDTM scrapSalesDTM)
        {
            var rResult = new RResult();
            var isSuperAdmin = Convert.ToBoolean(User.FindFirstValue(SessionKey.IsSuperAdmin));
            var isGatePassApproved = await Mediator.Send(new GetIsApprovedGatePassQuery { GatePassID = scrapSalesDTM.ID });
            if (!isSuperAdmin && isGatePassApproved)
            {
                rResult.result = 0;
                rResult.message = "Gate Pass Already Approved";
            }
            else
            {
                rResult = await Mediator.Send(new ScrapSalesGatePassCreateCommand { ScrapSalesGatePass = scrapSalesDTM });
            }
            return Json(rResult);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> UpdateScrapSalesGatePass(ScrapSalesGatePassDTM scrapSalesDTM)
        {
            var rResult = new RResult();
            rResult = await Mediator.Send(new ScrapSalesGatePassUpdateCommand { ScrapSalesGatePass = scrapSalesDTM });
            return Json(rResult);
        }
        #endregion Scrap Sales

        #region Other Json functions
        [HttpGet]
        public async Task<IActionResult> GetICBrowseGetPassesList(DataSourceLoadOptions loadOptions, GatepassQM gatePassReqObj)
        {
            gatePassReqObj.GatePassNo = gatePassReqObj.GatePassNo == null ? "" : gatePassReqObj.GatePassNo;
            if (!currentUserService.IsSuperAdminRole)
            {
                gatePassReqObj.Algo_UserId = currentUserService.AlgoUserID;
                gatePassReqObj.CA_UserId = currentUserService.UserID;
            }
            var data = await Mediator.Send(new GetICBrowseGetPassesListQuery { GatepassRequiestModel = gatePassReqObj, LoadOptions = loadOptions });
            return Json(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> RemoveGatePass(long gatePassId)
        {
            var isSuperAdmin = Convert.ToBoolean(User.FindFirstValue(SessionKey.IsSuperAdmin));
            return Json(await Mediator.Send(new GatePassMasterRemoveCommand { GatePassID = gatePassId,IsSuperAdmin=isSuperAdmin }));
        }

        public List<SelectListItem> DDLStatus(bool IsIncludeDefault = false)
        {
            var list = new List<SelectListItem>();
            if (IsIncludeDefault)
            {
                list = dropdownService.DefaultDDL();
            }
            list.Add(new SelectListItem() { Text = "All", Value = "All" });
            list.Add(new SelectListItem() { Text = "Approved", Value = "Approved" });
            list.Add(new SelectListItem() { Text = "Not Approved", Value = "Not Approved" });
            list.Add(new SelectListItem() { Text = "Marked Out", Value = "Marked Out" });
            list.Add(new SelectListItem() { Text = "Satisfied", Value = "Satisfied" });
            list.Add(new SelectListItem() { Text = "Un Satisfied", Value = "Un Satisfied" });

            return list;
        }

        public async Task<JsonResult> GetDDLIssuance_Master(int supplierID, int gatePassDetailID, string predict)
        {
            var issuanceList = dropdownService.RenderDDL(await Mediator.Send(new GetDDLIssuance_MasterQuery() {SupplierID=supplierID, GatePassDetailID = gatePassDetailID, Predict = predict }), true);
            return Json(issuanceList);

        }

        public async Task<JsonResult> GetDDLIssuance_DetailByMaster(long masterID, int gatePassDetailID)
        {

            var data = dropdownService.RenderDDL(await Mediator.Send(new GetDDLIssuance_DetailByMasterQuery { MasterID = masterID, GatePassDetailID = gatePassDetailID }), true);
            return Json(data);
        }
        public async Task<JsonResult> GetIssuanceDetailInfo(long issue_ID, long issue_DetailsID)
        {
            var data = await Mediator.Send(new GetIssuanceDetailInfoByIDQuery { issue_ID = issue_ID, issue_DetailsID = issue_DetailsID });
            return Json(data);
        }
        public async Task<IActionResult> GetOrderNumber(int buyerID, DateTime? OrderDate = null)
        {
            if (OrderDate == null)
            {
                OrderDate = DateTime.Now.AddYears(3);
            }
            var listOfObject = dropdownService.RenderDDL(await Mediator.Send(new DDLGetOrderListQuery() { BuyerID = buyerID, OrderConditionDate = OrderDate.Value }), true);
            return Json(listOfObject);
        }
        public async Task<JsonResult> GetDDLYarnRequisitionAfterAllocation(int knitterID, int GatePassDetailID, string predict)
        {
            var data = dropdownService.RenderCustomDDL(await Mediator.Send(new GetDDLYarnRequisitionAfterAllocationQuery { KnitterID = knitterID, GatePassDetailID = GatePassDetailID, Predict = predict, DateFrom = DateTime.Now.AddMonths(-12) }), true);
            return Json(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> ApprovedGatePass(long gatePassId)
        {
            var rResult = new RResult();
            rResult = await Mediator.Send(new ApprovedGatePassUpdateCommand { GatePassID = gatePassId });
            return Json(rResult);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> MarkOutGatePass(long gatePassId)
        {
            var rResult = new RResult();
            rResult = await Mediator.Send(new MarkOutGatePassUpdateCommand { GatePassID = gatePassId, UserID = currentUserService.AlgoUserID });
            return Json(rResult);
        }

        public async Task<JsonResult> GetGatePassChallanInfo(int gatePassID)
        {
            var data = await Mediator.Send(new GetGatePassChallanByGatePassIDQuery { GatePassID = gatePassID });
            return Json(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> ReturnableRecieveGatePassDetailSave(List<IC_ReturnableRecieveGatePassDetailDTM> model)
        {
            var data = await Mediator.Send(new ReturnableRecieveGatePassDetailCreateCommand { ReturnableRecieveGatePassDetail = model });
            return Json(data);
        }

        public async Task<JsonResult> GetDDLBuyer() { 
        var data= dropdownService.RenderDDL(await Mediator.Send(new GetDDLBuyerAllQuery()), true);
            return Json(data);
        }


        public async Task<JsonResult> GetExportItem(long GatePassID)
        {
            var data = await Mediator.Send(new GetExportSalesItemQuery() {GatePassID = GatePassID });
            return Json(data);
        }
        public async Task<JsonResult> GetReturnableItem(long GatePassID)
        {
            var data = await Mediator.Send(new GetReturnableGatePassQuery() { GatePassID = GatePassID });
            return Json(data);
        }
        public async Task<JsonResult> GetLocalSalesGatePassItems(long GatePassID)
        {
            var data = await Mediator.Send(new GetLocalSalesGatePassItemsQuery() { GatePassID = GatePassID });
            foreach (var item in data)
            {
                if (item.ProcessId != 6)
                {
                    item.IssuanceMasterID = (await Mediator.Send(new GetTbl_Issuance_DetailsByIDQurey() { ID = item.IssuanceDetailID.Value })).Transation_ID;
                }
            }
            return Json(data);
        }
        
        #endregion

        #region Report
        /// <summary>
        /// 
        /// </summary>
        /// <param name="GatePassID"></param>
        /// <param name="CategoryID"></param>
        /// <param name="ReportType">GatePass=1 OR Invoice=2</param>
        /// <param name="ReportFormat"></param>
        /// <returns></returns>
        public async Task<IActionResult> ShowGatePassReports(int GatePassID, int CategoryID, int ReportType, string ReportFormat)
        {
            //string reportName = "ExportSalesChallan";
            string reportName = $"/{ReportFolder.MaterialsManagementFolder}/";
            if (IC_DocumentCategoriesIDCC.SampleGmts == CategoryID)
                reportName += "SampleGatePass";
            else if (IC_DocumentCategoriesIDCC.LocalSales == CategoryID)
                reportName += "LocalSalesGatePass";
            else if (IC_DocumentCategoriesIDCC.NonReturnable == CategoryID)
                reportName += "NonReturnableGatePass";
            else if (IC_DocumentCategoriesIDCC.Returnable == CategoryID)
                reportName += "ReturnableGatePass";
            else if (IC_DocumentCategoriesIDCC.ExportSales == CategoryID)
                reportName += "ExportSalesGatePass";
            else if (IC_DocumentCategoriesIDCC.ScrapSales == CategoryID)
                reportName += "ScrapSalesGatePass"; 

            IDictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("gatePassID", GatePassID);
            parameters.Add("reportType", ReportType);
            int connectionString = (int)enum_ServerType.MaterialsManagementConnection;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

        }
        public async Task<IActionResult> ShowRequisitionDetailReport(int RequisitionID, string ReportFormat)
        {
            string reportName = $"/{ReportFolder.MaterialsManagementFolder}/";
             reportName += "YarnAllocationToKnitterInfo";//"YarnAllocationToKnitterInfo";
            IDictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("RequisitionID", RequisitionID);
            int connectionString = (int)enum_ServerType.MaterialsManagementConnection;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);
        }
        #endregion Report
    }
}
