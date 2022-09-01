using MediatR;
using RG.Application.Contracts.Maxco.Buisness.OrderDyeingSchedulings.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderDyeingSchedulings.Queries
{
    public class GetListDyeingFinishFabricQuery : IRequest<List<OrderDyeingSchedulingRM>>
    {
        public int OrderID { get; set; }
        public int GSM { get; set; }
        public int FabricQualityID { get; set; }
        public string FabricComposition { get; set; }
        public string PantoneNo { get; set; }
        public decimal FinishedWidth { get; set; }
    }
    public class GetListDyeingFinishFabricQueryHandler : IRequestHandler<GetListDyeingFinishFabricQuery, List<OrderDyeingSchedulingRM>>
    {
        private readonly IOrderDyeingSchedulingService _orderDyeingSchedulingService;

        public GetListDyeingFinishFabricQueryHandler(IOrderDyeingSchedulingService orderDyeingSchedulingService)
        {
            _orderDyeingSchedulingService = orderDyeingSchedulingService;
        }
        public async Task<List<OrderDyeingSchedulingRM>> Handle(GetListDyeingFinishFabricQuery request, CancellationToken cancellationToken)
        {
            return await _orderDyeingSchedulingService.GetListDyeingFinishFabric(request.OrderID,request.GSM,request.FabricQualityID,request.FabricComposition,request.PantoneNo,request.FinishedWidth, cancellationToken);
        }
    }
}
