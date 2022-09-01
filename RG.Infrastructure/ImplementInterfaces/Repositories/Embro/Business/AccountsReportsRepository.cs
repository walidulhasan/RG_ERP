using RG.Application.Contracts.Embro.AccountsReports.NoteSummary.Queries.QueryResponseModel;
using RG.Application.Contracts.Embro.AccountsReports.TrialBalance.Queries.QueryResponseModel;
using RG.Application.Contracts.Embro.AccountsReports.Vouchers.Queries.QueryResponseModel;
using RG.Application.Interfaces.Repositories.Embro.Business;
using RG.DBEntities.Embro.Setup;
using RG.Infrastructure.Persistence.EmbroDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Embro.Business
{
    public class AccountsReportsRepository : GenericRepository<BasicCOA>, IAccountsReportsRepository
    {
        private readonly EmbroDBContext _dbCon;

        public AccountsReportsRepository(EmbroDBContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }

        public async Task<List<NoteSummaryWithPreviousRM>> BalanceSheetNoteSummaryWithPrevious(int CompanyID, int BusinessID, DateTime DateFrom, DateTime DateTo, int WithDetail, int Status, int WithClosingBalance, int NoteGroupID)
        {
            List<NoteSummaryWithPreviousRM> data = new();
            try
            {
                await _dbCon.LoadStoredProc("rpt.usp_BalanceSheet_NoteSummaryWithPrevious", commandTimeout: 500)

                                  .WithSqlParam("CompID", CompanyID)
                                  .WithSqlParam("BusinessID", BusinessID)
                                  .WithSqlParam("DateFrom", DateFrom.ToString("dd-MMM-yyyy"))
                                  .WithSqlParam("DateTo", DateTo.ToString("dd-MMM-yyyy"))
                                  .WithSqlParam("WithDetail", WithDetail)
                                  .WithSqlParam("Status", Status)
                                  .WithSqlParam("WithClosingBalance", WithClosingBalance)
                                  .WithSqlParam("NoteGroupID", NoteGroupID)
                                  .ExecuteStoredProcAsync((handler) =>
                                  {
                                      data = handler.ReadToList<NoteSummaryWithPreviousRM>() as List<NoteSummaryWithPreviousRM>;
                                  });

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return data;
        }

        public async Task<List<TrialBalanceNoteRM>> GetTrailNotesStatement(int CompanyID, int BusinessID, int SelectLevel, int SelectByCostCenter, int SelectWithDetail, int ReportGroup, int VoucherPosted, DateTime DateFrom, DateTime DateTo, int IsExcludeZeroBalance, int NoteGroupID)
        {
            List<TrialBalanceNoteRM> trailData = new();
            try
            {
                await _dbCon.LoadStoredProc("rpt.Usp_TrailNotesStatement", commandTimeout: 500)
                                  .WithSqlParam("SelectLevel", SelectLevel)
                                  .WithSqlParam("CompID", CompanyID)
                                  .WithSqlParam("BusinessID", BusinessID)
                                  .WithSqlParam("DateFrom", DateFrom.ToString("dd-MMM-yyyy"))
                                  .WithSqlParam("DateTo", DateTo.ToString("dd-MMM-yyyy"))
                                  .WithSqlParam("WithDetail", SelectWithDetail)
                                  .WithSqlParam("Status", VoucherPosted)
                                  .WithSqlParam("WithClosingBalance", IsExcludeZeroBalance)
                                  .WithSqlParam("NoteGroupID", NoteGroupID)
                                  .ExecuteStoredProcAsync((handler) =>
                                  {
                                      trailData = handler.ReadToList<TrialBalanceNoteRM>() as List<TrialBalanceNoteRM>;
                                  });

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return trailData;
        }

        public async Task<List<TrialBalanceReportRM>> GetTrialBalanceReportData(int CompanyID, int BusinessID, int SelectLevel, int SelectByCostCenter, int SelectWithDetail, int ReportGroup, int VoucherPosted, DateTime DateFrom, DateTime DateTo, int IsExcludeZeroBalance)
        {
            List<TrialBalanceReportRM> requisitionList = new();
            try
            {
                await _dbCon.LoadStoredProc("usp_Report_Trial_Activity", commandTimeout: 500)
                                  .WithSqlParam("SelectLevel", SelectLevel)
                                  .WithSqlParam("CompID", CompanyID)
                                  .WithSqlParam("BusinessID", BusinessID)
                                  .WithSqlParam("DateFrom", DateFrom.ToString("dd-MMM-yyyy"))
                                  .WithSqlParam("DateTo", DateTo.ToString("dd-MMM-yyyy"))
                                  .WithSqlParam("WithDetail", SelectWithDetail)
                                  .WithSqlParam("Status", VoucherPosted)
                                  .WithSqlParam("WithClosingBalance", IsExcludeZeroBalance)
                                  .ExecuteStoredProcAsync((handler) =>
                                  {
                                      requisitionList = handler.ReadToList<TrialBalanceReportRM>() as List<TrialBalanceReportRM>;
                                  });
                /*
                List<int> comptexAccHead = new();
                comptexAccHead.Add(20001);
                comptexAccHead.Add(20002);
                comptexAccHead.Add(20005);

                List<int> robintexAccHead = new();
                robintexAccHead.Add(1);
                robintexAccHead.Add(2);
                robintexAccHead.Add(4);

                if (CompanyID == 183)
                {
                    requisitionList = requisitionList.Where(x => !comptexAccHead.Contains((int)x.CID)).ToList();
                }
                else
                {
                    requisitionList = requisitionList.Where(x => !robintexAccHead.Contains((int)x.CID)).ToList();
                }
                */
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return requisitionList;
        }

        public async Task<List<VoucherShortInfoRM>> GetVoucherShortInfo(int accountID, DateTime dateFrom, DateTime dateTo, bool needConversion = false, CancellationToken cancellationToken = default)
        {

            List<string> approvedStatus = new() { "1", "5", "10", "15" };

            var data = await (from v in _dbCon.viw_Voucher
                              join cos in _dbCon.BasicCOA on v.Costcenter.Value equals cos.ID
                              join act in _dbCon.BasicCOA on v.Activity.Value equals act.ID
                              join loc in _dbCon.BasicCOA on v.LocationID.Value equals loc.ID
                              join com in _dbCon.CompanyInfo on v.CompanyId equals (int)com.CompanyID
                              join curr in _dbCon.tbl_Currency_Setup on v.CurrencyID equals curr.ID
                              where approvedStatus.Contains(v.Status) && v.AccountID == accountID
                              && v.VDate <= dateTo
                              select new VoucherShortInfoRM
                              {
                                  VoucherId = v.VoucherId,
                                  VoucherNumber = v.VoucherNumber,
                                  VDate = v.VDate,
                                  AccountId = v.AccountID,
                                  AccountName = v.AccountName.Trim(),
                                  Amount = v.Amount,
                                  VoucherDescription = v.VoucherDescription.Trim(),
                                  Costcenter = v.Costcenter.Value,
                                  CostcenterName = cos.DESCRIPTION.Trim(),
                                  LocationId = v.LocationID.Value,
                                  LocationName = loc.DESCRIPTION.Trim(),
                                  Activity = v.Activity.Value,
                                  ActivityName = act.DESCRIPTION.Trim(),
                                  CompanyId = v.CompanyId,
                                  CompanyName = com.Companyname.Trim(),
                                  Status = approvedStatus.Contains(v.Status) ? "Approved" : "Processing",
                                  Currency = curr.ShortName,
                                  CRate = v.CRate.Value,
                                  NeedConversion = needConversion
                              }).OrderBy(x => x.VDate).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<VoucherShortInfoTBRM>> GetVoucherShortInfoTB(int accountID, DateTime dateFrom, DateTime dateTo, bool needConversion, CancellationToken cancellationToken)
        {

            var FiscalYear = 0;
            if (dateFrom.Month > 6)
            {
                FiscalYear = dateFrom.Year;
            }
            else
            {
                FiscalYear = dateFrom.Year - 1;
            }
            var fiscalDateFrom = new DateTime(FiscalYear, 7, 1);
            //var fiscalDateTo = new DateTime(FiscalYear+1, 6, 30);

            List<string> approvedStatus = new() { "1", "5", "10", "15" };
            List<VoucherShortInfoTBRM> returnData = new();

            var opening = await (from o in _dbCon.OpeningBalances
                                 join coa in _dbCon.BasicCOA on o.AccountID equals coa.ID
                                 where o.AccountID == accountID && o.FiscalYear == FiscalYear
                                 select new VoucherShortInfoTBRM
                                 {
                                     //VoucherId = v.VoucherId,
                                     //VoucherNumber = v.VoucherNumber,
                                     //VDate = v.VDate,
                                     //AccountId = v.AccountID,
                                     AccountName = coa.DESCRIPTION.Trim(),
                                     Amount = o.OpeningBalance,
                                     //VoucherDescription = v.VoucherDescription.Trim(),
                                     //Costcenter = v.Costcenter.Value,
                                     //CostcenterName = cos.DESCRIPTION.Trim(),
                                     //LocationId = v.LocationID.Value,
                                     //LocationName = loc.DESCRIPTION.Trim(),
                                     //Activity = v.Activity.Value,
                                     //ActivityName = act.DESCRIPTION.Trim(),
                                     //CompanyId = v.CompanyId,
                                     //CompanyName = com.Companyname.Trim(),
                                     //Status = approvedStatus.Contains(v.Status) ? "Approved" : "Processing",
                                     //Currency = curr.ShortName,
                                     //CRate = v.CRate.Value,
                                     NeedConversion = needConversion
                                 }).FirstOrDefaultAsync(cancellationToken);




            var data = await (from v in _dbCon.viw_Voucher
                              join cos in _dbCon.BasicCOA on v.Costcenter.Value equals cos.ID
                              join act in _dbCon.BasicCOA on v.Activity.Value equals act.ID
                              join loc in _dbCon.BasicCOA on v.LocationID.Value equals loc.ID
                              join com in _dbCon.CompanyInfo on v.CompanyId equals (int)com.CompanyID
                              join curr in _dbCon.tbl_Currency_Setup on v.CurrencyID equals curr.ID
                              where approvedStatus.Contains(v.Status) && v.AccountID == accountID && v.VDate >= fiscalDateFrom && v.VDate <= dateTo
                              select new VoucherShortInfoTBRM
                              {
                                  VoucherId = v.VoucherId,
                                  VoucherNumber = v.VoucherNumber,
                                  VDate = v.VDate,
                                  AccountId = v.AccountID,
                                  AccountName = v.AccountName.Trim(),
                                  Amount = v.Amount,
                                  VoucherDescription = v.VoucherDescription.Trim(),
                                  Costcenter = v.Costcenter.Value,
                                  CostcenterName = cos.DESCRIPTION.Trim(),
                                  LocationId = v.LocationID.Value,
                                  LocationName = loc.DESCRIPTION.Trim(),
                                  Activity = v.Activity.Value,
                                  ActivityName = act.DESCRIPTION.Trim(),
                                  CompanyId = v.CompanyId,
                                  CompanyName = com.Companyname.Trim(),
                                  Status = approvedStatus.Contains(v.Status) ? "Approved" : "Processing",
                                  Currency = curr.ShortName,
                                  CRate = v.CRate.Value,
                                  NeedConversion = needConversion
                              }).OrderBy(x => x.VDate).ThenBy(x => x.VoucherId).ToListAsync(cancellationToken);
            if (opening != null)
            {
                returnData.Add(opening);
            }

            returnData.AddRange(data);
            return returnData;
        }
    }
}
