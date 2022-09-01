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
    public class GetMachineMaintainceItemDetailInfoQuery:IRequest<List<MachineMaintainceItemDetailRM>>
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public int LocationID { get; set; }
        public int MachineID { get; set; }
    }
    public class GetMachineMaintainceItemDetailInfoQueryHandler : IRequestHandler<GetMachineMaintainceItemDetailInfoQuery, List<MachineMaintainceItemDetailRM>>
    {
        private readonly IMT_MachineAndMaintenanceCheckListMasterService mT_MachineAndMaintenanceCheckListMasterService;

        public GetMachineMaintainceItemDetailInfoQueryHandler(IMT_MachineAndMaintenanceCheckListMasterService _mT_MachineAndMaintenanceCheckListMasterService)
        {
            mT_MachineAndMaintenanceCheckListMasterService = _mT_MachineAndMaintenanceCheckListMasterService;
        }
        public async Task<List<MachineMaintainceItemDetailRM>> Handle(GetMachineMaintainceItemDetailInfoQuery request, CancellationToken cancellationToken)
        {
            return await mT_MachineAndMaintenanceCheckListMasterService.GetMachineMaintainceItemDetailInfo(request.Month, request.Year, request.LocationID, request.MachineID, cancellationToken);
        }
    }
}
