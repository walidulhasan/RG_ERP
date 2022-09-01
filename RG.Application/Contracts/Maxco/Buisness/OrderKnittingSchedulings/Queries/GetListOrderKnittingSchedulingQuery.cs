using MediatR;
using RG.Application.Contracts.Maxco.OrderKnittingSchedulings.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.OrderKnittingSchedulings.Queries
{
    public class GetListOrderKnittingSchedulingQuery:IRequest<List<OrderKnittingSchedulingRM>>
    {
        public int krsid { get; set; }
        public int fabid { get; set; }
    }
    public class GetListOrderKnittingSchedulingQueryHandler : IRequestHandler<GetListOrderKnittingSchedulingQuery, List<OrderKnittingSchedulingRM>>
    {
        private readonly IOrderKnittingSchedulingService _orderKnittingSchedulingService;

        public GetListOrderKnittingSchedulingQueryHandler(IOrderKnittingSchedulingService orderKnittingSchedulingService)
        {
            _orderKnittingSchedulingService = orderKnittingSchedulingService;
        }
        public async Task<List<OrderKnittingSchedulingRM>> Handle(GetListOrderKnittingSchedulingQuery request, CancellationToken cancellationToken)
        {
            return await _orderKnittingSchedulingService.GetListOrderKnittingScheduling(request.krsid,request.fabid,cancellationToken);
        }
    }
}
