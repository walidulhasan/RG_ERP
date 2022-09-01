using AutoMapper;
using FluentValidation;
using RG.Application.Common.Mappings;
using RG.Application.Interfaces.Repositories.Embro.Setups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RG.DBEntities.Embro.Setup;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Repositories.Embro;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RG.Application.ViewModel.Embro.Setup.LoanType
{
    public class LoanTypeCreateVM : IMapFrom<DBEntities.Embro.Setup.LoanType>
    {
        public int ID { get; set; }

        [Display(Name = "Loan Type Name")]
        public string LoanTypeName { get; set; }
        [Display(Name = "Loan Type Short Name")]
        public string LoanTypeShortName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoanTypeCreateVM, DBEntities.Embro.Setup.LoanType>();
        }
    }

    public class LoanTypeValidate : AbstractValidator<LoanTypeCreateVM>
    {

        public LoanTypeValidate(IEmbroDBContext dbCon, ILoanTypeRepository loanTypeRepository)
        {
            RuleFor(b => b.LoanTypeName).NotEmpty().WithMessage("Loan Type Name Can't be Null");
        }
    }
}
