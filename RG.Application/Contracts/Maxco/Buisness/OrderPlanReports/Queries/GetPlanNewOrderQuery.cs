using MediatR;
using RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries
{
   public class GetPlanNewOrderQuery :IRequest<List<PlanNewOrderRM>>
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int BuyerID { get; set; }
        public int OrderID { get; set; }
    }

    public class GetPlanNewOrderQueryHandler : IRequestHandler<GetPlanNewOrderQuery, List<PlanNewOrderRM>>
    {
        private readonly IOrderPlanReportsService _orderPlanReportsService;

        public GetPlanNewOrderQueryHandler(IOrderPlanReportsService orderPlanReportsService)
        {
            _orderPlanReportsService = orderPlanReportsService;
        }
        public async Task<List<PlanNewOrderRM>> Handle(GetPlanNewOrderQuery request, CancellationToken cancellationToken)
        {
            return await _orderPlanReportsService.PlanNewOrderReport(request.DateFrom, request.DateTo, request.BuyerID, request.OrderID, cancellationToken);
        }
    }
}
