using MediatR;
using RG.Application.Contracts.Embro.AccountsReports.Vouchers.Queries.QueryResponseModel;
using RG.Application.Interfaces.Services.Embro.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.AccountsReports.Vouchers.Queries
{
    public class GetVoucherShortInfoTBQuery:IRequest<List<VoucherShortInfoTBRM>>
    {
        public int AccountID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool NeedConversion { get; set; } = false;
    }
    public class GetVoucherShortInfoTBQueryHandler : IRequestHandler<GetVoucherShortInfoTBQuery, List<VoucherShortInfoTBRM>>
    {
        private readonly IAccountsReportsService _accountsReportsService;

        public GetVoucherShortInfoTBQueryHandler(IAccountsReportsService accountsReportsService)
        {
            _accountsReportsService = accountsReportsService;
        }
        public async Task<List<VoucherShortInfoTBRM>> Handle(GetVoucherShortInfoTBQuery request, CancellationToken cancellationToken)
        {
            return await _accountsReportsService.GetVoucherShortInfoTB(request.AccountID, request.DateFrom, request.DateTo, request.NeedConversion, cancellationToken);
        }
    }
}
