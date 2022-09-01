using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderSewingSchedulings.Commands.Update
{
    public class DeleteSewingSchedulingCommand:IRequest<RResult>
    {
        public int id { get; set; }
    }
    public class DeleteSewingSchedulingCommandHandler : IRequestHandler<DeleteSewingSchedulingCommand, RResult>
    {
        private readonly IOrderSewingSchedulingService _orderSewingSchedulingService;

        public DeleteSewingSchedulingCommandHandler(IOrderSewingSchedulingService orderSewingSchedulingService)
        {
            _orderSewingSchedulingService = orderSewingSchedulingService;
        }
        public async Task<RResult> Handle(DeleteSewingSchedulingCommand request, CancellationToken cancellationToken)
        {
            return await _orderSewingSchedulingService.DeleteSewingScheduling(request.id,true);
        }
    }
}
