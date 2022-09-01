using MediatR;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.Embro.Setups.SupplierSetups.Queries;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries.RequestResponseModel;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_Departments.Queries;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_UnitSetups.Queries;
using RG.Application.ViewModel.MaterialsManagement.Business.GatePass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.ViewComponents
{
    public class ScrapSalesViewComponent : ViewComponent
    {
        private readonly IMediator mediator;
        private readonly IDropdownService dropdownService;

        public ScrapSalesViewComponent(IMediator _mediator, IDropdownService _dropdownService)
        {
            mediator = _mediator;
            dropdownService = _dropdownService;
        }
        public async Task<IViewComponentResult> InvokeAsync(GatePassAllCategoryVCQM reqData)
        {
            
            var model = new ScrapSalesVCVM();
            model.DepartmentList = dropdownService.RenderDDL(await mediator.Send(new GetDDLDepartmentByUserQuery() { UserID = reqData.UserID }));

            model.CustomerList = dropdownService.DefaultDDL();
            
            model.UnitOfMeasurementList = await mediator.Send(new DDLGetAllIC_UnitListQuery());//dropdownService.DefaultDDL();
            

            if (reqData.GatePassID > 0)
            {
                var data = await mediator.Send(new GetICGatepassMasterDetailInfoByIDQuery { GatePassID = reqData.GatePassID });
                var items = data.IC_ScrapSalesGatePassMaster.IC_ScrapSalesGatePassDetail
                    .Select(x => new ScrapSalesItemVM()
                    {
                        ID = x.ID,
                        ItemName = x.ItemName,
                        Quantity = x.Quantity,
                        Rate = x.Rate,
                        Remarks = x.Remarks,
                        UnitID = x.UnitID,
                        UnitOfMeasurement = model.UnitOfMeasurementList.Where(z => z.Value == x.UnitID.ToString()).First().Text,

                    }).ToList();
                model.GatePassID = data.ID;
                model.DepartmentID = data.IC_ScrapSalesGatePassMaster.DepartmentId;
                model.CustomerID = data.IC_ScrapSalesGatePassMaster.ScrapCustomerID;
                model.VehicleNo = data.VehicleNo;
                model.IsSelfVehicle = data.IC_ScrapSalesGatePassMaster.IsSelfVehicle.Value;
                model.VehicleDriverMobileNo = data.IC_ScrapSalesGatePassMaster.VehicleDriverMobileNo;
                model.Description = data.IC_ScrapSalesGatePassMaster.Description;
                model.ScrapSalesItem = items;

            }
            return View("ScrapSalesVC", model);
        }
    }
}
