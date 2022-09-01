using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.Embro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.LoanTypes.Commands.Create
{
    public class LoanTypeCreateCommandValidator : AbstractValidator<LoanTypeCreateCommand>
    {
        private readonly IEmbroDBContext _dbCon;
        public LoanTypeCreateCommandValidator(IEmbroDBContext dbcon)
        {
            _dbCon = dbcon;

            RuleFor(b => b.loanType.LoanTypeName).NotEmpty().WithMessage("Loan Type Name Can't be Null")
            .MustAsync(BeUniqueLoanTypeNmae).WithMessage("Loan type must be unique.");

        }

        public async Task<bool> BeUniqueLoanTypeNmae(LoanTypeCreateCommand model, string LoanTypeName, CancellationToken cancellationToken)
        {
            if (model.loanType.ID > 0)
            {
                return await _dbCon.LoanType
                .Where(l =>l.IsRemoved==false && l.IsActive==true && (model.loanType.ID > 0 && l.ID != model.loanType.ID))
                .AllAsync(l => l.LoanTypeName == LoanTypeName, cancellationToken);
            }

            var result= !await _dbCon.LoanType
                .Where(b => b.IsRemoved == false && b.IsActive == true)
                .AnyAsync(l => l.LoanTypeName == LoanTypeName, cancellationToken);
            return result;

        }
    }
}
