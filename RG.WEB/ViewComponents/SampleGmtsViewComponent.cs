using MediatR;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries.RequestResponseModel;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_Departments.Queries;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_SampleCustomerTypes.Queries;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_SampleType_Setups.Queries;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_SampleTypeProcess_Setups.Queries;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_UnitSetups.Queries;
using RG.Application.Contracts.Maxco.Buisness.Style.Queries;
using RG.Application.Contracts.Maxco.Setup.Buyer_Setup.Queries;
using RG.Application.ViewModel.MaterialsManagement.Business.GatePass;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.ViewComponents
{
    public class SampleGmtsViewComponent : ViewComponent
    {
        private readonly IMediator mediator;
        private readonly IDropdownService dropdownService;

        public SampleGmtsViewComponent(IMediator _mediator, IDropdownService _dropdownService)
        {
            mediator = _mediator;
            dropdownService = _dropdownService;
        }
        public async Task<IViewComponentResult> InvokeAsync(GatePassAllCategoryVCQM reqData)
        {

            var model = new SampleGmtsVCVM();
            model.DDLCustomerType = dropdownService.RenderDDL(await mediator.Send(new DDLSampleCustomerTypeQuery()));
            model.CustomerTypeID = 1;
            model.DDLCustomer = dropdownService.RenderDDL(await mediator.Send(new GetDDLBuyerAllQuery()), true);
            model.DDLSampleType = dropdownService.RenderDDL(await mediator.Send(new DDLSampleTypeQuery()), false);
            model.SampleTypeID = Convert.ToInt32(model.DDLSampleType.First().Value);
            model.CustomerID = 76;

            model.DDLDepartment = dropdownService.RenderDDL(await mediator.Send(new GetDDLDepartmentByUserQuery() { UserID = reqData.UserID }));

            model.DDLSampleTypeProcess = dropdownService.RenderCustomDDL(await mediator.Send(new DDLCustomSampleTypeProcessQuery() { SampleTypeID = 0 }), true);
            model.UnitOfMeasurementList = await mediator.Send(new DDLGetAllIC_UnitListQuery());//ddlCommon.DefaultDDL();
            if (reqData.GatePassID > 0)
            {
                var data = await mediator.Send(new GetICGatepassMasterDetailInfoByIDQuery { GatePassID = reqData.GatePassID });
                var items = data.IC_SampleGatePassMaster.IC_SampleGatePassDetail
                    .Select(x => new SampleItemVM()
                    {
                        ID = x.ID,
                        ItemName = x.ItemName,
                        Quantity = x.Quantity,
                        Remarks = x.Remarks,
                        UnitID = x.UnitID,
                        UnitOfMeasurement = model.UnitOfMeasurementList.Where(u => u.Value == x.UnitID.ToString()).First().Text
                    }).ToList();



                var checkprocess = model.DDLSampleTypeProcess.Where(b => b.Value == data.IC_SampleGatePassMaster.SampleProcessTypeID.ToString()).FirstOrDefault();
                if (checkprocess != null && Convert.ToInt32(checkprocess.Custom1) < 3 && data.IC_SampleGatePassMaster.OrderID > 0)
                {
                    var orderinfo = await mediator.Send(new GetStyleInfoQuery() { ID = (long)data.IC_SampleGatePassMaster.OrderID });
                    model.OrderNo = orderinfo.OrderNo;
                }
                model.GatePassID = data.ID;
                model.OrderID = data.IC_SampleGatePassMaster.OrderID;
                model.CustomerTypeID = data.IC_SampleGatePassMaster.CustomerTypeID;
                model.CustomerID = data.IC_SampleGatePassMaster.CustomerID;
                model.CustomerName = data.IC_SampleGatePassMaster.CustomerName;
                model.DepartmentID = data.IC_SampleGatePassMaster.DepartmentID;

                model.SampleProcessTypeID = data.IC_SampleGatePassMaster.SampleProcessTypeID;
                model.CarrierName = data.IC_SampleGatePassMaster.CarrierName;
                model.ReferenceNo = data.IC_SampleGatePassMaster.ReferenceNo;
                model.LabSampleNo = data.IC_SampleGatePassMaster.WeightSlipNo;
                model.SampleDescription = data.IC_SampleGatePassMaster.SampleDescription;

                model.SampleItems = items;

            }
            model.DDLOrder = dropdownService.RenderDDL(await mediator.Send(new DDLGetOrderListQuery() { BuyerID = model.CustomerID.Value, OrderConditionDate = DateTime.Now.AddYears(-3) }));
            return View("SampleGmtsVC", model);
        }
    }
}
