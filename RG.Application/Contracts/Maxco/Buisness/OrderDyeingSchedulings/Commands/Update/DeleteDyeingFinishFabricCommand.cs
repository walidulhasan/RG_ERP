using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderDyeingSchedulings.Commands.Update
{
    public class DeleteDyeingFinishFabricCommand:IRequest<RResult>
    {
        public int DyeingId { get; set; }
    }
    public class DeleteDyeingFinishFabricCommandHandler : IRequestHandler<DeleteDyeingFinishFabricCommand, RResult>
    {
        private readonly IOrderDyeingSchedulingService _orderDyeingSchedulingService;

        public DeleteDyeingFinishFabricCommandHandler(IOrderDyeingSchedulingService orderDyeingSchedulingService)
        {
            _orderDyeingSchedulingService = orderDyeingSchedulingService;
        }
        public async Task<RResult> Handle(DeleteDyeingFinishFabricCommand request, CancellationToken cancellationToken)
        {
            return await _orderDyeingSchedulingService.DeleteDyeingFinishFabric(request.DyeingId,true);
        }
    }
}
