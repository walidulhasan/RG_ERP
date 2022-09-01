using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.Embro.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.LoanTypes.Commands.Update
{
    public class LoanTypeRemoveCommand:IRequest<RResult>
    {
        public int id { get; set; }
    }
    public class LoanTypeRemoveCommandHandler : IRequestHandler<LoanTypeRemoveCommand, RResult>
    {
        private readonly ILoanTypeService _loanTypeService;

        public LoanTypeRemoveCommandHandler(ILoanTypeService loanTypeService)
        {
            _loanTypeService = loanTypeService;
        }
        public async Task<RResult> Handle(LoanTypeRemoveCommand request, CancellationToken cancellationToken)
        {
            return await _loanTypeService.Remove(request.id, true);
        }
    }
}
