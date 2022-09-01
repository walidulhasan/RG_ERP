using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderCuttingSchedulings.Commands.Update
{
    public class DeleteCuttingSchedulingCommand:IRequest<RResult>
    {
        public int id { get; set; }
    }
    public class DeleteCuttingSchedulingCommandHandler : IRequestHandler<DeleteCuttingSchedulingCommand, RResult>
    {
        private readonly IOrderCuttingSchedulingService _orderCuttingSchedulingService;

        public DeleteCuttingSchedulingCommandHandler(IOrderCuttingSchedulingService orderCuttingSchedulingService)
        {
            _orderCuttingSchedulingService = orderCuttingSchedulingService;
        }
        public async Task<RResult> Handle(DeleteCuttingSchedulingCommand request, CancellationToken cancellationToken)
        {
            return await _orderCuttingSchedulingService.DeleteCuttingScheduling(request.id,true);
        }
    }
}
