using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.Style.Queries
{
    public class GetDDLOrdersQuery:IRequest<List<SelectListItem>>
    {
        public DateTime? FromDate { get; set; }
        public int BuyerID { get; set; } = 0;
        public string Predict { get; set; }
    }
    internal class GetDDLOrdersQueryHandler : IRequestHandler<GetDDLOrdersQuery, List<SelectListItem>>
    {
        private readonly IStyleService styleService;

        public GetDDLOrdersQueryHandler(IStyleService _styleService)
        {
            styleService = _styleService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLOrdersQuery request, CancellationToken cancellationToken)
        {
            return await styleService.DDLOrders(request.FromDate,request.BuyerID,request.Predict, cancellationToken);
        }
    }
}
