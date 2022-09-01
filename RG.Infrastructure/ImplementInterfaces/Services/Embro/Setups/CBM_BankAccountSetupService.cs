using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.Application.Interfaces.Services.Embro.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Embro.Setups
{
    public class CBM_BankAccountSetupService : ICBM_BankAccountSetupService
    {
        private readonly ICBM_BankAccountSetupRepository _cBM_BankAccountSetupRepository;

        public CBM_BankAccountSetupService(ICBM_BankAccountSetupRepository cBM_BankAccountSetupRepository)
        {
            _cBM_BankAccountSetupRepository = cBM_BankAccountSetupRepository;
        }
        public async Task<List<SelectListItem>> DDLCBM_BankAccount(int bankID, string predict, CancellationToken cancellationToken)
        {
            return await _cBM_BankAccountSetupRepository.DDLCBM_BankAccount(bankID, predict, cancellationToken);
        }
    }
}
