using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.OrderKnittingSchedulings.Commands.Update
{
    public class DeleteOrderKnittingSchedulingCommand:IRequest<RResult>
    {
        public int id { get; set; }
    }
    public class DeleteOrderKnittingSchedulingCommandHandler : IRequestHandler<DeleteOrderKnittingSchedulingCommand, RResult>
    {
        private readonly IOrderKnittingSchedulingService _orderKnittingSchedulingService;

        public DeleteOrderKnittingSchedulingCommandHandler(IOrderKnittingSchedulingService orderKnittingSchedulingService)
        {
            _orderKnittingSchedulingService = orderKnittingSchedulingService;
        }
        public async Task<RResult> Handle(DeleteOrderKnittingSchedulingCommand request, CancellationToken cancellationToken)
        {
            return await _orderKnittingSchedulingService.DeleteOrderKnittingScheduling(request.id,true);
        }
    }
}
