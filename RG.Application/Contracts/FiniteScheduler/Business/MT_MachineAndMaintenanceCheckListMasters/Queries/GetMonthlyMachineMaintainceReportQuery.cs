using MediatR;
using RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Queries
{
    public class GetMonthlyMachineMaintainceReportQuery : IRequest<List<MonthlyMachineMaintainceRM>>
    {
        public int LocationID { get; set; }
        public int Month { get; set; }
        public int YearID { get; set; }
    }
    public class GetMonthlyMachineMaintainceReportQueryHandler : IRequestHandler<GetMonthlyMachineMaintainceReportQuery, List<MonthlyMachineMaintainceRM>>
    {
        private readonly IMT_MachineAndMaintenanceCheckListMasterService _mtMachineAndMaintenanceCheckListMasterService;

        public GetMonthlyMachineMaintainceReportQueryHandler(IMT_MachineAndMaintenanceCheckListMasterService mtMachineAndMaintenanceCheckListMasterService)
        {
            _mtMachineAndMaintenanceCheckListMasterService = mtMachineAndMaintenanceCheckListMasterService;
        }

        public async Task<List<MonthlyMachineMaintainceRM>> Handle(GetMonthlyMachineMaintainceReportQuery request, CancellationToken cancellationToken)
        {
              return await _mtMachineAndMaintenanceCheckListMasterService.GetMonthlyMachineMaintainceReport(request.LocationID, request.Month, request.YearID, cancellationToken);
        }
    }
}
