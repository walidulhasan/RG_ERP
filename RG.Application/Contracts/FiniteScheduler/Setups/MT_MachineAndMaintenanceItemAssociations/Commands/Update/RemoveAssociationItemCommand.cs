using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MachineAndMaintenanceItemAssociations.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.MT_MachineAndMaintenanceItemAssociations.Commands.Update
{
    public class RemoveAssociationItemCommand : IRequest<RResult>
    {
        public List<UpdateAssociationDTM> removeModel { get; set; }
    }

    public class RemoveAssociationItemCommandHandler : IRequestHandler<RemoveAssociationItemCommand, RResult>
    {
        private readonly IMT_MachineAndMaintenanceItemAssociationService _MachineAndMaintenanceItemAssociationService;
        public RemoveAssociationItemCommandHandler(IMT_MachineAndMaintenanceItemAssociationService MachineAndMaintenanceItemAssociationService)
        {
            _MachineAndMaintenanceItemAssociationService = MachineAndMaintenanceItemAssociationService;
        }
        public async Task<RResult> Handle(RemoveAssociationItemCommand request, CancellationToken cancellationToken)
        {
            return await _MachineAndMaintenanceItemAssociationService.RemoveMachineMaintainceAssociation(request.removeModel);
        }
    }
}
