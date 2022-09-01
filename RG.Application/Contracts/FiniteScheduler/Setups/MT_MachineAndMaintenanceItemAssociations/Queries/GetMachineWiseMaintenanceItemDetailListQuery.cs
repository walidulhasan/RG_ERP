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
    public class GetMachineWiseMaintenanceItemDetailListQuery:IRequest<List<MachineWiseMaintenanceItemDetailResponseModel>>
    {
        public int MachineID { get; set; }
        public int MasterID { get; set; }
    }
    public class GetMachineWiseMaintenanceItemDetailListQueryHandler : IRequestHandler<GetMachineWiseMaintenanceItemDetailListQuery, List<MachineWiseMaintenanceItemDetailResponseModel>>    
    {
        private readonly IMT_MachineAndMaintenanceItemAssociationService mT_MachineAndMaintenanceItemAssociationService;

        public GetMachineWiseMaintenanceItemDetailListQueryHandler(IMT_MachineAndMaintenanceItemAssociationService _mT_MachineAndMaintenanceItemAssociationService)
        {
            mT_MachineAndMaintenanceItemAssociationService = _mT_MachineAndMaintenanceItemAssociationService;
        }
        public async Task<List<MachineWiseMaintenanceItemDetailResponseModel>> Handle(GetMachineWiseMaintenanceItemDetailListQuery request, CancellationToken cancellationToken)
        {
            return await mT_MachineAndMaintenanceItemAssociationService.GetMachineWiseMaintenanceItemDetailList(request.MachineID,request.MasterID, cancellationToken);
        }
    }
}
