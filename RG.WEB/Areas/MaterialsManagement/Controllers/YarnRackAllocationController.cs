using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.MaterialsManagement.Business.Yarn_POMaster.Queries;
using RG.Application.Contracts.MaterialsManagement.Business.YarnRackAllocations.Commands.Create;
using RG.Application.Contracts.MaterialsManagement.Business.YarnRackAllocations.Commands.DataTransferModel;
using RG.Application.Contracts.MaterialsManagement.Business.YarnRackAllocations.Queries;
using RG.Application.ViewModel.MaterialsManagement.Business.YarnRackAllocation;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RG.WEB.Areas.MaterialsManagement.Controllers
{
    [Area("MaterialsManagement")]
    [Route("MaterialsManagement/[controller]/[action]")]
    public class YarnRackAllocationController : BaseController
    {
        private readonly IDropdownService _dropDownService;
        private readonly ICurrentUserService _currentuserService;

        public YarnRackAllocationController(IDropdownService dropDownService, ICurrentUserService currentuserService)
        {
            _dropDownService = dropDownService;
            _currentuserService = currentuserService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            List<int> categoryIDList = new();
            if (_currentuserService.CompanyID == 20183)
            {
                categoryIDList.Add(20002);
            }
            else
            {
                categoryIDList.Add(2);
            }
            var model = new YarnRackAllocationCreateVM()
            {
                DDLSupplier = _dropDownService.DefaultDDL(),
                DDLPO = _dropDownService.DefaultDDL(),
                ConditionPOData = DateTime.Now.AddYears(-10).ToString("dd-MMM-yyyy")
            };
            return View(model);
        }
        [HttpPost]
        public async Task<JsonResult> Create(List<YarnRackAllocationDTM> yarnRackAllocation)
        {
            var result = await Mediator.Send(new YarnRackAllocationCreateCommand { YarnRackAllocation = yarnRackAllocation });
            return Json(result);
        }
        public async Task<JsonResult> GetDDLYarnPONo(int supplierID, DateTime? poDate = null, string predict = null)
        {
            if (poDate == null || poDate.HasValue == false)
            {
                poDate = DateTime.Now.AddYears(-1);
            }
            var data = await Mediator.Send(new GetDDLYarnPONoQuery { SupplierID = supplierID, PODateFrom = poDate.Value, PODateTo = DateTime.Now });
            return Json(data);

        }

        public async Task<JsonResult> GetSubRackCurrentStatus(long yarnStockTransactionID, int subRackID)
        {
            var allocatedQty = await Mediator.Send(new GetCurrentlyAllocatedQuantityQuery { SubRackID = subRackID });
            var currentYstAllocationQty = await Mediator.Send(new GetYarnStockTransactionWiseCurrentlyAllocatedQuantityQuery { YarnStockTransactionID = yarnStockTransactionID, SubRackID = subRackID });
            var data = new
            {
                AllocatedQty = allocatedQty,
                CurrentYstAllocationQty = currentYstAllocationQty
            };
            return Json(data);

        }

    }
}
