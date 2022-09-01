using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.Embro.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.LoanTypes.Queries
{
    public class GetDDLLoanTypeNmaeQuery:IRequest<List<SelectListItem>>
    {
    }
    public class GetDDLLoanTypeNmaeQueryHandler : IRequestHandler<GetDDLLoanTypeNmaeQuery, List<SelectListItem>>
    {
        private readonly ILoanTypeService _loanTypeService;

        public GetDDLLoanTypeNmaeQueryHandler(ILoanTypeService loanTypeService)
        {
            _loanTypeService = loanTypeService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLLoanTypeNmaeQuery request, CancellationToken cancellationToken)
        {
            return await _loanTypeService.DDLLoanTypeName(cancellationToken);
        }
    }
}
