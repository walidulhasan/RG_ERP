using MediatR;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.Utilities;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.ViewComponents
{
    public class DeliveryChallanViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public DeliveryChallanViewComponent(IMediator _mediator)
        {
            mediator = _mediator;
        }
        public async Task<IViewComponentResult> InvokeAsync(int gatePassID)
        {
            var viewComponentName = "";
            var model = await mediator.Send(new GetGatePassChallanByGatePassIDQuery() { GatePassID = gatePassID });
            if (model.CategoryID == IC_DocumentCategoriesIDCC.SampleGmts)
            {
                viewComponentName = "SampleDeliveryChallanVC";
            }
            else if (model.CategoryID == IC_DocumentCategoriesIDCC.LocalSales)
            {
                viewComponentName = "LocalSalesDeliveryChallanVC";
            }
            else if (model.CategoryID == IC_DocumentCategoriesIDCC.NonReturnable)
            {
                viewComponentName = "NonReturnableDeliveryChallanVC";
            }
            else if (model.CategoryID == IC_DocumentCategoriesIDCC.Returnable)
            {
                viewComponentName = "ReturnableDeliveryChallanVC";
            }
            else if (model.CategoryID == IC_DocumentCategoriesIDCC.ExportSales)
            {
                viewComponentName = "ExportSalesDeliveryChallanVC";
            }
            else if (model.CategoryID == IC_DocumentCategoriesIDCC.ScrapSales)
            {
                viewComponentName = "ScrapSalesDeliveryChallanVC";
            }

            return View(viewComponentName, model);
        }
    }
}
