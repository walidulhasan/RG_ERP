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
    public class GetOutstandingLCRealizationQuery : IRequest<List<LCMaturityRealizeRM>>
    {       
        public int Year { get; set; }
        public int CompanyId { get; set; } = 0;
        public int FundTypeID { get; set; } = 0;
    }
    public class GetOutstandingLCRealizationQueryHandler : IRequestHandler<GetOutstandingLCRealizationQuery, List<LCMaturityRealizeRM>>
    {
        private readonly IExportDocumentsService _exportDocumentsService;

        public GetOutstandingLCRealizationQueryHandler(IExportDocumentsService exportDocumentsService)
        {
            _exportDocumentsService = exportDocumentsService;
        }
        public async Task<List<LCMaturityRealizeRM>> Handle(GetOutstandingLCRealizationQuery request, CancellationToken cancellationToken)
        {
            return await _exportDocumentsService.GetOutstandingLCRealization(request.Year, request.CompanyId, request.FundTypeID);
        }
    }
}
