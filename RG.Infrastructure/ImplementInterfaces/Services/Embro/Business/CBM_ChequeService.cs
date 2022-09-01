using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.Embro.Business;
using RG.Application.Interfaces.Services.Embro.Business;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Embro.Business
{
    public class CBM_ChequeService : ICBM_ChequeService
    {
        private readonly ICBM_ChequeRepository _cBM_ChequeRepository;

        public CBM_ChequeService(ICBM_ChequeRepository cBM_ChequeRepository)
        {
            _cBM_ChequeRepository = cBM_ChequeRepository;
        }
        public async Task<List<SelectListItem>> DDLSupplierWhomChequePaidTo(int accountID, DateTime fromDate, DateTime toDate, string predict, CancellationToken cancellationToken)
        {
            return await _cBM_ChequeRepository.DDLSupplierWhomChequePaidTo(accountID, fromDate, toDate, predict, cancellationToken);
        }
    }
}
