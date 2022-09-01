using RG.Application.Contracts.Embro.AccountsReports.GeneralLedgers.Queries.QueryResponseModel;
using RG.Application.Interfaces.Repositories.Embro.Business;
using RG.Application.Interfaces.Services.Embro.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Embro.Business
{
    public class GeneralLedgeReportService : IGeneralLedgeReportService
    {
        private readonly IGeneralLedgeReportRepository _generalLedgeReportRepository;

        public GeneralLedgeReportService(IGeneralLedgeReportRepository generalLedgeReportRepository)
        {
            _generalLedgeReportRepository = generalLedgeReportRepository;
        }
        public async Task<List<GeneralLedgerDetailReportRM>> GeneralLedgerDetailReport(DateTime FromDate, DateTime ToDate, int AccountID, int CompanyID)
        {
            return await _generalLedgeReportRepository.GeneralLedgerDetailReport(FromDate, ToDate, AccountID, CompanyID);
        }
    }
}
