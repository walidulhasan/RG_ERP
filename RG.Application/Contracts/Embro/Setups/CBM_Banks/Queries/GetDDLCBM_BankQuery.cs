using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.Embro.Setups;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.CBM_Banks.Queries
{
    public class GetDDLCBM_BankQuery : IRequest<List<SelectListItem>>
    {
        public int CompanyID { get; set; } = 0;
        public string Predict { get; set; }
    }
    public class GetDDLCBM_BankQueryHandler : IRequestHandler<GetDDLCBM_BankQuery, List<SelectListItem>>
    {
        private readonly ICBM_BankService _cBM_BankService;

        public GetDDLCBM_BankQueryHandler(ICBM_BankService cBM_BankService)
        {
            _cBM_BankService = cBM_BankService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLCBM_BankQuery request, CancellationToken cancellationToken)
        {
            return await _cBM_BankService.DDLCBM_Bank(request.CompanyID, request.Predict, cancellationToken);
        }
    }
}
