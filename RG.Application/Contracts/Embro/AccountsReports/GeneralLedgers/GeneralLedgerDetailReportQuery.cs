using MediatR;
using RG.Application.Contracts.Embro.AccountsReports.GeneralLedgers.Queries.QueryResponseModel;
using RG.Application.Interfaces.Services.Embro.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.AccountsReports.GeneralLedgers
{
    public class GeneralLedgerDetailReportQuery : IRequest<List<GeneralLedgerDetailReportRM>>
    {
             public DateTime FromDate {get;set;}
             public DateTime ToDate   {get;set;}
             public int AccountID     {get;set;}
             public int CompanyID { get; set; }
     }
    internal class GeneralLedgerDetailReportQueryHandler : IRequestHandler<GeneralLedgerDetailReportQuery, List<GeneralLedgerDetailReportRM>>
    {
        private readonly IGeneralLedgeReportService _generalLedgeReportService;

        public GeneralLedgerDetailReportQueryHandler(IGeneralLedgeReportService generalLedgeReportService)
        {
            _generalLedgeReportService = generalLedgeReportService;
        }
        public async Task<List<GeneralLedgerDetailReportRM>> Handle(GeneralLedgerDetailReportQuery request, CancellationToken cancellationToken)
        {
            return await _generalLedgeReportService.GeneralLedgerDetailReport(request.FromDate,request.ToDate,request.AccountID,request.CompanyID);
        }
    }
}
