using MediatR;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using RG.Application.Interfaces.Services.Maxco.Business;
using RG.Application.Interfaces.Services.Maxco.Setup;
using RG.Application.ViewModel.MaterialsManagement.Business.GatePass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries
{
   public  class GetExportSalesItemQuery :IRequest<List<ExportSalesItemVM>>
    {
        public long GatePassID { get; set; }
    }

    public class GetExportSalesItemQueryHandler : IRequestHandler<GetExportSalesItemQuery, List<ExportSalesItemVM>>
    {
        private readonly IIC_GatepassMasterService _iC_GatepassMasterService;
        private readonly ICountry_Assorment_SetupService _country_Assorment_SetupService;
        private readonly IIC_UnitSetupService _iC_UnitSetupService;
        private readonly IStyleService _styleService;

        public GetExportSalesItemQueryHandler(IIC_GatepassMasterService iC_GatepassMasterService, ICountry_Assorment_SetupService country_Assorment_SetupService
            , IIC_UnitSetupService iC_UnitSetupService, IStyleService styleService)
        {
            _iC_GatepassMasterService = iC_GatepassMasterService;
            _country_Assorment_SetupService = country_Assorment_SetupService;
            _iC_UnitSetupService = iC_UnitSetupService;
            _styleService = styleService;
        }
        public async Task<List<ExportSalesItemVM>> Handle(GetExportSalesItemQuery request, CancellationToken cancellationToken)
        {
            List<string> withShortName = new() { { "crt" }, { "pc" }, { "Set" }, { "Pack" } };

            var data = await _iC_GatepassMasterService.GetExportSalesItem(request.GatePassID, cancellationToken);
            var country = await _country_Assorment_SetupService.DDLGetCountryList(cancellationToken);
            var unitList =await _iC_UnitSetupService.DDLGetAllIC_UnitList(withShortName, cancellationToken);
            var orderList = await _styleService.DDLOrdersWithOutSample(DateTime.Now.AddYears(-2), 0, null, cancellationToken);

            foreach (var item in data)
            {
                if (item.OrderID != null)
                {
                    item.OrderNo = orderList.Where(o => o.Value == item.OrderID.ToString()).FirstOrDefault()?.Text??"";
                }
                if (item.CountryID != null && item.CountryID>0)
                {
                    item.CountryName = country.Where(o => o.Value == item.CountryID.ToString()).FirstOrDefault()?.Text ?? "";
                }
                if (item.UnitID != null && item.UnitID>0)
                {
                    item.UnitOfMeasurement = unitList.Where(o => o.Value == item.UnitID.ToString()).FirstOrDefault()?.Text ?? "";
                }
            }

            return data;
        }
    }
}
