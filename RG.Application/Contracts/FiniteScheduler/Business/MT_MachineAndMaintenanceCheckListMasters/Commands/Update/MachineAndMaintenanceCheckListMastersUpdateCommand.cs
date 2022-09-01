using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Commands.Update
{
    public class MachineAndMaintenanceCheckListMastersUpdateCommand : IRequest<RResult>
    {
        public CheckListMasterDTM CheckListMaster { get; set; }
    }
    public class MachineAndMaintenanceCheckListMastersUpdateCommandHandler : IRequestHandler<MachineAndMaintenanceCheckListMastersUpdateCommand, RResult>
    {
        private readonly IMT_MachineAndMaintenanceCheckListMasterService mT_MachineAndMaintenanceCheckListMasterService;

        public MachineAndMaintenanceCheckListMastersUpdateCommandHandler(IMT_MachineAndMaintenanceCheckListMasterService _mT_MachineAndMaintenanceCheckListMasterService)
        {
            mT_MachineAndMaintenanceCheckListMasterService = _mT_MachineAndMaintenanceCheckListMasterService;
        }
        public async Task<RResult> Handle(MachineAndMaintenanceCheckListMastersUpdateCommand request, CancellationToken cancellationToken)
        {
            return await mT_MachineAndMaintenanceCheckListMasterService.MachineMaintenceCheckListUpdate(request.CheckListMaster, true);

        }        
    }
}
