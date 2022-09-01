using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.MaterialsManagement.Business.YarnStockReport.RequestResponseModel;
using RG.Application.Contracts.MaterialsManagement.Setups.BuildingInfos.Queries;
using RG.Application.Contracts.Maxco.Setup.FabricYarnComposition_Setups.Queries;
using RG.Application.Contracts.Maxco.Setup.FabricYarnCount_Setups.Queries;
using RG.Application.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RG.WEB.ViewComponents
{
    public class RackWiseYarnReportViewComponent : ViewComponent
    {
        private readonly IDropdownService _dropdownService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMediator _mediator;

        public RackWiseYarnReportViewComponent(IDropdownService dropdownService, ICurrentUserService currentUserService, IMediator mediator)
        {
            _dropdownService = dropdownService;
            _currentUserService = currentUserService;
            _mediator = mediator;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var model = new RackWiseYarnReportVCQM
            {
                DDLBulding = _dropdownService.RenderDDL(await _mediator.Send(new DDLFloorTypeWiseBuildingQuery { FloorType = (int)enum_FloorType.YarnStore }), true),
                DDLBuildingFloor = _dropdownService.DefaultDDL(),
                DDLRack = _dropdownService.DefaultDDL(),
                DDLLotno = _dropdownService.DefaultDDL(),
                DDLYarnComposition = _dropdownService.RenderDDL(await _mediator.Send(new GetDDLFabricYarnCompositionQuery { }), true),
                DDLYarnCount = _dropdownService.RenderDDL(await _mediator.Send(new GetDDLFabricYarnCountQuery { DescriptionInBothTextValue = true }), true),
            DDLOrderBy = _dropdownService.RenderDDL(GetDDLOrderBy(), true)
            };

            return View("RackWiseYarnReportVC", model);
        }

        private List<SelectListItem> GetDDLOrderBy()
        {
            List<SelectListItem> ddl = new()
            {
                new SelectListItem { Text = "Lot Wise", Value = "1" },
                new SelectListItem { Text = "Sub-Rack Wise", Value = "2" }
            };
            return ddl;
        }
    }
}
