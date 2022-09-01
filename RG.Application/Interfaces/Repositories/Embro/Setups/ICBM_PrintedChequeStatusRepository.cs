using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.Embro.Setups.CBM_PrintedChequeStatuss.Queries.QueryResponseModel;
using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Embro.Setups
{
    public interface ICBM_PrintedChequeStatusRepository:IGenericRepository<CBM_PrintedChequeStatus>
    {
        Task<List<SelectListItem>> DDLPrintedChequeStatus(CancellationToken cancellationToken);
        Task<List<CBM_PrintedChequesRM>> GetCBM_PrintedCheques(int accountID, DateTime fromDate, DateTime toDate, int statusID, string paidTo);
    }
}
