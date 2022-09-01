using MediatR;
using RG.Application.Contracts.EMS.Business.ExportDocuments.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.EMS.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.EMS.Business.ExportDocuments.Queries
{
    public class GetWeeklyShipmentStatusReportQuery:IRequest<List<WeeklyShipmentStatusRM>>
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Week { get; set; }
        
    }
    public class GetWeeklyShipmentStatusReportQueryHandler : IRequestHandler<GetWeeklyShipmentStatusReportQuery, List<WeeklyShipmentStatusRM>>
    {
        private readonly IExportDocumentsService _exportDocumentsService;

        public GetWeeklyShipmentStatusReportQueryHandler(IExportDocumentsService exportDocumentsService)
        {
            _exportDocumentsService = exportDocumentsService;
        }
        public async Task<List<WeeklyShipmentStatusRM>> Handle(GetWeeklyShipmentStatusReportQuery request, CancellationToken cancellationToken)
        {
            List<WeeklyShipmentStatusRM> data = await _exportDocumentsService.GetWeeklyShipmentStatusReportData(request.Year,request.Month,request.Week, cancellationToken);
            return data;
        }
    }
}
