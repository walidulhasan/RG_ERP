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
    public class GetGatePassReceivableListQuery : IRequest<List<GatepassRM>>
    {
        public GatepassQM ReqModel { get; set; }
    }
    public class GetGatePassReceivableListQueryHandler : IRequestHandler<GetGatePassReceivableListQuery, List<GatepassRM>>
    {
        private readonly IIC_GatepassMasterService iC_GatepassMasterService;

        public GetGatePassReceivableListQueryHandler(IIC_GatepassMasterService _iC_GatepassMasterService)
        {
            iC_GatepassMasterService = _iC_GatepassMasterService;
        }
        public async Task<List<GatepassRM>> Handle(GetGatePassReceivableListQuery request, CancellationToken cancellationToken)
        {
            return await iC_GatepassMasterService.GetGatePassReceivableList(request.ReqModel, cancellationToken);
        }
    }
}
