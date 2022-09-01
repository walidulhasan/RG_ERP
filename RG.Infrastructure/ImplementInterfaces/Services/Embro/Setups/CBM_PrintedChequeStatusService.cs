using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.Embro.Setups.CBM_PrintedChequeStatuss.Queries.QueryResponseModel;
using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.Application.Interfaces.Services.Embro.Setups;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Embro.Setups
{
    public class CBM_PrintedChequeStatusService : ICBM_PrintedChequeStatusService
    {
        private readonly ICBM_PrintedChequeStatusRepository _cBM_PrintedChequeStatusRepository;

        public CBM_PrintedChequeStatusService(ICBM_PrintedChequeStatusRepository cBM_PrintedChequeStatusRepository)
        {
            _cBM_PrintedChequeStatusRepository = cBM_PrintedChequeStatusRepository;
        }
        public async Task<List<SelectListItem>> DDLPrintedChequeStatus(CancellationToken cancellationToken)
        {
            return await _cBM_PrintedChequeStatusRepository.DDLPrintedChequeStatus(cancellationToken);
        }
        public async Task<List<CBM_PrintedChequesRM>> GetCBM_PrintedCheques(int accountID, DateTime fromDate, DateTime toDate, int statusID, string paidTo)
        {
            return await _cBM_PrintedChequeStatusRepository.GetCBM_PrintedCheques(accountID, fromDate, toDate,statusID,paidTo);
        }


    }
}
