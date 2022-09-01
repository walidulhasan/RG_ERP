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
    public class GetMachineAndMaintenanceCheckListMasterQuery:IRequest<MachineAndMaintenanceCheckMasterRM>
    {
        public int ID { get; set; }
    }
    public class GetMachineAndMaintenanceCheckListMasterQueryHandler : IRequestHandler<GetMachineAndMaintenanceCheckListMasterQuery, MachineAndMaintenanceCheckMasterRM>
    {
        private readonly IMT_MachineAndMaintenanceCheckListMasterService mT_MachineAndMaintenanceCheckListMasterService;

        public GetMachineAndMaintenanceCheckListMasterQueryHandler(IMT_MachineAndMaintenanceCheckListMasterService _mT_MachineAndMaintenanceCheckListMasterService)
        {
            mT_MachineAndMaintenanceCheckListMasterService = _mT_MachineAndMaintenanceCheckListMasterService;
        }
        public async Task<MachineAndMaintenanceCheckMasterRM> Handle(GetMachineAndMaintenanceCheckListMasterQuery request, CancellationToken cancellationToken)
        {
            return await mT_MachineAndMaintenanceCheckListMasterService.GetMachineAndMaintenanceCheckListMasterData(request.ID, cancellationToken);
        }
    }
}
