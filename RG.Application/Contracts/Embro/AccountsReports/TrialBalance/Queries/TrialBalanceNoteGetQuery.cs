using MediatR;
using RG.Application.Contracts.Embro.AccountsReports.TrialBalance.Queries.QueryResponseModel;
using RG.Application.Interfaces.Services.Embro.Business;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.AccountsReports.TrialBalance.Queries
{
    public class TrialBalanceNoteGetQuery : IRequest<List<TrialBalanceNoteRM>>
    {
        //int CompanyID, int BusinessID, int SelectLevel, int SelectByCostCenter, int SelectWithDetail, int ReportGroup, int VoucherPosted, DateTime DateFrom, DateTime DateTo, int IsExcludeZeroBalance
        public int CompanyID { get; set; }
        public int BusinessID { get; set; }
        public int SelectLevel { get; set; }
        public int SelectByCostCenter { get; set; }
        public int SelectWithDetail { get; set; }
        public int ReportGroup { get; set; }
        public int VoucherPosted { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int IsExcludeZeroBalance { get; set; }
        public int NoteGroupID { get; set; } = 1;
    }
    public class TrialBalanceNoteGetQueryHandler : IRequestHandler<TrialBalanceNoteGetQuery, List<TrialBalanceNoteRM>>
    {
        private readonly IAccountsReportsService _accountsReportsService;

        public TrialBalanceNoteGetQueryHandler(IAccountsReportsService accountsReportsService)
        {
            _accountsReportsService = accountsReportsService;
        }
        public async Task<List<TrialBalanceNoteRM>> Handle(TrialBalanceNoteGetQuery request, CancellationToken cancellationToken)
        {
            return await _accountsReportsService.GetTrailNotesStatement(request.CompanyID, request.BusinessID, request.SelectLevel, request.SelectByCostCenter
                , request.SelectWithDetail, request.ReportGroup, request.VoucherPosted, request.DateFrom, request.DateTo, request.IsExcludeZeroBalance,request.NoteGroupID);
        }
    }
}
