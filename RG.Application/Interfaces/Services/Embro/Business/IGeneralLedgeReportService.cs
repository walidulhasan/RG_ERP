using RG.Application.Contracts.Embro.AccountsReports.GeneralLedgers.Queries.QueryResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Embro.Business
{
    public interface IGeneralLedgeReportService
    {
        Task<List<GeneralLedgerDetailReportRM>> GeneralLedgerDetailReport(DateTime FromDate, DateTime ToDate, int AccountID, int CompanyID);
    }
}
