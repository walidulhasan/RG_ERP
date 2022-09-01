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
    public class GetExportDocumentRealizationDataQuery:IRequest<List<ExportDocumentRealizationRM>>
    {
        public int IsDetailsReport { get; set; }
        public int FDBPP_ID { get; set; }
    }
    public class GetExportDocumentRealizationDataQueryHandler : IRequestHandler<GetExportDocumentRealizationDataQuery, List<ExportDocumentRealizationRM>>
    {
        private readonly IExportDocumentsService _exportDocumentsService;

        public GetExportDocumentRealizationDataQueryHandler(IExportDocumentsService exportDocumentsService)
        {
            _exportDocumentsService = exportDocumentsService;
        }
        public async Task<List<ExportDocumentRealizationRM>> Handle(GetExportDocumentRealizationDataQuery request, CancellationToken cancellationToken)
        {
            return await _exportDocumentsService.GetExportDocumentRealizationData(request.IsDetailsReport, request.FDBPP_ID);
        }
    }
}
