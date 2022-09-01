using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.Embro.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Business.LoanMasters.Commands.Update
{
    public class LoanMasterRemoveCommand:IRequest<RResult>
    {
        public int loanID { get; set; }
    }
    public class LoanMasterRemoveCommandHandlear : IRequestHandler<LoanMasterRemoveCommand, RResult>
    {
        private readonly ILoanMasterService _loanMasterService;

        public LoanMasterRemoveCommandHandlear(ILoanMasterService loanMasterService)
        {
            _loanMasterService = loanMasterService;
        }
        public async Task<RResult> Handle(LoanMasterRemoveCommand request, CancellationToken cancellationToken)
        {
            return await _loanMasterService.RemoveLoanMaster(request.loanID,true);
        }
    }
}
