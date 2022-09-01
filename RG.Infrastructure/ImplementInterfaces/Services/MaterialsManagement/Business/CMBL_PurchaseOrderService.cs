using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using RG.Application.ViewModel.MDSir.CMBLPurchaseOrder;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Business
{
    public class CMBL_PurchaseOrderService : ICMBL_PurchaseOrderService
    {
        private readonly ICMBL_PurchaseOrderRepository _cmbl_PurchaseOrderRepository;

        public CMBL_PurchaseOrderService(ICMBL_PurchaseOrderRepository cmbl_PurchaseOrderRepository)
        {
            _cmbl_PurchaseOrderRepository = cmbl_PurchaseOrderRepository;
        }

        public async Task<List<SelectListItem>> GetDDLPO(int companyID, string predict, CancellationToken cancellationToken)
        {
            return await _cmbl_PurchaseOrderRepository.GetDDLPO(companyID, predict, cancellationToken);
        }

        public async Task<POReportVM> GetPOReportMdSir(long POID, CancellationToken cancellationToken)
        {
            return await _cmbl_PurchaseOrderRepository.GetPOReportMdSir(POID, cancellationToken);
        }
    }
}
