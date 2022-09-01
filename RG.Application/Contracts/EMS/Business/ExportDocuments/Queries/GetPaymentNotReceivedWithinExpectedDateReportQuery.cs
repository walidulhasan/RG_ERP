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
    public class GetPaymentNotReceivedWithinExpectedDateReportQuery : IRequest<List<WeeklyExportDetailsReportRM>>
    {
        public DateTime ExFactoryDateTo { get; set; }
    }
    public class GetPaymentNotReceivedWithinExpectedDateReportQueryHandler : IRequestHandler<GetPaymentNotReceivedWithinExpectedDateReportQuery, List<WeeklyExportDetailsReportRM>>
    {
        private readonly IExportDocumentsService _exportDocumentsService;

        public GetPaymentNotReceivedWithinExpectedDateReportQueryHandler(IExportDocumentsService exportDocumentsService)
        {
            _exportDocumentsService = exportDocumentsService;
        }
        public async Task<List<WeeklyExportDetailsReportRM>> Handle(GetPaymentNotReceivedWithinExpectedDateReportQuery request, CancellationToken cancellationToken)
        {
            return await _exportDocumentsService.GetPaymentNotReceivedWithinExpectedDateReportData(request.ExFactoryDateTo);
        }
    }
}
