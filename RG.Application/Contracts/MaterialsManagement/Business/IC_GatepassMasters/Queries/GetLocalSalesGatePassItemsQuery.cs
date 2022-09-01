using MediatR;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using RG.Application.ViewModel.MaterialsManagement.Business.GatePass;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries
{
    public class GetLocalSalesGatePassItemsQuery : IRequest<List<LocalSalesItemVM>>
    {
        public long GatePassID { get; set; }
    }
    public class GetLocalSalesGatePassItemsQueryHandler : IRequestHandler<GetLocalSalesGatePassItemsQuery, List<LocalSalesItemVM>>
    {
        private readonly IIC_GatepassMasterService _iIC_GatepassMasterService;

        public GetLocalSalesGatePassItemsQueryHandler(IIC_GatepassMasterService iIC_GatepassMasterService)
        {
            _iIC_GatepassMasterService = iIC_GatepassMasterService;
        }
        public async Task<List<LocalSalesItemVM>> Handle(GetLocalSalesGatePassItemsQuery request, CancellationToken cancellationToken)
        {
            return await _iIC_GatepassMasterService.GetLocalSalesItem(request.GatePassID, cancellationToken);
        }
    }
}
