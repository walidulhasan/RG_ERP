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
    public class DDLGetOrderListQuery : IRequest<List<SelectListItem>>
    {
        public int BuyerID { get; set; }
        public DateTime OrderConditionDate { get; set; }
        public string Predict { get; set; } = null;
    }
    public class DDLGetOrderListQueryHandler : IRequestHandler<DDLGetOrderListQuery, List<SelectListItem>>
    {
        private readonly IStyleService styleService;

        public DDLGetOrderListQueryHandler(IStyleService _styleService)
        {
            styleService = _styleService;
        }
        public async Task<List<SelectListItem>> Handle(DDLGetOrderListQuery request, CancellationToken cancellationToken)
        {
            return await styleService.DDLGetOrderNo(request.BuyerID, request.OrderConditionDate, request.Predict, cancellationToken);
        }
    }
}
