using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.MT_MachineAndMaintenanceItemAssociations.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.MT_MachineAndMaintenanceItemAssociations.Commands.Create
{
    public class MachineAndMaintenanceItemAssociationCreateCommand : IRequest<RResult>
    {
        public List<AssociationDTM> Association { get; set; }
    }
    public class MachineAndMaintenanceItemAssociationCreateCommandHandler : IRequestHandler<MachineAndMaintenanceItemAssociationCreateCommand, RResult>
    {

        private readonly IMT_MachineAndMaintenanceItemAssociationService mt_MachineAndMaintenanceItemAssociationService;

        public MachineAndMaintenanceItemAssociationCreateCommandHandler(IMT_MachineAndMaintenanceItemAssociationService _mt_MachineAndMaintenanceItemAssociationService)
        {
            mt_MachineAndMaintenanceItemAssociationService = _mt_MachineAndMaintenanceItemAssociationService;
        }

        public async Task<RResult> Handle(MachineAndMaintenanceItemAssociationCreateCommand request, CancellationToken cancellationToken)
        {
            return await mt_MachineAndMaintenanceItemAssociationService.SaveMachineAndMaintenanceItemAssociation(request.Association, true);
        }
    }
}
