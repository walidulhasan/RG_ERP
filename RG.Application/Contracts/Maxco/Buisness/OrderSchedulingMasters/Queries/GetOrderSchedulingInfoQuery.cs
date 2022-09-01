using MediatR;
using RG.Application.Interfaces.Services.Maxco.Business;
using RG.Application.ViewModel.Maxco.Business.OrderScheduling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderSchedulingMasters.Queries
{
    public class GetOrderSchedulingInfoQuery:IRequest<OrderSchedulingMasterVM>
    {
        public int id { get; set; }
    }
    public class GetOrderSchedulingInfoQueryHandler : IRequestHandler<GetOrderSchedulingInfoQuery, OrderSchedulingMasterVM>
    {
        private readonly IOrderSchedulingMasterService _orderSchedulingMasterService;

        public GetOrderSchedulingInfoQueryHandler(IOrderSchedulingMasterService orderSchedulingMasterService)
        {
            _orderSchedulingMasterService = orderSchedulingMasterService;
        }
        public async Task<OrderSchedulingMasterVM> Handle(GetOrderSchedulingInfoQuery request, CancellationToken cancellationToken)
        {
            return await _orderSchedulingMasterService.GetOrderSchedulingInfo(request.id,cancellationToken);
        }
    }
}
