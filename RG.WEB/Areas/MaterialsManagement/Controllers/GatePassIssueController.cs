using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Common.Utilities;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatePassAccountReviews.Commands.DataTransferModel;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Commands.Update;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries.RequestResponseModel;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_DocumentCategoriess.Queries;
using RG.Application.ViewModel.MaterialsManagement.Business.GatePassIssue;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.MaterialsManagement.Controllers
{
    [Area("MaterialsManagement")]
    [Route("MaterialsManagement/[controller]/[action]")]
    public class GatePassIssueController : BaseController
    {
        private readonly IDropdownService dropdownService;

        public GatePassIssueController(IDropdownService _dropdownService)
        {
            dropdownService = _dropdownService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AccountsIssue()
        {

            var model = new GatePassAccountIssueVM
            {
                ApprovalTypeList = DDLAccountsGatePassApprovalType(),
                //model.CategoryID = 2;//local sales
                CategoryList = dropdownService.RenderDDL(await Mediator.Send(new GetDDLICDocumentCategoriesForAccountsApprovalQuery()), true)
            };
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> GetGatePassAccountIssueList(DataSourceLoadOptions loadOptions, GatePassAccountIssueQM reqModel)
        {
            var claims = User.Claims.ToList();
            var cashApproval = claims?.FirstOrDefault(x => x.Type.Equals(UserClaimsCC.GatePassAccountsCashApproval, StringComparison.OrdinalIgnoreCase))?.Value;
            //var chequeApproval = claims?.FirstOrDefault(x => x.Type.Equals(UserClaimsCC.GatePassAccountsChequeApproval, StringComparison.OrdinalIgnoreCase))?.Value;
            var lCApproval = claims?.FirstOrDefault(x => x.Type.Equals(UserClaimsCC.GatePassAccountsLCApproval, StringComparison.OrdinalIgnoreCase))?.Value;
            List<int> accessableModelList = new();

            if (cashApproval != null)
                accessableModelList.Add(Convert.ToInt32(cashApproval));
            if (lCApproval != null)
                accessableModelList.Add(Convert.ToInt32(lCApproval));

            reqModel.AccessablePaymentMode = accessableModelList;


            var data = await Mediator.Send(new GetGatePassAccountIssueListQuery() { ReqModel = reqModel });
            loadOptions.PrimaryKey = new[] { "GatePassID" };
            loadOptions.PaginateViaPrimaryKey = true;
            return Json(DataSourceLoader.Load(data, loadOptions));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AccountsApprove(long gatePassID, IC_GatePassAccountReviewDTM accountsReview)
        {
            var data = await Mediator.Send(new GatepassMasterAccountsApprovalInfoUpdateCommand { GatePassID = gatePassID, IsApproved = true, AccountsReview = accountsReview });
            return Json(data);
        }
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AccountsReject(long gatePassID)
        {
            var data = await Mediator.Send(new GatepassMasterAccountsApprovalInfoUpdateCommand { GatePassID = gatePassID, IsApproved = false });
            return Json(data);
        }
        public async Task<IActionResult> GatePassApprove()
        {

            var model = new GatePassApproveVM
            {
                ApprovalTypeList = DDLGatePassApprovalType(),

                CategoryList = dropdownService.RenderDDL(await Mediator.Send(new GetDDLICDocumentCategoriesQuery()), true)
            };
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> GetGatePassApproveList(DataSourceLoadOptions loadOptions, Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries.RequestResponseModel.GatepassQM reqModel)
        {
            var data = await Mediator.Send(new GetGatePassApprovalListQuery() { ReqModel = reqModel });
            loadOptions.PrimaryKey = new[] { "GatePassID" };
            loadOptions.PaginateViaPrimaryKey = true;
            return Json(DataSourceLoader.Load(data, loadOptions));
        }

        public async Task<IActionResult> GatePassMarkOut()
        {

            var model = new GatePassMarkOutVM
            {
                ApprovalTypeList = DDLGatePassMarlOutType(),
                CategoryList = dropdownService.RenderDDL(await Mediator.Send(new GetDDLICDocumentCategoriesQuery()), true)
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetGatePassMarkOutList(DataSourceLoadOptions loadOptions, GatepassQM reqModel)
        {
            var data = await Mediator.Send(new GetGatePassMarkOutListQuery() { ReqModel = reqModel });
            loadOptions.PrimaryKey = new[] { "GatePassID" };
            loadOptions.PaginateViaPrimaryKey = true;
            return Json(DataSourceLoader.Load(data, loadOptions));
        }
        public IActionResult GatePassReceivable()
        {            
            var model = new GatePassReceivableVM();
            model.ApprovalTypeList = DDLGatePassReturnableType();
            //model.CategoryList = dropdownService.RenderDDL(await Mediator.Send(new GetDDLICDocumentCategoriesQuery()), true);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetGatePassReceivableList(DataSourceLoadOptions loadOptions, GatepassQM reqModel)
        {
            reqModel.CategoryID = IC_DocumentCategoriesIDCC.Returnable;
            var data = await Mediator.Send(new GetGatePassReceivableListQuery() { ReqModel = reqModel });
            loadOptions.PrimaryKey = new[] { "GatePassID" };
            loadOptions.PaginateViaPrimaryKey = true;
            return Json(DataSourceLoader.Load(data, loadOptions));
        }
        private List<SelectListItem> DDLAccountsGatePassApprovalType(bool IsIncludeDefault = false)
        {
            var list = new List<SelectListItem>();
            if (IsIncludeDefault)
            {
                list = dropdownService.DefaultDDL();
            }
            list.Add(new SelectListItem() { Text = "Not Approved", Value = "" });
            list.Add(new SelectListItem() { Text = "Approved", Value = "true" });
            list.Add(new SelectListItem() { Text = "Rejected", Value = "false" });

            return list;
        }
        private List<SelectListItem> DDLGatePassApprovalType(bool IsIncludeDefault = false)
        {
            var list = new List<SelectListItem>();
            if (IsIncludeDefault)
            {
                list = dropdownService.DefaultDDL();
            }
            list.Add(new SelectListItem() { Text = "Not Approved", Value = "false" });
            list.Add(new SelectListItem() { Text = "Approved", Value = "true" });
            //list.Add(new SelectListItem() { Text = "Rejected", Value = "false" });

            return list;
        }
        private List<SelectListItem> DDLGatePassMarlOutType(bool IsIncludeDefault = false)
        {
            var list = new List<SelectListItem>();
            if (IsIncludeDefault)
            {
                list = dropdownService.DefaultDDL();
            }
            list.Add(new SelectListItem() { Text = "Waiting For Mark Out", Value = "false" });
            list.Add(new SelectListItem() { Text = "Marked Out", Value = "true" });


            return list;
        }
        private List<SelectListItem> DDLGatePassReturnableType(bool IsIncludeDefault = false)
        {
            var list = new List<SelectListItem>();
            if (IsIncludeDefault)
            {
                list = dropdownService.DefaultDDL();
            }
            list.Add(new SelectListItem() { Text = "Not Satisfied", Value = "false" });
            list.Add(new SelectListItem() { Text = "Satisfied", Value = "true" });


            return list;
        }
    }
}
