using MediatR;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.AOP.Business.Tbl_Issuance_Detailss.Queries;
using RG.Application.Contracts.Embro.Setups.BasicCOAs.Queries;
using RG.Application.Contracts.Embro.Setups.ERP_PaymentModess.Queries;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries.RequestResponseModel;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_Departments.Queries;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_SampleTypeProcess_Setups.Queries;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_UnitSetups.Queries;
using RG.Application.Interfaces.Repositories.AOP.Business;
using RG.Application.ViewModel.MaterialsManagement.Business.GatePass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.ViewComponents
{
    public class LocalSalesViewComponent : ViewComponent
    {
        private readonly IMediator mediator;
        private readonly IDropdownService dropDownService;
        private readonly ITbl_Issuance_MasterRepository _tbl_Issuance_MasterRepository;

        public LocalSalesViewComponent(IMediator _mediator, IDropdownService _dropDownService, ITbl_Issuance_MasterRepository tbl_Issuance_MasterRepository)
        {
            mediator = _mediator;
            dropDownService = _dropDownService;
            _tbl_Issuance_MasterRepository = tbl_Issuance_MasterRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync(GatePassAllCategoryVCQM reqData)
        {

            var model = new LocalSalesVCVM
            {
                DepartmentList = dropDownService.RenderDDL(await mediator.Send(new GetDDLDepartmentByUserQuery() { UserID = reqData.UserID })),
                CustomerList = dropDownService.DefaultDDL(),
                ProcessList = dropDownService.RenderDDL(await mediator.Send(new GetDDLIC_ProcessSetupQuery())),
                IssuanceDetailList = dropDownService.DefaultDDL(),
                WorkOrderNoList = dropDownService.DefaultDDL(),
                UnitOfMeasurementID = "1",// unit id not found in db so default kg is set as per habib vi's suggestion
                UnitOfMeasurementList = dropDownService.RenderDDL(await mediator.Send(new DDLGetAllIC_UnitListQuery())),
                DDLPaymentMode = dropDownService.RenderDDL(await mediator.Send(new GetDDLERP_PaymentModesQuery { }), false)
            };

            if (reqData.GatePassID > 0)
            {
                try
                {
                    var data = await mediator.Send(new GetICGatepassMasterDetailInfoByIDQuery() { GatePassID = reqData.GatePassID });
                    var supplierInfo = await mediator.Send(new GetBasicCOAQuery() { ID = data.IC_LocalSalesGatePassMaster.CustomerID > 0 ? (decimal)data.IC_LocalSalesGatePassMaster.CustomerID : 0 });
                    var departmentInfo = await mediator.Send(new GetDepartmentInfoQuery() { DepartmentID = data.IC_LocalSalesGatePassMaster.DepartmentID });
                    var items = data.IC_LocalSalesGatePassMaster.IC_LocalSalesGatePassDetail
                        .Select(x => new LocalSalesItemVM()
                        {
                            ID = x.ID,
                            FinishCode = x.ColorFinishCode,
                            IssuanceDetailID = x.IssuanceDetailID,
                            GrossWeight = (decimal)x.GrossWeight,
                            ItemDetail = x.ItemType,
                            NetWeight = (decimal)x.NetWeight,
                            ProcessCode = x.ProcessCodeID,
                            PaymentMode = x.PaymentMode,
                            ProcessId = x.ProcessId,
                            ProcessName = model.ProcessList.Where(y => y.Value == x.ProcessId.Value.ToString()).First().Text,
                            Quantity = (decimal)x.Quantity,
                            Rate = (decimal)x.Rate,
                            Remarks = x.Remarks,
                            RollCount = x.Roll,
                            UnitID = x.UnitID,
                            UnitOfMeasurement = model.UnitOfMeasurementList.Where(z => z.Value == x.UnitID.ToString()).First().Text,
                            WorkOrderNo = x.OrderNo,
                            OrderID = x.OrderID,
                            OrderName = x.OrderName,
                            RefNo = x.RefNo,
                            GreigeWidth = x.GreigeWidth,
                            FinishedWidth = x.FinishedWidth
                        }).ToList();
                    foreach (var item in items)
                    {
                        if (item.ProcessId != 6)
                        {
                            item.PMDescription = (await _tbl_Issuance_MasterRepository.GetIssuancePaymentInfo(item.IssuanceDetailID.Value)).PaymentTermFull;
                            item.IssuanceMasterID = (await mediator.Send(new GetTbl_Issuance_DetailsByIDQurey() { ID = item.IssuanceDetailID.Value })).Transation_ID;
                        }
                    }
                    model.GatePassID = data.ID;
                    model.DepartmentID = data.IC_LocalSalesGatePassMaster.DepartmentID;
                    model.CustomerID = data.IC_LocalSalesGatePassMaster.CustomerID;
                    model.CustomerName = supplierInfo != null ? supplierInfo.DESCRIPTION.Trim() : "";
                    model.DepartmentName = departmentInfo.DepartmentName;

                    model.VehicleNo = data.VehicleNo;
                    model.isSelfVehicle = data.IC_LocalSalesGatePassMaster.isSelfVehicle;
                    model.LocalSalesItems = items;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }

            return View("LocalSalesVC", model);
        }
    }
}
