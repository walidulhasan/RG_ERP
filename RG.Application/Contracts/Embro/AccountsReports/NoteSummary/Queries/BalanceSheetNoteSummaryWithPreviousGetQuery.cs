using MediatR;
using RG.Application.Contracts.Embro.AccountsReports.NoteSummary.Queries.QueryResponseModel;
using RG.Application.Interfaces.Services.Embro.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.AccountsReports.NoteSummary.Queries
{
    public class BalanceSheetNoteSummaryWithPreviousGetQuery : IRequest<List<NoteSummaryWithPreviousRM>>
    {
        public int CompanyID { get; set; }
        public int BusinessID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int WithDetail { get; set; }
        public int Status { get; set; }
        public int WithClosingBalance { get; set; }
        public int NoteGroupID { get; set; }

    }
    public class BalanceSheetNoteSummaryWithPreviousGetQueryHandler : IRequestHandler<BalanceSheetNoteSummaryWithPreviousGetQuery, List<NoteSummaryWithPreviousRM>>
    {
        private readonly IAccountsReportsService _accountsReportsService;

        public BalanceSheetNoteSummaryWithPreviousGetQueryHandler(IAccountsReportsService accountsReportsService)
        {
            _accountsReportsService = accountsReportsService;
        }
        public async Task<List<NoteSummaryWithPreviousRM>> Handle(BalanceSheetNoteSummaryWithPreviousGetQuery request, CancellationToken cancellationToken)
        {
            return await _accountsReportsService.BalanceSheetNoteSummaryWithPrevious(request.CompanyID, request.BusinessID, request.DateFrom, request.DateTo
                , request.WithDetail, request.Status, request.WithClosingBalance, request.NoteGroupID);
        }
    }
}
