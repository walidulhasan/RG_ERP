using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Business;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Commands.Create
{
    public class MachineAndMaintenanceCheckListMastersCreateCommand : IRequest<RResult>
    {
        public CheckListMasterDTM CheckListMaster { get; set; }
    }
    public class MachineAndMaintenanceCheckListMastersCreateCommandHandler : IRequestHandler<MachineAndMaintenanceCheckListMastersCreateCommand, RResult>
    {
        private readonly IMT_MachineAndMaintenanceCheckListMasterService mT_MachineAndMaintenanceCheckListMasterService;

        public MachineAndMaintenanceCheckListMastersCreateCommandHandler(IMT_MachineAndMaintenanceCheckListMasterService _mT_MachineAndMaintenanceCheckListMasterService)
        {
            mT_MachineAndMaintenanceCheckListMasterService = _mT_MachineAndMaintenanceCheckListMasterService;
        }
        public async Task<RResult> Handle(MachineAndMaintenanceCheckListMastersCreateCommand request, CancellationToken cancellationToken)
        {
            return await mT_MachineAndMaintenanceCheckListMasterService.MachineMaintenceCheckListSave(request.CheckListMaster, true);

        }
    }
}
