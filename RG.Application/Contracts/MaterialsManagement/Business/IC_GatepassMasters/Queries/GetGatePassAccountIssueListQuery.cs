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
    public class GetGatePassAccountIssueListQuery : IRequest<List<GatePassAccountIssueRM>>
    {
        public GatePassAccountIssueQM ReqModel { get; set; }
        

    }
    public class GetGatePassAccountIssueListQueryResponse : IRequestHandler<GetGatePassAccountIssueListQuery, List<GatePassAccountIssueRM>>
    {
        private readonly IIC_GatepassMasterService iC_GatepassMasterService;
        public GetGatePassAccountIssueListQueryResponse(IIC_GatepassMasterService _iC_GatepassMasterService)
        {
            iC_GatepassMasterService = _iC_GatepassMasterService;
        }
        public async Task<List<GatePassAccountIssueRM>> Handle(GetGatePassAccountIssueListQuery request, CancellationToken cancellationToken)
        {
            return await iC_GatepassMasterService.GetGatePassAccountIssueList(request.ReqModel, cancellationToken);
        }        
    }
}
