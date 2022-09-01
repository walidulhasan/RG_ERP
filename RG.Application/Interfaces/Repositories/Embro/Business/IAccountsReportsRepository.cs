using RG.Application.Contracts.Embro.AccountsReports.NoteSummary.Queries.QueryResponseModel;
using RG.Application.Contracts.Embro.AccountsReports.TrialBalance.Queries.QueryResponseModel;
using RG.Application.Contracts.Embro.AccountsReports.Vouchers.Queries.QueryResponseModel;
using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Embro.Business
{
    public interface IAccountsReportsRepository:IGenericRepository<BasicCOA>
    {
        Task<List<TrialBalanceReportRM>> GetTrialBalanceReportData(int CompanyID, int BusinessID, int SelectLevel, int SelectByCostCenter,
            int SelectWithDetail, int ReportGroup, int VoucherPosted, DateTime DateFrom, DateTime DateTo, int IsExcludeZeroBalance);

        Task<List<TrialBalanceNoteRM>> GetTrailNotesStatement(int CompanyID, int BusinessID, int SelectLevel, int SelectByCostCenter,
    int SelectWithDetail, int ReportGroup, int VoucherPosted, DateTime DateFrom, DateTime DateTo, int IsExcludeZeroBalance, int NoteGroupID);
        Task<List<NoteSummaryWithPreviousRM>> BalanceSheetNoteSummaryWithPrevious(int CompanyID, int BusinessID, DateTime DateFrom, DateTime DateTo,
            int WithDetail,int Status,int WithClosingBalance,int NoteGroupID);
        Task<List<VoucherShortInfoRM>> GetVoucherShortInfo(int accountID, DateTime dateFrom, DateTime dateTo, bool needConversion=false, CancellationToken cancellationToken=default);
        Task<List<VoucherShortInfoTBRM>> GetVoucherShortInfoTB(int accountID, DateTime dateFrom, DateTime dateTo, bool needConversion, CancellationToken cancellationToken);
    }
}
