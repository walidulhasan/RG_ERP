using MediatR;
using RG.Application.Contracts.MaterialsManagement.Business.YarnStockReport.RequestResponseModel;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.YarnStockReport.Queries
{
    public class YarnStockSummaryWithRackQuery : IRequest<List<YarnStockReportRM>>
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int WithAllTransaction { get; set; } = 1;
        public int ShowEmptyClosing { get; set; } = 0;
    }

    public class YarnStockSummaryWithRackQueryHandler : IRequestHandler<YarnStockSummaryWithRackQuery, List<YarnStockReportRM>>
    {
        private readonly IYarnstockReportService _yarnstockReportService;

        public YarnStockSummaryWithRackQueryHandler(IYarnstockReportService yarnstockReportService)
        {
            _yarnstockReportService = yarnstockReportService;
        }
        public async Task<List<YarnStockReportRM>> Handle(YarnStockSummaryWithRackQuery request, CancellationToken cancellationToken)
        {
            return await _yarnstockReportService.GetYarnStockWithRack(request.DateFrom,request.DateTo,request.WithAllTransaction,request.ShowEmptyClosing);
        }
    }
}
