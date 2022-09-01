using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.Embro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.LoanTypes.Commands.Update
{
    public class LoanTypeUpdateCommandValidator : AbstractValidator<LoanTypeUpdateCommand>
    {
        private readonly IEmbroDBContext _dbcon;

        public LoanTypeUpdateCommandValidator(IEmbroDBContext dbcon)
        {
            _dbcon = dbcon;
            RuleFor(b => b.model.LoanTypeName).MustAsync(BeUniqueLoanTypeNmae).WithMessage("Loan Type Must be Unique");
        }
        private async Task<bool> BeUniqueLoanTypeNmae(LoanTypeUpdateCommand models, string LoanTypeName, CancellationToken cancellationToken)
        {
            var result = !await _dbcon.LoanType
                .Where(l => l.IsRemoved == false && l.IsActive == true)
                .AnyAsync(l => l.LoanTypeName == LoanTypeName, cancellationToken);

            return result;

        }
    }
}
