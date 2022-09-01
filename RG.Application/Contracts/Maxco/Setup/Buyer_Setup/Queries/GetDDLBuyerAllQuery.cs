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
   public class GetDDLBuyerAllQuery:IRequest<List<SelectListItem>>
    {
        public DateTime OrderLimit { get; set; } = DateTime.Now.AddYears(-2);
    }
    public class GetDDLBuyerAllQueryHandler : IRequestHandler<GetDDLBuyerAllQuery, List<SelectListItem>>
    {
        private readonly IBuyer_SetupService _buyer_SetupService;

        public GetDDLBuyerAllQueryHandler(IBuyer_SetupService buyer_SetupService)
        {
            _buyer_SetupService = buyer_SetupService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLBuyerAllQuery request, CancellationToken cancellationToken)
        {
            return await _buyer_SetupService.DDLBuyerAllQuery(request.OrderLimit, cancellationToken);
        }
    }
}
