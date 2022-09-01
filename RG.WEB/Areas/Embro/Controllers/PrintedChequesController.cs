using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Contracts.Embro.Business.CBM_Cheque.Queries;
using RG.Application.Contracts.Embro.Setups.CBM_BankAccountSetups.Queries;
using RG.Application.Contracts.Embro.Setups.CBM_Banks.Queries;
using RG.Application.Contracts.Embro.Setups.CBM_PrintedCheques.Commands.DataTransferModel;
using RG.Application.Contracts.Embro.Setups.CBM_PrintedCheques.Commands.Update;
using RG.Application.Contracts.Embro.Setups.CBM_PrintedChequeStatuss.Queries;
using RG.Application.ViewModel.Embro.Business.PrintedCheques;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RG.WEB.Areas.Embro.Controllers
{
    [Area("Embro")]
    [Route("Embro/[controller]/[action]")]
    public class PrintedChequesController : BaseController
    {
        private readonly IDropdownService _dropdownService;
        public PrintedChequesController(IDropdownService dropdownService)
        {
            _dropdownService = dropdownService;
        }
        public async Task<IActionResult> ChequesStatus()
        {
            var model = new ChequesStatusVM()
            {
                DDLBank = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCBM_BankQuery { })),
                DDLAccount = _dropdownService.DefaultDDL(),
                DDLPaidTo = _dropdownService.DefaultDDL(),
                DDLStatus = await Mediator.Send(new GetDDLPrintedChequeStatusQuery { }),
                DateFrom = (new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)).ToString("dd-MMM-yyyy"),
                DateTo = DateTime.Now.ToString("dd-MMM-yyyy"),
                ClearingDate = DateTime.Now.ToString("dd-MMM-yyyy")
            };
            return View(model);
        }
        [HttpGet]
        public async Task<JsonResult> GetDDLCBM_BankAccount(int bankID, string predict)
        {
            var data = await Mediator.Send(new GetDDLCBM_BankAccountQuery { BankID = bankID, Predict = predict });
            return Json(data);
        }
        public async Task<JsonResult> GetDDLSupplierWhomChequePaidTo(int accountID, DateTime fromDate, DateTime toDate, string predict)
        {
            var data = await Mediator.Send(new DDLSupplierWhomChequePaidToGetQuery { AccountID = accountID,FromDate=fromDate,ToDate=toDate, Predict = predict });
            return Json(data);
        }
        
       [HttpPost]
        public async Task<IActionResult> UpdateChequeStatus(List<UpdateChequeStatusDTM> selectedData)
        {
            var data = await Mediator.Send(new UpdateChequeStatusQuery { SelectedData = selectedData });
            return Json(data);
        }

        public async Task<JsonResult> GetCBMPrintedCheques(DataSourceLoadOptions loadOptions, int accountID, DateTime fromDate, DateTime toDate,int statusID,string paidTo)
        {
            try
            {
                loadOptions.PrimaryKey = new[] { "ChqID" };
                loadOptions.PaginateViaPrimaryKey = true;
                var data = await Mediator.Send(new GetCBM_PrintedChequesQuery { AccountID = accountID, FromDate = fromDate, ToDate = toDate ,StatusID=statusID,PaidTo=paidTo});
                var retData = DataSourceLoader.Load(data, loadOptions);
                return Json(retData);
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
