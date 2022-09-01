using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.Setup.Buyer_Setup.Queries;
using RG.Application.Contracts.Maxco.Setup.CuttingAdditionFabricRequireds.Commands.Create;
using RG.Application.Contracts.Maxco.Setup.CuttingAdditionFabricRequireds.Commands.DataTransferModel;
using RG.Application.Contracts.Maxco.Setup.CuttingAdditionFabricRequireds.Commands.Update;
using RG.Application.Contracts.Maxco.Setup.CuttingAdditionFabricRequireds.Queries;
using RG.Application.ViewModel.Maxco.Setup;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.Maxco.Controllers
{
    [Area("Maxco")]
    [Route("Maxco/[controller]/[action]")]
    public class CuttingAdditionFabricRequiredController : BaseController
    {
        private readonly IDropdownService dropdownService;

        public CuttingAdditionFabricRequiredController(IDropdownService _dropdownService)
        {
             dropdownService = _dropdownService;
        }
        public async Task<IActionResult>  AddCuttingAdditionalFabric()
        {
            var model = new CuttingAdditionFabricRequiredVM()
            {
                DDLBuyer = dropdownService.RenderDDL(await Mediator.Send(new GetDDLBuyerAllQuery() { }))
            };
            model.RequisitionDate=DateTime.Now.ToString("dd-MMM-yyyy");
            model.FormDate=DateTime.Now.AddMonths(-1).ToString("dd-MMM-yyyy");
            model.ToDate=DateTime.Now.ToString("dd-MMM-yyyy");
           
            return View(model);
        }
        

        [HttpPost]
        public async Task<IActionResult> Create(CuttingAdditionalFabricDTM model)
        {
            var resutl = await Mediator.Send( new CreateCuttingAdditionalFabricCommand { AditionalFabric = model });
            return Json(resutl);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CuttingAdditionalFabricDTM dtm)
        {
            var rResult = new RResult();
            if (ModelState.IsValid)
            {
                rResult = await Mediator.Send(new UpdateCuttingAdditionalFabricCommand { cuttingAdditionalFabricDTM = dtm});
            }
            return Json(rResult);
        }         
        public async Task<IActionResult> Remove(int ID)
        {
            var rResult = new RResult();
            if (ModelState.IsValid)
            {
                rResult = await Mediator.Send(new RemoveCuttingAdditionalFabricCommand { ID = ID });
            }
            return Json(rResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetCuttingAdditionFabricRequiredList(DataSourceLoadOptions loadOptions, DateTime dateFrom, DateTime dateTo, long orderID=0, int buyerID=0)
        {
            loadOptions.PrimaryKey = new[] {"ID"};
            loadOptions.PaginateViaPrimaryKey = true;
            var data = await Mediator.Send(new GetCuttingAdditionFabricRequiredQuery {LoadOptions = loadOptions,OrderID=orderID,BuyerID=buyerID,DateFrom=dateFrom,DateTo=dateTo});
            return Json(data);
        }
    }
}
