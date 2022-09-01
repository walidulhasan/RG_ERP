using MediatR;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using RG.Application.ViewModel.MaterialsManagement.Business.GatePass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries
{
    public class GetGatePassChallanByGatePassIDQuery : IRequest<GatePassChallanMasterVM>
    {
        public int GatePassID { get; set; }
    }
    public class GetGatePassChallanByGatePassIDQueryHandler : IRequestHandler<GetGatePassChallanByGatePassIDQuery, GatePassChallanMasterVM>
    {
        private readonly IGatePassChallanService gatePassChallanService;

        public GetGatePassChallanByGatePassIDQueryHandler(IGatePassChallanService _gatePassChallanService)
        {
            gatePassChallanService = _gatePassChallanService;
        }
        public async Task<GatePassChallanMasterVM> Handle(GetGatePassChallanByGatePassIDQuery request, CancellationToken cancellationToken)
        {
            return await gatePassChallanService.GetGatePassChallanRecord(request.GatePassID, cancellationToken);
        }
    }
}
