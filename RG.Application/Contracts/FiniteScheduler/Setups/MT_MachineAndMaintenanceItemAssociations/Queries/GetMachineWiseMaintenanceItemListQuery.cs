using MediatR;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MachineAndMaintenanceItemAssociations.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.MT_MachineAndMaintenanceItemAssociations.Queries
{
    public class GetMachineWiseMaintenanceItemListQuery:IRequest<List<MachineWiseMaintenanceItemResponseModel>>
    {
        public int MachineID { get; set; }
    }
    public class GetMachineWiseMaintenanceItemListQueryHandler : IRequestHandler<GetMachineWiseMaintenanceItemListQuery, List<MachineWiseMaintenanceItemResponseModel>>
    {
        private readonly IMT_MachineAndMaintenanceItemAssociationService mT_MachineAndMaintenanceItemAssociationService;

        public GetMachineWiseMaintenanceItemListQueryHandler(IMT_MachineAndMaintenanceItemAssociationService _mT_MachineAndMaintenanceItemAssociationService)
        {
            mT_MachineAndMaintenanceItemAssociationService = _mT_MachineAndMaintenanceItemAssociationService;
        }
        public async Task<List<MachineWiseMaintenanceItemResponseModel>> Handle(GetMachineWiseMaintenanceItemListQuery request, CancellationToken cancellationToken)
        {
            return await mT_MachineAndMaintenanceItemAssociationService.GetMachineWiseMaintenanceItemList(request.MachineID, cancellationToken);
        }
    }
}
