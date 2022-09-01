using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.Setup.Production_Efficiency.Commands.Create;
using RG.Application.Contracts.Maxco.Setup.Production_Efficiency.Commands.DataTransferModel;
using RG.Application.Contracts.Maxco.Setup.Production_Efficiency.Commands.Update;
using RG.Application.Contracts.Maxco.Setup.Production_Efficiency.Queries;
using RG.Application.ViewModel.Maxco.Setup;
using RG.WEB.Controllers;
using System;
using System.Threading.Tasks;

namespace RG.WEB.Areas.Maxco.Controllers
{
    [Area("Maxco")]
    [Route("Maxco/[controller]/[action]")]
    public class ProductionEfficiencyController : BaseController
    {
        public IActionResult Create()
        {
            var model = new ProductionEfficiencyCreateVM();
            model.ProductionDate = DateTime.Now.ToString("dd-MMM-yyyy");
          
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductionEfficiencyDTM ProductionEfficiency)
        {
            var resutl = await Mediator.Send(new ProductionEfficiencyCreateCommand { ProductionEfficiency = ProductionEfficiency });
            return Json(resutl);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductionEfficiencyList(DataSourceLoadOptions loadOptions)
        {
            loadOptions.PrimaryKey = new[] { "ID" };
            loadOptions.PaginateViaPrimaryKey = true;
            var data = await Mediator.Send(new GetProductionEfficiencyQuery { LoadOptions = loadOptions });
            return Json(data);
        }

        
        public async Task<IActionResult> Remove(int ID)
        {
            var rResult = new RResult();
            
            rResult = await Mediator.Send(new ProductionEfficencyRemoveCommand { ID = ID });

            return Json(rResult);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductionEfficiencyDTM productionEfficiency)
        {
            var rResult = new RResult();
            rResult = await Mediator.Send(new ProductionEfficencyUpdateCommand { ProductionEfficency = productionEfficiency });

            return Json(rResult);
        }
    }
}
