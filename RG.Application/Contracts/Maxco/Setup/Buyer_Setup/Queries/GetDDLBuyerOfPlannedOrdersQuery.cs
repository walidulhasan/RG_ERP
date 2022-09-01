using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Setup.Buyer_Setup.Queries
{
    public class GetDDLBuyerOfPlannedOrdersQuery : IRequest<List<SelectListItem>>
    {
    }
    public class GetDDLBuyerOfPlannedOrdersQueryHandler : IRequestHandler<GetDDLBuyerOfPlannedOrdersQuery, List<SelectListItem>>
    {
        private readonly IBuyer_SetupService buyer_SetupService;

        public GetDDLBuyerOfPlannedOrdersQueryHandler(IBuyer_SetupService _buyer_SetupService)
        {
            buyer_SetupService = _buyer_SetupService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLBuyerOfPlannedOrdersQuery request, CancellationToken cancellationToken)
        {
            return await buyer_SetupService.DDLBuyerOfPlannedOrders(cancellationToken);
        }
    }
}
