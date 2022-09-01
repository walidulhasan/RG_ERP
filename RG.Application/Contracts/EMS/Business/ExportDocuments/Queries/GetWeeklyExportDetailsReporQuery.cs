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
    public class GetWeeklyExportDetailsReporQuery:IRequest<List<WeeklyExportDetailsReportRM>>
    {
        public DateTime ExFactoryDateFrom { get; set; }
        public DateTime ExFactoryDateTo { get; set; }
        public int CompanyID { get; set; }
        public int BuyerID { get; set; }
        public int OrderID { get; set; }
        
        
    }
    public class GetWeeklyExportDetailsReporQueryHandler : IRequestHandler<GetWeeklyExportDetailsReporQuery, List<WeeklyExportDetailsReportRM>>
    {
        private readonly IExportDocumentsService _exportDocumentsService;

        public GetWeeklyExportDetailsReporQueryHandler(IExportDocumentsService exportDocumentsService)
        {
            _exportDocumentsService = exportDocumentsService;
        }
        public async Task<List<WeeklyExportDetailsReportRM>> Handle(GetWeeklyExportDetailsReporQuery request, CancellationToken cancellationToken)
        {
            return await _exportDocumentsService.GetWeeklyExportDetailsReportData(request.ExFactoryDateFrom,request.ExFactoryDateTo, request.CompanyID, request.BuyerID, request.OrderID);
        }
    }
}
