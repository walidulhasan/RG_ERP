using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries.RequestResponseModel;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_Departments.Queries;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_UnitSetups.Queries;
using RG.Application.Contracts.Maxco.Buisness.Style.Queries;
using RG.Application.Contracts.Maxco.Setup.Buyer_Setup.Queries;
using RG.Application.Contracts.Maxco.Setup.Country_Assorment_Setups.Queries;
using RG.Application.ViewModel.MaterialsManagement.Business.GatePass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RG.WEB.ViewComponents
{
    public class ExportSalesViewComponent : ViewComponent
    {
        private readonly IMediator mediator;
        private readonly IDropdownService dropdownService;

        public ExportSalesViewComponent(IMediator _mediator, IDropdownService _dropdownService)
        {
            mediator = _mediator;
            dropdownService = _dropdownService;
        }
        public async Task<IViewComponentResult> InvokeAsync(GatePassAllCategoryVCQM reqData)
        {
            try
            {
                List<string> withShortName = new() { { "crt" }, { "pc" }, { "Set" }, { "Pack" } };
                var model = new ExportSalesVCVM();
                model.UnitOfMeasurementList = await mediator.Send(new DDLGetAllIC_UnitListQuery { WithShortName = withShortName });
                model.BuyerList = dropdownService.RenderDDL(await mediator.Send(new GetDDLBuyerAllQuery()), true);
                model.OrderList = dropdownService.DefaultDDL();
                model.CountryList = dropdownService.RenderDDL(await mediator.Send(new DDLGetCountryListQuery()), true);
                model.DepartmentList = await mediator.Send(new GetDDLDepartmentByUserQuery() { UserID = reqData.UserID });
                 
                if (reqData.GatePassID > 0)
                {
                    var allOrder = await mediator.Send(new GetDDLOrdersWithOutSampleQuery() { BuyerID = 0, FromDate = DateTime.Now.AddYears(-2), Predict = null });
                    var data = await mediator.Send(new GetICGatepassMasterDetailInfoByIDQuery { GatePassID = reqData.GatePassID });
                    var items = data.IC_ExportSalesGatePassMaster.IC_ExportSalesGatePassDetail
                        .Select(x => new ExportSalesItemVM()
                        {
                            ID = x.Id,
                            ItemName = x.ItemName,
                            UnitID = x.UnitId,
                            InvoiceNumber = x.InvoiceNumber??"",
                            BuyerID = x.BuyerID,
                            BuyerName = x.BuyerName,
                            ClearingAgent = x.ClearingAgent ?? "",
                            Seal = x.SealNo ?? "",
                            ShippingLine = x.ShippingLine ?? "",
                            Remarks = x.Remarks ?? "",
                            Quantity = x.Quantity,
                            CartonQuantity = x.CartonQty,
                            FromE = x.FormENo??"",
                            Container = x.ContainerNo??"",
                            ContainerSize = x.ContainerSize??"",
                            OrderID = x.OrderID,
                            CountryID = x.CountryID,
                            CountryName = (x.CountryID != null && x.CountryID>0 )? model.CountryList.Where(z => z.Value.Equals(x.CountryID.ToString())).First().Text : "",
                            UnitOfMeasurement = model.UnitOfMeasurementList.Where(z => z.Value == x.UnitId.ToString()).First().Text
                        }).ToList();
                   

                    model.GatePassID = data.ID;
                    model.IssuedTo = data.IC_ExportSalesGatePassMaster.CustomerId;
                    //model.VehicleNo = data.VehicleNo;
                    model.Purpose = data.IC_ExportSalesGatePassMaster.Purpose;
                    model.VehicleRef = data.IC_ExportSalesGatePassMaster.VehicleRef;
                    model.Description = data.IC_ExportSalesGatePassMaster.Description;
                    model.DriverName = data.IC_ExportSalesGatePassMaster.DriverName;
                    model.MobileNo = data.IC_ExportSalesGatePassMaster.MobileNo;
                    model.TransportServiceName = data.IC_ExportSalesGatePassMaster.TransportServiceName;
                    model.DepartmentID = data.IC_ExportSalesGatePassMaster.DepartmentID;
                    model.ExportSalesItem = items;

                    foreach (var item in model.ExportSalesItem)
                    {
                        if (item.OrderID != null)
                        {
                            item.OrderNo = allOrder.Where(o => o.Value == item.OrderID.ToString()).FirstOrDefault().Text;
                        }
                    }
                    //model.DataJson = System.Text.Json.JsonSerializer.Serialize(model.ExportSalesItem);
                }
                return View("ExportSalesVC", model);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
         
    }
}
