using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.Embro.Setups.CBM_PrintedChequeStatuss.Queries.QueryResponseModel;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Embro.Setups
{
    public interface ICBM_PrintedChequeStatusService
    {
        Task<List<SelectListItem>> DDLPrintedChequeStatus(CancellationToken cancellationToken);
        Task<List<CBM_PrintedChequesRM>> GetCBM_PrintedCheques(int accountID, DateTime fromDate, DateTime toDate,int statusID,string paidTo);

    }
}
