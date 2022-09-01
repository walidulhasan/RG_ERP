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
   public class GetReturnableGatePassQuery :IRequest<List<ReturnableItemVM>>
    {
        public long GatePassID { get; set; }
    }
    public class GetReturnableGatePassQueryHandler : IRequestHandler<GetReturnableGatePassQuery, List<ReturnableItemVM>>
    {
        private readonly IIC_GatepassMasterService _iIC_GatepassMasterService;

        public GetReturnableGatePassQueryHandler(IIC_GatepassMasterService iIC_GatepassMasterService)
        {
            _iIC_GatepassMasterService = iIC_GatepassMasterService;
        }
        public async Task<List<ReturnableItemVM>> Handle(GetReturnableGatePassQuery request, CancellationToken cancellationToken)
        {
            return await _iIC_GatepassMasterService.GetReturnableItem(request.GatePassID, cancellationToken);
        }
    }
}
