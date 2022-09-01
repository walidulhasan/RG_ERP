using MediatR;
using RG.Application.Contracts.Maxco.Buisness.OrderCuttingSchedulings.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderCuttingSchedulings.Queries
{
    public class GetListOrderCuttingSchedulingQuery:IRequest<List<OrderCuttingSchedulingRM>>
    {
       public int OrderId { get; set; }
       public int GSM { get; set; }
       public int FabricQualityID { get; set; }
       public string FabricComposition { get; set; }
       public string PantoneNo { get; set; }
       public decimal FinishedWidth { get; set; }
    }
    public class GetListOrderCuttingSchedulingQueryHandler : IRequestHandler<GetListOrderCuttingSchedulingQuery, List<OrderCuttingSchedulingRM>>
    {
        private readonly IOrderCuttingSchedulingService _orderCuttingSchedulingService;

        public GetListOrderCuttingSchedulingQueryHandler(IOrderCuttingSchedulingService orderCuttingSchedulingService)
        {
            _orderCuttingSchedulingService = orderCuttingSchedulingService;
        }
        public async Task<List<OrderCuttingSchedulingRM>> Handle(GetListOrderCuttingSchedulingQuery request, CancellationToken cancellationToken)
        {
            return await _orderCuttingSchedulingService.GetListCuttingScheduling(request.OrderId, request.GSM, request.FabricQualityID, request.FabricComposition, request.PantoneNo, request.FinishedWidth, cancellationToken);
        }
    }
}
