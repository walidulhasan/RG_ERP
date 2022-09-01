using RG.Application.Contracts.Embro.AccountsReports.GeneralLedgers.Queries.QueryResponseModel;
using RG.Application.Interfaces.Repositories.Embro.Business;
using RG.Infrastructure.Persistence.EmbroDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Embro.Business
{
    public class GeneralLedgeReportRepository : IGeneralLedgeReportRepository
    {
        private readonly EmbroDBContext _dbCon;
        public GeneralLedgeReportRepository(EmbroDBContext dbcon)
        {
            _dbCon = dbcon;
        }
        public async Task<List<GeneralLedgerDetailReportRM>> GeneralLedgerDetailReport(DateTime FromDate, DateTime ToDate, int AccountID, int CompanyID)
        {
            List<GeneralLedgerDetailReportRM> requisitionList = new();
            try
            {
                var inputXML= $"<Report><Account FromDate='{FromDate}' ToDate='{ToDate}' AccountID={AccountID} CompanyID='{CompanyID}'></Account></Report>";

                await _dbCon.LoadStoredProc("USP_GeneralLedgerDetailReport")
                                  .WithSqlParam("inputXML", inputXML) 
                                  .ExecuteStoredProcAsync((handler) =>
                                  {
                                      requisitionList = handler.ReadToList<GeneralLedgerDetailReportRM>() as List<GeneralLedgerDetailReportRM>;
                                  });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return requisitionList;
        }
    }
}
