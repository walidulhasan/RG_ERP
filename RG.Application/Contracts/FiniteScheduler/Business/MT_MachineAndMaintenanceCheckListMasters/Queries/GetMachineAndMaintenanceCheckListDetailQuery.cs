using MediatR;
using RG.Application.Contracts.AlgoHR.Business.ApprovalNotifications.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Business;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Queries
{
    public class GetMachineAndMaintenanceCheckListDetailQuery : IRequest<List<MachineMaintenanceNotificationDetailRM>>
    {
        public int MasterID { get; set; }
    }
    public class GetMachineAndMaintenanceCheckListDetailQueryHandler : IRequestHandler<GetMachineAndMaintenanceCheckListDetailQuery, List<MachineMaintenanceNotificationDetailRM>>
    {

        private readonly IMT_MachineAndMaintenanceCheckListMasterService mT_MachineAndMaintenanceCheckListMasterService;

        public GetMachineAndMaintenanceCheckListDetailQueryHandler(IMT_MachineAndMaintenanceCheckListMasterService _mT_MachineAndMaintenanceCheckListMasterService)
        {
            mT_MachineAndMaintenanceCheckListMasterService = _mT_MachineAndMaintenanceCheckListMasterService;
        }
        public async Task<List<MachineMaintenanceNotificationDetailRM>> Handle(GetMachineAndMaintenanceCheckListDetailQuery request, CancellationToken cancellationToken)
        {
            return await mT_MachineAndMaintenanceCheckListMasterService.GetMachineAndMaintenanceCheckListDetail(request.MasterID, cancellationToken);
        }
    }
}
