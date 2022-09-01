using MediatR;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.Embro.Setups.BasicCOAs.Queries;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries.RequestResponseModel;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_Departments.Queries;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_ReturnableItemCategorys.Queries;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_UnitSetups.Queries;
using RG.Application.ViewModel.MaterialsManagement.Business.GatePass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.ViewComponents
{
    public class ReturnableViewComponent : ViewComponent
    {
        private readonly IMediator mediator;
        private readonly ICurrentUserService currentUserService;
        private readonly IDropdownService dropdownService;

        public ReturnableViewComponent(IMediator _mediator, ICurrentUserService _currentUserService
            , IDropdownService _dropdownService)
        {
            mediator = _mediator;
            currentUserService = _currentUserService;
            dropdownService = _dropdownService;
        }
        public async Task<IViewComponentResult> InvokeAsync(GatePassAllCategoryVCQM reqData)
        {
           
            var model = new ReturnableVCVM();
            try
            {
                model.NarrowGroupTypeList = dropdownService.RenderDDL(await mediator.Send(new GetDDLReturnableNarrowGroupQuery { CompanyID = currentUserService.CompanyID }));//
                model.IdentificationList = dropdownService.DefaultDDL();
                model.VendorList = dropdownService.DefaultDDL();
                model.UnitOfMeasurementList = await mediator.Send(new DDLGetAllIC_UnitListQuery());
                model.DepartmentList = await mediator.Send(new GetDDLDepartmentByUserQuery() { UserID = reqData.UserID });
                model.ReturnableItemCategoryList = dropdownService.RenderDDL(await mediator.Send(new GetDDLIC_ReturnableItemCategoryQuery { }), true);
                model.RequisitionList = dropdownService.DefaultDDL();
                if (reqData.GatePassID > 0)
                {
                    var data = await mediator.Send(new GetICGatepassMasterDetailInfoByIDQuery { GatePassID = reqData.GatePassID });
                    var items = data.IC_ReturnableGatePassMaster.IC_ReturnableGatePassDetail
                        .Select(x => new ReturnableItemVM()
                        {
                            ID = x.ID,
                            ReturnableItemCategoryID = x.ReturnableItemCategoryID,
                            ReturnableItemCategory = model.ReturnableItemCategoryList.Where(z => z.Value == x.ReturnableItemCategoryID.ToString()).First().Text,
                            RequisitionID = x.RequisitionID,
                            ItemName = x.ItemName,
                            Quantity = x.Quantity,
                            UnitID = x.UnitID,
                            GrossWeight = x.GrossWeight,
                            ReturnDate = x.ExpectedReturnDate.ToString("dd-MMM-yyyy"),
                            Remarks = x.Remarks,
                            UnitOfMeasurement = model.UnitOfMeasurementList.Where(z => z.Value == x.UnitID.ToString()).First().Text
                        }).ToList();

                    model.GatePassID = data.ID;
                    model.VendorRepresentative = data.IC_ReturnableGatePassMaster.IssuedTo;
                    model.VendorID = data.IC_ReturnableGatePassMaster.VendorID;
                    model.isSelfVehicle = data.IC_ReturnableGatePassMaster.isSelfVehicle;
                    model.VehicleNo = data.VehicleNo;
                    model.CompanyRepresentative = data.IC_ReturnableGatePassMaster.Representative;
                    model.VendorRepresentativeContactNo = data.IC_ReturnableGatePassMaster.RepresentativeContact;
                    model.CompanyRepresentativeID = data.IC_ReturnableGatePassMaster.HRMSID;
                    model.JobDescription = data.IC_ReturnableGatePassMaster.JobDesc;
                    model.NarrowGroupType = data.IC_ReturnableGatePassMaster.NarrowGroupId;
                    model.Identification = data.IC_ReturnableGatePassMaster.IdentificationId;
                    model.IdentificationName = (await mediator.Send(new GetBasicCOAQuery { ID = data.IC_ReturnableGatePassMaster.IdentificationId.Value })).DESCRIPTION;
                    model.VendorName = (await mediator.Send(new GetBasicCOAQuery { ID = data.IC_ReturnableGatePassMaster.VendorID })).DESCRIPTION;
                    model.DepartmentID = data.IC_ReturnableGatePassMaster.DepartmentID;
                    model.ReturnableItem = items;
                    model.IdentificationList = dropdownService.RenderDDL(await mediator.Send(new GetDDLBasicCoaQuery { ParentID = model.NarrowGroupType, LevelID = 0, Predict = null }), true);
                    model.VendorList = dropdownService.RenderDDL(await mediator.Send(new GetDDLBasicCoaQuery { ParentID = model.Identification, LevelID = 0, Predict = null }), true);
                }
            }
            catch (System.Exception e)
            {
                throw;
            }

            return View("ReturnableVC", model);
        }
    }
}
