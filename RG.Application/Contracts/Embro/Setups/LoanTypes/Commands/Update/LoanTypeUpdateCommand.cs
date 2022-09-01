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

namespace RG.Application.Contracts.Embro.Setups.LoanTypes.Commands.Update
{
    public class LoanTypeUpdateCommand:IRequest<RResult>
    {
        public LoanTypeCreateVM model { get; set; }
    }
    public class LoanTypeUpdateCommandHandler : IRequestHandler<LoanTypeUpdateCommand, RResult>
    {
        private readonly ILoanTypeService _loanTypeService;

        public LoanTypeUpdateCommandHandler(ILoanTypeService loanTypeService)
        {
            _loanTypeService = loanTypeService;
        }
        public async Task<RResult> Handle(LoanTypeUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _loanTypeService.SaveAndUpdate(request.model);
        }
    }
}
