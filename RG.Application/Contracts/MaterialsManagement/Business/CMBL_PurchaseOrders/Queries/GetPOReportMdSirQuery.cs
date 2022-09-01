using MediatR;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using RG.Application.ViewModel.MDSir.CMBLPurchaseOrder;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.CMBL_PurchaseOrders.Queries
{
    public class GetPOReportMdSirQuery : IRequest<POReportVM>
    {
        public long POID { get; set; }
    }
    public class GetPOReportMdSirQueryHandler : IRequestHandler<GetPOReportMdSirQuery, POReportVM>
    {
        private readonly ICMBL_PurchaseOrderService _cmbl_PurchaseOrderService;

        public GetPOReportMdSirQueryHandler(ICMBL_PurchaseOrderService cmbl_PurchaseOrderService)
        {
            _cmbl_PurchaseOrderService = cmbl_PurchaseOrderService;
        }
        public async Task<POReportVM> Handle(GetPOReportMdSirQuery request, CancellationToken cancellationToken)
        {
            return await _cmbl_PurchaseOrderService.GetPOReportMdSir(request.POID, cancellationToken);
        }
    }
}

