using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.Embro.Business;
using RG.Application.ViewModel.Embro.Business.LoanMasters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Business.LoanMasters.Commands.Update
{
    public class LoanMasterUpdateCommand:IRequest<RResult>
    {
        public LoanMasterCreateVM Model { get; set; }
    }
    public class LoanMasterUpdateCommandHandler : IRequestHandler<LoanMasterUpdateCommand, RResult>
    {
        private readonly ILoanMasterService _loanMasterService;

        public LoanMasterUpdateCommandHandler(ILoanMasterService loanMasterService)
        {
            _loanMasterService = loanMasterService;
        }
        public async Task<RResult> Handle(LoanMasterUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _loanMasterService.LoanMasterUpdate(request.Model, cancellationToken);
        }
    }
}
