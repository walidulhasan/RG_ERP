using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.ViewModel.MDSir.CMBLPurchaseOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.MaterialsManagement.Business
{
    public interface ICMBL_PurchaseOrderService
    {
        Task<POReportVM> GetPOReportMdSir(long POID, CancellationToken cancellationToken);
        Task<List<SelectListItem>> GetDDLPO(int companyID, string predict, CancellationToken cancellationToken);
    }
}
