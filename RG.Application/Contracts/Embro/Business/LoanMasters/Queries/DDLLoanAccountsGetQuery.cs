using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.Embro.Business;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Business.LoanMasters.Queries
{
    public class DDLLoanAccountsGetQuery : IRequest<List<SelectListItem>>
    {
        public int BankID { get; set; }
        public int LoanTypeID { get; set; }
        public string Predict { get; set; }
    }
    public class DDLLoanAccountsGetQueryHandler : IRequestHandler<DDLLoanAccountsGetQuery, List<SelectListItem>>
    {
        private readonly ILoanMasterService _loanMasterService;

        public DDLLoanAccountsGetQueryHandler(ILoanMasterService loanMasterService)
        {
            _loanMasterService = loanMasterService;
        }
        public async Task<List<SelectListItem>> Handle(DDLLoanAccountsGetQuery request, CancellationToken cancellationToken)
        {
            return await _loanMasterService.DDLLoanAccounts(request.BankID,request.LoanTypeID,request.Predict, cancellationToken);
        }
    }
}
