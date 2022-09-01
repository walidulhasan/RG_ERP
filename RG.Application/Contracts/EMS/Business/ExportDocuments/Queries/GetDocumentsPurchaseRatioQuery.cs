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
    public class GetDocumentsPurchaseRatioQuery:IRequest<List<DocumentsPurchaseRatioRM>>
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public bool WithPurchaseRatio { get; set; }
    }
    public class GetDocumentsPurchaseRatioQueryHandler : IRequestHandler<GetDocumentsPurchaseRatioQuery, List<DocumentsPurchaseRatioRM>>
    {
        private readonly IExportDocumentsService _exportDocumentsService;

        public GetDocumentsPurchaseRatioQueryHandler(IExportDocumentsService exportDocumentsService)
        {
            _exportDocumentsService = exportDocumentsService;
        }
        public async Task<List<DocumentsPurchaseRatioRM>> Handle(GetDocumentsPurchaseRatioQuery request, CancellationToken cancellationToken)
        {
            return await _exportDocumentsService.GetDocumentsPurchaseRatio(request.DateFrom, request.DateTo, request.WithPurchaseRatio, cancellationToken);
        }
    }
}
