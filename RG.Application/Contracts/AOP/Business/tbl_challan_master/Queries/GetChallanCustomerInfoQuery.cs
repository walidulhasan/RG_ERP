using MediatR;
using RG.Application.Contracts.AOP.Business.tbl_challan_master.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.AOP.Business;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AOP.Business.tbl_challan_master.Queries
{
    public class GetChallanCustomerInfoQuery : IRequest<ChallanCustomerInfoRM>
    {
        public long CustomerID { get; set; }
    }
    public class GetChallanCustomerInfoQueryHandler : IRequestHandler<GetChallanCustomerInfoQuery, ChallanCustomerInfoRM>
    {
        private readonly Itbl_challan_masterService _tbl_Challan_MasterService;

        public GetChallanCustomerInfoQueryHandler(Itbl_challan_masterService tbl_Challan_MasterService)
        {
            _tbl_Challan_MasterService = tbl_Challan_MasterService;
        }
        public async Task<ChallanCustomerInfoRM> Handle(GetChallanCustomerInfoQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_Challan_MasterService.GetChallanCustomerInfo(request.CustomerID, cancellationToken);
        }
    }
}
