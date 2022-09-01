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
    public class CBM_BankService : ICBM_BankService
    {
        private readonly ICBM_BankRepository _cBM_BankRepository;

        public CBM_BankService(ICBM_BankRepository cBM_BankRepository)
        {
            _cBM_BankRepository = cBM_BankRepository;
        }
        public async Task<List<SelectListItem>> DDLCBM_Bank(int CompanyID=0,string predict=null, CancellationToken cancellationToken=default)
        {
            return await _cBM_BankRepository.DDLCBM_Bank(CompanyID,predict, cancellationToken);
        }
    }
}
