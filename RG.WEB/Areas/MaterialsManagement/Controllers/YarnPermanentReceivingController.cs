using Microsoft.AspNetCore.Mvc;
using RG.Application.Contracts.MaterialsManagement.Business.Yarn_PermanentReceivingMasters.Queries;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.MaterialsManagement.Controllers
{
    [Area("MaterialsManagement")]
    [Route("MaterialsManagement/[controller]/[action]")]
    public class YarnPermanentReceivingController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> GetYarnReceivingByPOForRackAllocation(long supplierID = 0, long poID = 0, long yarnPermRecID = 0, int topData = 50,string lotNo="")
        {
            var data = await Mediator.Send(new GetYarnReceivingByPOForRackAllocationQuery { SupplierID = supplierID, POID = poID, YarnPermRecID = yarnPermRecID, TopData = topData,LotNo=lotNo });
            return Json(data);
        }
        public async Task<JsonResult> DDLYarnReceivedBalanceLot(long supplierID = 0, long poID = 0, int topData = 500, string predict = null)
        {
            var data = await Mediator.Send(new DDLYarnReceivedBalanceLotQuery { SupplierID = supplierID, POID = poID, TopData = topData,Predict=predict });
            return Json(data);
        }
        
    }
}
