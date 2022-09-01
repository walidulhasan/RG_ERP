using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.Embro.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.CBM_BankAccountSetups.Queries
{
    public class GetDDLCBM_BankAccountQuery:IRequest<List<SelectListItem>>
    {
        public int BankID { get; set; }
        public string Predict { get; set; }
    }
    public class DDLCBM_BankAccountHandler : IRequestHandler<GetDDLCBM_BankAccountQuery, List<SelectListItem>>
    {
        private readonly ICBM_BankAccountSetupService _cBM_BankAccountSetupService;

        public DDLCBM_BankAccountHandler(ICBM_BankAccountSetupService cBM_BankAccountSetupService)
        {
            _cBM_BankAccountSetupService = cBM_BankAccountSetupService;
        }

        public async Task<List<SelectListItem>> Handle(GetDDLCBM_BankAccountQuery request, CancellationToken cancellationToken)
        {
            return await _cBM_BankAccountSetupService.DDLCBM_BankAccount(request.BankID, request.Predict, cancellationToken);
        }
    }
}
