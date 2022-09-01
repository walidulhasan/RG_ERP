using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.Buisness.OrderSchedulingMasters.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderSchedulingMasters.Commands.Create
{
    public class OrderSchedulingCreateMasterCommand:IRequest<RResult>
    {
        public OrderSchedulingMastersDTM OrderSchedulingMasters { get; set; }
    }
    public class OrderSchedulingCreateMasterCommandHandler : IRequestHandler<OrderSchedulingCreateMasterCommand, RResult>
    {
        private readonly IOrderSchedulingMasterService _orderSchedulingMasterService;

        public OrderSchedulingCreateMasterCommandHandler(IOrderSchedulingMasterService orderSchedulingMasterService)
        {
            _orderSchedulingMasterService = orderSchedulingMasterService;
        }
        public async Task<RResult> Handle(OrderSchedulingCreateMasterCommand request, CancellationToken cancellationToken)
        {
            return await _orderSchedulingMasterService.Create(request.OrderSchedulingMasters,true);
        }
    }
}
