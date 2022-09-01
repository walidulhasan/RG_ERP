using MediatR;
using RG.Application.Contracts.Maxco.Buisness.OrderReports.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderReports.Queries
{
    public class GetShipmentOrderInfoQuery:IRequest<List<ShipmentOrderInfoRM>>
    {
        public int OrderID { get; set; }
        public int OrderQty { get; set; }
    }
    public class GetShipmentOrderInfoQueryHandler : IRequestHandler<GetShipmentOrderInfoQuery, List<ShipmentOrderInfoRM>>
    {
        private readonly IOrderReportsService _orderReportsService;

        public GetShipmentOrderInfoQueryHandler(IOrderReportsService orderReportsService)
        {
            _orderReportsService = orderReportsService;
        }
        public async Task<List<ShipmentOrderInfoRM>> Handle(GetShipmentOrderInfoQuery request, CancellationToken cancellationToken)
        {
            return await _orderReportsService.GetShipmentOrderInfo(request.OrderID, cancellationToken);
        }
    }
}
