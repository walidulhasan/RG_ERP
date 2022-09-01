using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Constants;
using RG.Application.Contracts.Embro.AccountsReports.NoteSummary.Queries;
using RG.Application.Contracts.Embro.AccountsReports.TrialBalance.Queries;
using RG.Application.Contracts.Embro.AccountsReports.Vouchers.Queries.QueryResponseModel;
using RG.Application.Contracts.Embro.CompanyInfos.Queries;
using RG.Application.Contracts.Embro.Setups.BalanceSheetGroupMaps.Queries;
using RG.Application.Contracts.Embro.Setups.BasicCOAs.Queries;
using RG.Application.Contracts.Embro.Setups.COAGroupCategorys.Queries;
using RG.Application.Enums;
using RG.Application.ViewModel.Embro.Business.GeneralLedgers;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RG.WEB.Areas.Embro.Controllers
{
    [Area("Embro")]
    [Route("Embro/[controller]/[action]")]
    public class GeneralLedgerController : BaseController
    {
        private readonly IDropdownService _dropdownService;
        private readonly ICurrentUserService _currentUserService;

        public GeneralLedgerController(IDropdownService dropdownService, ICurrentUserService currentUserService)
        {
            _dropdownService = dropdownService;
            _currentUserService = currentUserService;
        }
        public async Task<IActionResult> TrailBalance()
        {
            GeneralLedgerTrailBalanceVM model = new GeneralLedgerTrailBalanceVM();
            if (DateTime.Now.Month > 6)
            {
                model.DateFrom = new DateTime(DateTime.Now.Year, 7, 1);
                model.DateTo = new DateTime(DateTime.Now.Year + 1, 6, 30);
            }
            else
            {
                model.DateFrom = new DateTime(DateTime.Now.Year - 1, 7, 1);
                model.DateTo = new DateTime(DateTime.Now.Year, 6, 30);
            }
            model.DDLCompany = await Mediator.Send(new GetDDLCompanyInfoQuery());
            model.CompanyID = _currentUserService.CompanyID;
            model.DDLBusiness = await Mediator.Send(new GetDDLBasicCoaQuery() { ParentID = model.CompanyID, LevelID = 2 });
            model.DDLAccountLevel = new List<SelectListItem>()
            {
                new SelectListItem(){Text="Category",Value="4"},
                new SelectListItem(){Text="Sub Category",Value="5"},
                new SelectListItem(){Text="Broad Group",Value="6"},
                new SelectListItem(){Text="Narrow Group",Value="7"},
                new SelectListItem(){Text="Identification",Value="8"},
                new SelectListItem(){Text="Item",Value="14",Selected=true},

            };
            model.DDLSelectByCostCenter = _dropdownService.YesNoDDL(false, 0, "No", "Yes");
            model.DDLSelectWithDetail = _dropdownService.YesNoDDL(false, 0, "No", "Yes");
            model.DDLReportGroup = _dropdownService.YesNoDDL(false, 0, "Summarize", "Expanded");
            model.DDLVoucherPosted = _dropdownService.YesNoDDL(false, 0, "Unposted", "Posted");

            model.DDLExecutionType = new List<SelectListItem>()
            {
                new SelectListItem(){Text="Trial Balance View",Value="TrialBalanceView"},
                new SelectListItem(){Text="Trial Balance PDF",Value="TrialBalancePDF"},
                new SelectListItem(){Text="Trial Balance Excel",Value="TrialBalanceExcel"},
            };
            model.DDLExecutionType.AddRange(await Mediator.Send(new GetDDLCOAGroupCategoryQuery { }));

            model.DDLExecutionType.Add(new SelectListItem() { Text = "Statement of Financial Position", Value = "1" });
            model.DDLExecutionType.Add(new SelectListItem() { Text = "Statement of Profit or Loss and Other Comprehensive Income", Value = "2" });


            return View(model);
        }

        public async Task<IActionResult> TrailBalanceReport(int CompanyID, int BusinessID, int SelectLevel, int SelectByCostCenter, int SelectWithDetail,
             int ReportGroup, int VoucherPosted, DateTime DateFrom, DateTime DateTo, int IsExcludeZeroBalance, string ReportFormat = "PDF")
        {
            //string reportName = "ExportSalesChallan";
            string reportName = $"/{ReportFolder.EmbroFolder}/";

            //Report_Trial_Activity

            reportName += "Report_Trial_Activity";
            IDictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("SelectLevel", SelectLevel);
            parameters.Add("CompID", CompanyID);
            parameters.Add("BusinessID", BusinessID);
            parameters.Add("DateFrom", DateFrom.ToString("dd-MMM-yyyy"));
            parameters.Add("DateTo", DateTo.ToString("dd-MMM-yyyy"));
            parameters.Add("WithDetail", SelectWithDetail);
            parameters.Add("Status", VoucherPosted);
            parameters.Add("WithClosingBalance", IsExcludeZeroBalance);
            int connectionString = (int)enum_ServerType.EmbroConnection;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

        }

        public async Task<IActionResult> TrailBalanceReportView(int CompanyID, int BusinessID, int SelectLevel, int SelectByCostCenter, int SelectWithDetail,
             int ReportGroup, int VoucherPosted, DateTime DateFrom, DateTime DateTo, int IsExcludeZeroBalance)
        {
            var data = await Mediator.Send(new TrialBalanceReportGetQuery
            {
                CompanyID = CompanyID,
                BusinessID = BusinessID,
                SelectLevel = SelectLevel,
                SelectWithDetail = SelectWithDetail
                ,
                ReportGroup = ReportGroup,
                VoucherPosted = VoucherPosted,
                DateFrom = DateFrom,
                DateTo = DateTo,
                IsExcludeZeroBalance = IsExcludeZeroBalance
            });
            return View(data);
        }
        public async Task<IActionResult> TrailBalanceNotesReportView(int CompanyID, int BusinessID, int SelectLevel, int SelectByCostCenter, int SelectWithDetail,
             int ReportGroup, int VoucherPosted, DateTime DateFrom, DateTime DateTo, int IsExcludeZeroBalance, int NoteGroupID)
        {
            var data = await Mediator.Send(new TrialBalanceNoteGetQuery
            {
                CompanyID = CompanyID,
                BusinessID = BusinessID,
                SelectLevel = SelectLevel,
                SelectWithDetail = SelectWithDetail,
                ReportGroup = ReportGroup,
                VoucherPosted = VoucherPosted,
                DateFrom = DateFrom,
                DateTo = DateTo,
                IsExcludeZeroBalance = IsExcludeZeroBalance,
                NoteGroupID = NoteGroupID
            });
            return View(data);
        }
        public async Task<IActionResult> FinancialPositionReportView(int CompanyID, int BusinessID, DateTime DateFrom, DateTime DateTo,
            int WithDetail, int Status, int WithClosingBalance)
        {
            int NoteGroupID = 1;
            var data = await Mediator.Send(new BalanceSheetNoteSummaryWithPreviousGetQuery
            {
                CompanyID = CompanyID,
                BusinessID = BusinessID,
                DateFrom = DateFrom,
                DateTo = DateTo,
                WithDetail = WithDetail,
                Status = Status,
                WithClosingBalance = WithClosingBalance,
                NoteGroupID = NoteGroupID
            });
            return View(data);
        }
        public async Task<IActionResult> ProfitLossComprehensiveIncomeReportView(int CompanyID, int BusinessID, DateTime DateFrom, DateTime DateTo,
            int WithDetail, int Status, int WithClosingBalance)
        {
            int NoteGroupID = 2;//income statement
            var data = await Mediator.Send(new BalanceSheetNoteSummaryWithPreviousGetQuery
            {
                CompanyID = CompanyID,
                BusinessID = BusinessID,
                DateFrom = DateFrom,
                DateTo = DateTo,
                WithDetail = WithDetail,
                Status = Status,
                WithClosingBalance = WithClosingBalance,
                NoteGroupID = NoteGroupID
            });
            return View(data);
        }
        //

        public async Task<JsonResult> ShowParticularGroups(int particularSerial, int groupCategoryID)
        {
            var data = await Mediator.Send(new GetParticularGroupsQuery { ParticularSerial = particularSerial, GroupCategoryID = groupCategoryID });
            return Json(data);
        }
      [AllowAnonymous]
        public ActionResult CallVoucherInfoViewComponent(int AccountID, DateTime DateFrom, DateTime DateTo, bool NeedConversion=false)
        {
            var viewComponentName = "VoucherShortInfo";
            var reqData = new VoucherShortInfoVCQM()
            {
               AccountId=AccountID,
               DateFrom=DateFrom,
               DateTo=DateTo,
               NeedConversion=NeedConversion
            };           

            return ViewComponent(viewComponentName, reqData);
        }
        [AllowAnonymous]
        public ActionResult CallVoucherInfoTBViewComponent(int AccountID,DateTime DateFrom,DateTime DateTo, bool NeedConversion = false)
        {
            var viewComponentName = "VoucherShortInfoTB";
            var reqData = new VoucherShortInfoTBVCQM()
            {
                AccountId = AccountID,
                DateFrom=DateFrom,
                DateTo=DateTo,
                NeedConversion = NeedConversion
            };

            return ViewComponent(viewComponentName, reqData);
        }

    }
}
