using MediatR;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.Embro.Setups.BasicCOAs.Queries;
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
    public class NonReturnableViewComponent : ViewComponent
    {
        private readonly IMediator mediator;
        private readonly IDropdownService dropdownService;

        public NonReturnableViewComponent(IMediator _mediator,IDropdownService _dropdownService)
        {
            mediator = _mediator;
            dropdownService = _dropdownService;
        }
        public async Task<IViewComponentResult> InvokeAsync(GatePassAllCategoryVCQM reqData)
        {            
            var model = new NonReturnableVCVM();
            model.UnitOfMeasurementList = await mediator.Send(new DDLGetAllIC_UnitListQuery());
            model.DepartmentList = await mediator.Send(new GetDDLDepartmentByUserQuery() { UserID = reqData.UserID });
            model.CustomerList = dropdownService.DefaultDDL();//dropdownService.RenderDDL(await mediator.Send(new GetDDLBasicCOASupplierComQuery() {AccCategoryID=0,CompanyID=0 }));
            if (reqData.GatePassID > 0)
            {
                var data = await mediator.Send(new GetICGatepassMasterDetailInfoByIDQuery { GatePassID = reqData.GatePassID });
                var items = data.IC_NonReturnableGatePassMaster.IC_NonReturnableGatePassDetail
                    .Select(x => new NonReturnableItemVM()
                    {
                        ID = x.ID,
                        ItemName = x.ItemName,
                        NonReturnableGatePassID = x.NonReturnableGatePassID,
                        Remarks = x.Remarks,
                        UnitID = x.UnitID,
                        UnitOfMeasurement = model.UnitOfMeasurementList.Where(u => u.Value == x.UnitID.ToString()).First().Text,
                        GrossWeight = x.GrossWeight,
                        Quantity = x.Quantity
                    }).ToList();

                model.GatePassID = data.ID;
                model.DepartmentID = data.IC_NonReturnableGatePassMaster.DepartmentID;
                model.IssuedTo = data.IC_NonReturnableGatePassMaster.IssuedToID;
                model.Purpose = data.IC_NonReturnableGatePassMaster.Purpose;
                model.VehicleNo = data.VehicleNo;
                model.CustomerID = data.IC_NonReturnableGatePassMaster.CustomerID;

                if (model.CustomerID > 0)
                {
                    var supplierName = await mediator.Send(new GetBasicCOAQuery() { ID = (decimal)model.CustomerID });
                    model.IssuedTo = supplierName.DESCRIPTION.Trim();
                }

                model.NonReturnableItems = items;
            }
            return View("NonReturnableVC", model);
        }
    }
}
