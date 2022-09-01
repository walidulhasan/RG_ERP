using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.Embro.Setups;
using RG.Application.ViewModel.Embro.Setup.LoanType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.LoanTypes.Commands.Create
{
    public class LoanTypeCreateCommand:IRequest<RResult>
    {
        public LoanTypeCreateVM loanType { get; set; }
    }
    public class LoanTypeUpdateCommandHandler : IRequestHandler<LoanTypeCreateCommand, RResult>
    {
        private readonly ILoanTypeService _loanTypeService;

        public LoanTypeUpdateCommandHandler(ILoanTypeService loanTypeService)
        {
            _loanTypeService = loanTypeService;
        }
        public async Task<RResult> Handle(LoanTypeCreateCommand request, CancellationToken cancellationToken)
        {
            return await _loanTypeService.SaveAndUpdate(request.loanType);
        }
    }
}
