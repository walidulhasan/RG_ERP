using MediatR;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.Utilities;
using RG.Application.Contracts.AOP.Setup.Tbl_PaymentTypes.Queries;
using RG.Application.Contracts.Embro.Setups.ERP_PaymentModess.Queries;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries;
using RG.Application.ViewModel.MaterialsManagement.Business.GatePass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.ViewComponents
{
    public class GatePassChallanViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public GatePassChallanViewComponent(IMediator _mediator)
        {
            mediator = _mediator;
        }
        public async Task<IViewComponentResult> InvokeAsync(GatePassChallanMasterVM reqData)
        {
            var viewComponentName = "";
            var model = await mediator.Send(new GetGatePassChallanByGatePassIDQuery() { GatePassID = (int)reqData.GatePassID });
            model.ReportType = reqData.ReportType;
            model.PaymentTypeList = await mediator.Send(new GetDDLERP_PaymentModesQuery { });
            var paymentMode = (await mediator.Send(new GetDDLERP_PaymentModesQuery { })).ToList()
                                .Where(x => x.Value == model.PaymentMode.ToString()).FirstOrDefault();
            if (paymentMode != null)
                model.PaymentModeName = paymentMode.Text;

            if (model.CategoryID == IC_DocumentCategoriesIDCC.SampleGmts)
            {
                viewComponentName = "SampleChallanVC";
            }
            else if (model.CategoryID == IC_DocumentCategoriesIDCC.LocalSales)
            {
                viewComponentName = "LocalSalesChallanVC";
            }
            else if (model.CategoryID == IC_DocumentCategoriesIDCC.NonReturnable)
            {
                viewComponentName = "NonReturnableChallanVC";
            }
            else if (model.CategoryID == IC_DocumentCategoriesIDCC.Returnable)
            {
                viewComponentName = "ReturnableChallanVC";
            }
            else if (model.CategoryID == IC_DocumentCategoriesIDCC.ExportSales)
            {
                viewComponentName = "ExportSalesChallanVC";
            }
            else if (model.CategoryID == IC_DocumentCategoriesIDCC.ScrapSales)
            {

                viewComponentName = "ScrapSalesChallanVC";
            }

            return View(viewComponentName, model);
        }
    }
}
