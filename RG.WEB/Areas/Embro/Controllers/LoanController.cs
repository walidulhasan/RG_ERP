using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Common.Models;
using RG.Application.Contracts.Embro.Business.LoanMasters.Commands.Create;
using RG.Application.Contracts.Embro.Business.LoanMasters.Commands.Update;
using RG.Application.Contracts.Embro.Business.LoanMasters.Queries;
using RG.Application.Contracts.Embro.CompanyInfos.Queries;
using RG.Application.Contracts.Embro.Setups.CBM_Banks.Queries;
using RG.Application.Contracts.Embro.Setups.LoanTypes.Queries;
using RG.Application.ViewModel.Embro.Business.LoanMasters;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.Embro.Controllers
{
    [Area("Embro")]
    [Route("Embro/[controller]/[action]")]
    public class LoanController : BaseController
    {
        private readonly IDropdownService _dropdownService;
        private readonly ICurrentUserService _currentUserService;

        public LoanController(IDropdownService dropdownService, ICurrentUserService currentUserService)
        {
            _dropdownService = dropdownService;
            _currentUserService = currentUserService;
        }
        public async Task<IActionResult> Create()
        {
            List<SelectListItem> DDLPaymentTypes = new()
            {
                new SelectListItem { Text = "Please Select", Value = "" },
                new SelectListItem { Text = "Principal", Value = "Principal" },
                new SelectListItem { Text = "Interest Charge", Value = "Interest Charge" }
            };
            LoanMasterCreateVM model = new()
            {
                DDLPaymentPeriodInDaysWiseMonth = _dropdownService.NumberDDL(1, 12, true),
                DDLLoanTypeName = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLLoanTypeNmaeQuery { }), true),
                DDLLoanNumber = _dropdownService.DefaultDDL(),
            };
            var bank = await Mediator.Send(new GetDDLCBM_BankQuery { });
            /// ignore bank asia for robintex.
            //model.DDLBank = _dropdownService.RenderDDL(bank.Where(b => b.Value != "50").ToList());
            model.DDLBank = _dropdownService.RenderDDL(bank);
            model.DDLPaymentType = DDLPaymentTypes;
            model.StartDate = DateTime.Now;
            model.EndDate = DateTime.Now;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(LoanMasterCreateVM loanMastes)
        {
            RResult rResult = new RResult();
            //if (ModelState.IsValid)
            //{

            //}
            rResult = await Mediator.Send(new LoanMasterCreateCommand { model = loanMastes });
            return Json(rResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetLoanMasterGridDataList(DataSourceLoadOptions loadOptions, int BankID = 0, int LoanTypeID = 0, string PaymentType = null)
        {
            loadOptions.PrimaryKey = new[] { "LoanID" };
            loadOptions.PaginateViaPrimaryKey = true;
            var data = await Mediator.Send(new LoanMasterDataToGetQuery { LoadOptions = loadOptions, BankID = BankID, LoanTypeID = LoanTypeID, PaymentType = PaymentType });
            return Json(data);
        }


        //public async Task<IActionResult> Edit()
        //{
        //    LoanMasterCreateVM model = new();
        //    if (model !=null)
        //    {
        //        model = await Mediator.Send(new LoanMasterDataToGetQuery { });
        //    }
        //    else
        //    {

        //    }
        //    return Json(model);
        //}

        [HttpPost]
        public async Task<IActionResult> Update(LoanMasterCreateVM loanMaster)
        {
            var result = await Mediator.Send(new LoanMasterUpdateCommand { Model = loanMaster });
            return Json(result);
        }
        public async Task<IActionResult> Remove(int ID)
        {
            var rResult = new RResult();

            rResult = await Mediator.Send(new LoanMasterRemoveCommand { loanID = ID });
            return Json(rResult);
        }


        public async Task<IActionResult> LoanSearch()
        {
            LoanListSearchVM model = new();
            model.DDLCompany = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery() { }),true);
            model.CompanyID = _currentUserService.CompanyID;
            model.DDLBank = _dropdownService.DefaultDDL();// _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCBM_BankQuery {CompanyID= _currentUserService.CompanyID }));
            model.DDLLoanTypeName = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLLoanTypeNmaeQuery { }), true);
            model.DDLLoanNumber = _dropdownService.DefaultDDL();
            model.DateFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("dd-MMM-yyyy");
            model.DateTo = DateTime.Now.ToString("dd-MMM-yyyy");
            model.DDLReportType = GetReportTypes();
            return View(model);
        }

        private List<SelectListItem> GetReportTypes()
        {
            List<SelectListItem> typeList = new()
            {
                new SelectListItem { Text = "Loan Position", Value = "LP" },
                new SelectListItem { Text = "Loan Group Detail", Value = "LGD" },
                new SelectListItem { Text = "Loan Summary", Value = "LS" }
            };
            return typeList;
        }
        [AllowAnonymous]
        public async Task<IActionResult> BankLoanPosition(DateTime DateFrom, DateTime DateTo, int CompanyID = 0, int BankID = 0, int LoanTypeID = 0, int LoanAccID = 0)
        {

            var data = await Mediator.Send(new LoanDetailsReportQuery() { DateFrom = DateFrom, DateTo = DateTo, CompanyID = CompanyID, BankID = BankID, LoanTypeID = LoanTypeID, LoanAccID = LoanAccID });
            return View(data);
        }
        [AllowAnonymous]
        public async Task<IActionResult> BankLoanGroupDetail(int month,int year,string dateFrom, string dateTo, int companyID = 0, int bankID = 0, int loanTypeID = 0, int loanAccID = 0,int userID=0)
        {
            DateTime DateFrom = new();
            DateTime DateTo = new();
            if (month>0 && year>0)
            {
                DateFrom = new DateTime(year, month, 1);
                DateTo = DateFrom.AddMonths(1).AddDays(-1);
            }
            else
            {
                DateFrom =Convert.ToDateTime(dateFrom);
                DateTo = Convert.ToDateTime(dateTo);
            }

            var data = await Mediator.Send(new LoanDetailsReportQuery() { DateFrom = DateFrom, DateTo = DateTo, CompanyID = companyID, BankID = bankID, LoanTypeID = loanTypeID, LoanAccID = loanAccID ,UserID=userID});
            return View(data);
        }
        [AllowAnonymous]
        public async Task<IActionResult> BankLoanSummary(int month, int year, string DateFrom, string DateTo, int CompanyID = 0, int BankID = 0, int LoanTypeID = 0, int LoanAccID = 0)
        {
            DateTime dateFrom = new();
            DateTime dateTo = new();
            if (month > 0 && year > 0)
            {
                dateFrom = new DateTime(year, month, 1);
                dateTo = dateFrom.AddMonths(1).AddDays(-1);
            }
            else
            {
                dateFrom = Convert.ToDateTime(DateFrom);
                dateTo = Convert.ToDateTime(DateTo);
            }
            var data = await Mediator.Send(new LoanDetailsReportQuery() { DateFrom = dateFrom, DateTo = dateTo, CompanyID = CompanyID, BankID = BankID, LoanTypeID = LoanTypeID, LoanAccID = LoanAccID });
            return View(data);
        }

        public async Task<JsonResult> DDLLoanAccounts(int bankID, int loanTypeID, string predict)
        {
            var data = await Mediator.Send(new DDLLoanAccountsGetQuery { BankID = bankID, LoanTypeID = loanTypeID, Predict = predict });
            return Json(data);
        }

    }
}
