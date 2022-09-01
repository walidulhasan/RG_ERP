using MediatR;
using RG.Application.Contracts.Embro.Business.LoanMasters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.Embro.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Business.LoanMasters.Queries
{
    public class LoanDetailsReportQuery : IRequest<BankLoanPositionRM>
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int CompanyID { get; set; } = 0;
        public int BankID { get; set; } = 0;
        public int LoanTypeID { get; set; } = 0;
        public int LoanAccID { get; set; } = 0;
        public int UserID { get; set; } = 0;
    }

    public class LoanDetailsReportQueryHandler : IRequestHandler<LoanDetailsReportQuery, BankLoanPositionRM>
    {
        private readonly ILoanMasterService _loanMasterService;
        public LoanDetailsReportQueryHandler(ILoanMasterService loanMasterService)
        {
            _loanMasterService = loanMasterService;
        }
        public async Task<BankLoanPositionRM> Handle(LoanDetailsReportQuery request, CancellationToken cancellationToken)
        {
            return await _loanMasterService.LoanDetailsReport(request.DateFrom, request.DateTo, request.CompanyID, request.BankID,request.LoanTypeID,request.LoanAccID,request.UserID);
        }
    }
}
