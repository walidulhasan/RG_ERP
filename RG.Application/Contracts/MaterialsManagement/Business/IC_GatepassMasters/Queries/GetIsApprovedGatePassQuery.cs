using MediatR;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries
{
    public class GetIsApprovedGatePassQuery:IRequest<bool>
    {
        public long GatePassID { get; set; }
    }
    public class GetIsApprovedGatePassQueryHandler : IRequestHandler<GetIsApprovedGatePassQuery, bool>
    {
        private readonly IIC_GatepassMasterService _iC_GatepassMasterService;

        public GetIsApprovedGatePassQueryHandler(IIC_GatepassMasterService iC_GatepassMasterService)
        {
            _iC_GatepassMasterService = iC_GatepassMasterService;
        }
        public async Task<bool> Handle(GetIsApprovedGatePassQuery request, CancellationToken cancellationToken)
        {
            return await _iC_GatepassMasterService.IsApprovedGatePass(request.GatePassID, cancellationToken);
        }
    }
}
