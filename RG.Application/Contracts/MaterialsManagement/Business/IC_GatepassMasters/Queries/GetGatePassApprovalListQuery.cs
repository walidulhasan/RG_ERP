using MediatR;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries
{
    public class GetGatePassApprovalListQuery : IRequest<List<GatepassRM>>
    {
        public GatepassQM ReqModel { get; set; }
    }
    public class GetGatePassApprovalListQueryHandler : IRequestHandler<GetGatePassApprovalListQuery, List<GatepassRM>>
    {
        private readonly IIC_GatepassMasterService iC_GatepassMasterService;
        public GetGatePassApprovalListQueryHandler(IIC_GatepassMasterService _iC_GatepassMasterService)
        {
            iC_GatepassMasterService = _iC_GatepassMasterService;
        }
        public async Task<List<GatepassRM>> Handle(GetGatePassApprovalListQuery request, CancellationToken cancellationToken)
        {
            return await iC_GatepassMasterService.GetGatePassApprovalList(request.ReqModel, cancellationToken);
        }
    }
}
