using MediatR;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries
{
    public class GetICGatepassMasterDetailInfoByIDQuery : IRequest<IC_GatepassMasterRM>
    {
        public long GatePassID { get; set; }
    }
    public class GetICGatepassMasterDetailInfoByIDQueryHandler : IRequestHandler<GetICGatepassMasterDetailInfoByIDQuery, IC_GatepassMasterRM>
    {
        private readonly IIC_GatepassMasterService iC_GatepassMasterService;
        public GetICGatepassMasterDetailInfoByIDQueryHandler(IIC_GatepassMasterService _iC_GatepassMasterService)
        {
            iC_GatepassMasterService = _iC_GatepassMasterService;
        }
        public async Task<IC_GatepassMasterRM> Handle(GetICGatepassMasterDetailInfoByIDQuery request, CancellationToken cancellationToken)
        {
            return await iC_GatepassMasterService.GetIC_GatepassMasterDetailInfoByID(request.GatePassID, cancellationToken);
        }
    }
}
