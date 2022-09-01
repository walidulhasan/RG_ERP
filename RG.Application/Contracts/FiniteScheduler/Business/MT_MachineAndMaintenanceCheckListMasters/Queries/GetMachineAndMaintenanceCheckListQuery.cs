using MediatR;
using RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Queries
{
    public class GetMachineAndMaintenanceCheckListQuery : IRequest<List<MachineAndMaintenanceCheckRM>>
    {
        public int? MachineID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
    public class GetMachineAndMaintenanceCheckListQueryHandler : IRequestHandler<GetMachineAndMaintenanceCheckListQuery, List<MachineAndMaintenanceCheckRM>>
    {
        private readonly IMT_MachineAndMaintenanceCheckListMasterService mT_MachineAndMaintenanceCheckListMasterService;

        public GetMachineAndMaintenanceCheckListQueryHandler(IMT_MachineAndMaintenanceCheckListMasterService _mT_MachineAndMaintenanceCheckListMasterService)
        {
            mT_MachineAndMaintenanceCheckListMasterService = _mT_MachineAndMaintenanceCheckListMasterService;
        }
        public async Task<List<MachineAndMaintenanceCheckRM>> Handle(GetMachineAndMaintenanceCheckListQuery request, CancellationToken cancellationToken)
        {
            return await mT_MachineAndMaintenanceCheckListMasterService.GetMachineAndMaintenanceCheckList(request.MachineID, request.DateFrom, request.DateTo, cancellationToken);
        }
    }
}
