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
    public class GetLCMaturityRealizeQuery:IRequest<List<LCMaturityRealizeRM>>
    {
        public int FilterTypeId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int CompanyId { get; set; } = 0;
        public int FundTypeID { get; set; } = 0;
    }
    public class GetLCMaturityRealizeQueryHandler : IRequestHandler<GetLCMaturityRealizeQuery, List<LCMaturityRealizeRM>>
    {
        private readonly IExportDocumentsService _exportDocumentsService;

        public GetLCMaturityRealizeQueryHandler(IExportDocumentsService exportDocumentsService)
        {
            _exportDocumentsService = exportDocumentsService;
        }
        public async Task<List<LCMaturityRealizeRM>> Handle(GetLCMaturityRealizeQuery request, CancellationToken cancellationToken)
        {
            return await _exportDocumentsService.GetLCMaturityRealize(request.FilterTypeId, request.DateFrom, request.DateTo, request.Month, request.Year, request.CompanyId, request.FundTypeID);
        }
    }
}
