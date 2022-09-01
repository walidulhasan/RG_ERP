using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Contracts.Embro.Setups.CBM_PrintedChequeStatuss.Queries.QueryResponseModel;
using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.DBEntities.Embro.Setup;
using RG.Infrastructure.Persistence.EmbroDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Embro.Setups
{
    public class CBM_PrintedChequeStatusRepository : GenericRepository<CBM_PrintedChequeStatus>, ICBM_PrintedChequeStatusRepository
    {
        private readonly EmbroDBContext _dbCon;

        public CBM_PrintedChequeStatusRepository(EmbroDBContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }

        public async Task<List<SelectListItem>> DDLPrintedChequeStatus(CancellationToken cancellationToken)
        {
            var data = await _dbCon.CBM_PrintedChequeStatus
                 .Select(x => new SelectListItem { Text = x.StatusName.Trim(), Value = x.StatusID.ToString() }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<CBM_PrintedChequesRM>> GetCBM_PrintedCheques(int accountID, DateTime fromDate, DateTime toDate, int statusID, string paidTo)
        {
            List<CBM_PrintedChequesRM> cheques = new();
            try
            {
                await _dbCon.LoadStoredProc("ajt.Usp_GetCBM_PrintedCheques")
                    .WithSqlParam("AccountID", accountID)
                    .WithSqlParam("FromDate", fromDate)
                    .WithSqlParam("ToDate", toDate)
                    .WithSqlParam("StatusID", statusID)
                    .WithSqlParam("PaidTo", paidTo)
                                  .ExecuteStoredProcAsync((handler) =>
                                  {
                                      cheques = handler.ReadToList<CBM_PrintedChequesRM>() as List<CBM_PrintedChequesRM>;                                      
                                  });

                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return cheques;
        }
    }
}
