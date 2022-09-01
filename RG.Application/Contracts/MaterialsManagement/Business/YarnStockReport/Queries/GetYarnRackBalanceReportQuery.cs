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
    public class GetYarnRackBalanceReportQuery:IRequest<List<YarnRackBalanceReportRM>>
    {
        public string LotNo { get; set; }
        public int BuildingID { get; set; }
        public int FloorID { get; set; }
        public int RackID { get; set; }
        public int CompositionID { get; set; }
        public string Count { get; set; }
        public int OrderBy { get; set; }

    }
    public class GetYarnRackBalanceReportQueryHandler : IRequestHandler<GetYarnRackBalanceReportQuery, List<YarnRackBalanceReportRM>>
    {
        private readonly IYarnstockReportService _yarnstockReportService;

        public GetYarnRackBalanceReportQueryHandler(IYarnstockReportService yarnstockReportService)
        {
            _yarnstockReportService = yarnstockReportService;
        }
        public async Task<List<YarnRackBalanceReportRM>> Handle(GetYarnRackBalanceReportQuery request, CancellationToken cancellationToken)
        {
            return await _yarnstockReportService.GetYarnRackBalanceReport(request.LotNo, request.BuildingID, request.FloorID, request.RackID,request.CompositionID,request.Count,request.OrderBy);
        }
    }
}
