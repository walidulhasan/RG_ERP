using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.CMBL_PurchaseOrders.Queries
{
    public class GetDDLPOQuery:IRequest<List<SelectListItem>>
    {
        public int CompanyID { get; set; }
        public string Predict { get; set; }
    }
    public class GetDDLPOQueryHandler : IRequestHandler<GetDDLPOQuery, List<SelectListItem>>
    {
        private readonly ICMBL_PurchaseOrderService _cmbl_PurchaseOrderService;

        public GetDDLPOQueryHandler(ICMBL_PurchaseOrderService cmbl_PurchaseOrderService)
        {
            _cmbl_PurchaseOrderService = cmbl_PurchaseOrderService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLPOQuery request, CancellationToken cancellationToken)
        {
            return await _cmbl_PurchaseOrderService.GetDDLPO(request.CompanyID, request.Predict, cancellationToken);
        }
    }
}
