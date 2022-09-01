using MediatR;
using RG.Application.Contracts.Maxco.Buisness.OrderSchedulingMasters.Queries.RequestResponseModel;
using RG.Application.Contracts.Maxco.Buisness.OrderSewingSchedulings.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderSewingSchedulings.Queries
{
    public class GetListSewingSchedulingQuery:IRequest<List<OrderSewingSchedulingRM>>
    {
        public int OrderId { get; set; }
        public int GSM { get; set; }
        public int FabricQualityID { get; set; }
        public string FabricComposition { get; set; }
        public string PantoneNo { get; set; }
        public decimal FinishedWidth { get; set; }
    }
    public class GetListSewingSchedulingQueryHandler : IRequestHandler<GetListSewingSchedulingQuery, List<OrderSewingSchedulingRM>>
    {
        private readonly IOrderSewingSchedulingService _orderSewingSchedulingService;

        public GetListSewingSchedulingQueryHandler(IOrderSewingSchedulingService orderSewingSchedulingService)
        {
            _orderSewingSchedulingService = orderSewingSchedulingService;
        }
        public async Task<List<OrderSewingSchedulingRM>> Handle(GetListSewingSchedulingQuery request, CancellationToken cancellationToken)
        {
            return await _orderSewingSchedulingService.GetListSewingScheduling(request.OrderId,request.GSM,request.FabricQualityID,request.FabricComposition,request.PantoneNo,request.FinishedWidth,cancellationToken);
        }
    }
}
