using MediatR;
using RG.Application.Contracts.Embro.AccountsReports.Vouchers.Queries.QueryResponseModel;
using RG.Application.Interfaces.Services.Embro.Business;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.AccountsReports.Vouchers.Queries
{
    public class GetVoucherShortInfoQuery : IRequest<List<VoucherShortInfoRM>>
    {
        public int AccountID { get; set; }
        public DateTime DateFrom{ get; set; }
        public DateTime DateTo { get; set; }
        public bool NeedConversion { get; set; } = false;
    }
    public class GetVoucherShortInfoQueryHandler : IRequestHandler<GetVoucherShortInfoQuery, List<VoucherShortInfoRM>>
    {
        private readonly IAccountsReportsService _accountsReportsService;

        public GetVoucherShortInfoQueryHandler(IAccountsReportsService accountsReportsService)
        {
            _accountsReportsService = accountsReportsService;
        }
        public async Task<List<VoucherShortInfoRM>> Handle(GetVoucherShortInfoQuery request, CancellationToken cancellationToken)
        {
            return await _accountsReportsService.GetVoucherShortInfo(request.AccountID,request.DateFrom,request.DateTo,request.NeedConversion, cancellationToken);
        }
    }
}
