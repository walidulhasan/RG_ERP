using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.AlgoHR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Tbl_EmpLeavess.Commands.Create
{
    public class EmpLeaveCreateCommandValidator:AbstractValidator<EmpLeaveCreateCommand>
    {
        private readonly IAlgoHRDBContext dbCon;

        public EmpLeaveCreateCommandValidator(IAlgoHRDBContext _dbCon)
        {
            dbCon = _dbCon;
            RuleFor(x => x.EmpLeave.Leave_Emp)
                .NotEmpty().WithMessage("Employee is required");
            RuleFor(x => x.EmpLeave.Leave_EmpCD)
                .NotEmpty().WithMessage("Employee is required");
            RuleFor(x => x.EmpLeave.Leave_ID)
                .NotEmpty().WithMessage("Leave type is required");
            RuleFor(v => v.EmpLeave.Leave_From)
                .NotEmpty().WithMessage("Leave from date is required")                
                .MustAsync(CheckLeaveDates).WithMessage("Leave already found in leave from date.");
            RuleFor(v => v.EmpLeave.Leave_To)
                .NotEmpty().WithMessage("Leave to date is required")
                .MustAsync(CheckLeaveDates).WithMessage("Leave already found in leave to date.");
        }

        public async Task<bool> CheckLeaveDates(EmpLeaveCreateCommand model, DateTime checkDate, CancellationToken cancellationToken)
        {
            var res= !await dbCon.Tbl_EmpLeaves.Where(x=>x.Leave_Emp==model.EmpLeave.Leave_Emp && x.Leave_Approved!=false)
                .AnyAsync(l => l.Leave_From.Value.Date <= checkDate.Date && l.Leave_To.Value.Date>=checkDate.Date);
            return res;
        }

    }
}
