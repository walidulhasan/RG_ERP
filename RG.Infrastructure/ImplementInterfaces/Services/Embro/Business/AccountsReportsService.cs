using RG.Application.Contracts.Embro.AccountsReports.NoteSummary.Queries.QueryResponseModel;
using RG.Application.Contracts.Embro.AccountsReports.TrialBalance.Queries.QueryResponseModel;
using RG.Application.Contracts.Embro.AccountsReports.Vouchers.Queries.QueryResponseModel;
using RG.Application.Interfaces.Repositories.Embro.Business;
using RG.Application.Interfaces.Services.Embro.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Embro.Business
{
    public class AccountsReportsService : IAccountsReportsService
    {
        private readonly IAccountsReportsRepository _accountsReportsRepository;

        public AccountsReportsService(IAccountsReportsRepository accountsReportsRepository)
        {
            _accountsReportsRepository = accountsReportsRepository;
        }

        public async Task<List<NoteSummaryWithPreviousRM>> BalanceSheetNoteSummaryWithPrevious(int CompanyID, int BusinessID, DateTime DateFrom, DateTime DateTo, int WithDetail, int Status, int WithClosingBalance, int NoteGroupID)
        {
            return await _accountsReportsRepository.BalanceSheetNoteSummaryWithPrevious(CompanyID, BusinessID, DateFrom, DateTo, WithDetail, Status, WithClosingBalance, NoteGroupID);

        }

        public async Task<List<TrialBalanceNoteRM>> GetTrailNotesStatement(int CompanyID, int BusinessID, int SelectLevel, int SelectByCostCenter, int SelectWithDetail, int ReportGroup, int VoucherPosted, DateTime DateFrom, DateTime DateTo, int IsExcludeZeroBalance, int NoteGroupID)
        {
            return await _accountsReportsRepository.GetTrailNotesStatement(CompanyID, BusinessID, SelectLevel, SelectByCostCenter, SelectWithDetail, ReportGroup, VoucherPosted, DateFrom, DateTo, IsExcludeZeroBalance, NoteGroupID);
        }

        public async Task<List<TrialBalanceReportRM>> GetTrialBalanceReportData(int CompanyID, int BusinessID, int SelectLevel, int SelectByCostCenter, int SelectWithDetail, int ReportGroup, int VoucherPosted, DateTime DateFrom, DateTime DateTo, int IsExcludeZeroBalance)
        {
            var data = await _accountsReportsRepository.GetTrialBalanceReportData(CompanyID, BusinessID, SelectLevel, SelectByCostCenter, SelectWithDetail, ReportGroup, VoucherPosted, DateFrom, DateTo, IsExcludeZeroBalance);
            var returnData = new List<TrialBalanceReportRM>();
            switch (SelectLevel)
            {
                case 4:
                    {
                        returnData = data.GroupBy(x => new { x.CompanyName, x.CompanyAddress, x.CID, x.Category })
                            .Select(r => new TrialBalanceReportRM
                            {
                                CompanyName = r.Key.CompanyName,
                                CompanyAddress = r.Key.CompanyAddress,
                                CID = r.Key.CID,
                                Category = r.Key.Category,
                                OBDebit = r.Sum(x => x.OBDebit),
                                OBCredit = r.Sum(x => x.OBCredit),
                                Debit = r.Sum(x => x.Debit),
                                Credit = r.Sum(x => x.Credit)
                            }).ToList();
                        break;
                    }
                case 5:
                    {
                        returnData = data.GroupBy(x => new { x.CompanyName, x.CompanyAddress, x.CID, x.Category, x.SCID, x.SubCateogory })
                            .Select(r => new TrialBalanceReportRM
                            {
                                CompanyName = r.Key.CompanyName,
                                CompanyAddress = r.Key.CompanyAddress,
                                CID = r.Key.CID,
                                Category = r.Key.Category,
                                SCID = r.Key.SCID,
                                SubCateogory = r.Key.SubCateogory,
                                OBDebit = r.Sum(x => x.OBDebit),
                                OBCredit = r.Sum(x => x.OBCredit),
                                Debit = r.Sum(x => x.Debit),
                                Credit = r.Sum(x => x.Credit)
                            }).ToList();
                        break;
                    }
                case 6:
                    {
                        returnData = data.GroupBy(x => new { x.CompanyName, x.CompanyAddress, x.CID, x.Category, x.SCID, x.SubCateogory, x.BGID, x.BroadGroup })
                            .Select(r => new TrialBalanceReportRM
                            {
                                CompanyName = r.Key.CompanyName,
                                CompanyAddress = r.Key.CompanyAddress,
                                CID = r.Key.CID,
                                Category = r.Key.Category,
                                SCID = r.Key.SCID,
                                SubCateogory = r.Key.SubCateogory,
                                BGID = r.Key.BGID,
                                BroadGroup = r.Key.BroadGroup,
                                OBDebit = r.Sum(x => x.OBDebit),
                                OBCredit = r.Sum(x => x.OBCredit),
                                Debit = r.Sum(x => x.Debit),
                                Credit = r.Sum(x => x.Credit)
                            }).ToList();
                        break;
                    }
                case 7:
                    {
                        returnData = data.GroupBy(x => new { x.CompanyName, x.CompanyAddress, x.CID, x.Category, x.SCID, x.SubCateogory, x.BGID, x.BroadGroup, x.NGID, x.NarrowGroup })
                           .Select(r => new TrialBalanceReportRM
                           {
                               CompanyName = r.Key.CompanyName,
                               CompanyAddress = r.Key.CompanyAddress,
                               CID = r.Key.CID,
                               Category = r.Key.Category,
                               SCID = r.Key.SCID,
                               SubCateogory = r.Key.SubCateogory,
                               BGID = r.Key.BGID,
                               BroadGroup = r.Key.BroadGroup,
                               NGID = r.Key.NGID,
                               NarrowGroup = r.Key.NarrowGroup,
                               OBDebit = r.Sum(x => x.OBDebit),
                               OBCredit = r.Sum(x => x.OBCredit),
                               Debit = r.Sum(x => x.Debit),
                               Credit = r.Sum(x => x.Credit)
                           }).ToList();
                        break;
                    }
                case 8:
                    {
                        returnData = data.GroupBy(x => new { x.CompanyName, x.CompanyAddress, x.CID, x.Category, x.SCID, x.SubCateogory, x.BGID, x.BroadGroup, x.NGID, x.NarrowGroup, x.IdentID, x.IDENTIFICATION })
                              .Select(r => new TrialBalanceReportRM
                              {
                                  CompanyName = r.Key.CompanyName,
                                  CompanyAddress = r.Key.CompanyAddress,
                                  CID = r.Key.CID,
                                  Category = r.Key.Category,
                                  SCID = r.Key.SCID,
                                  SubCateogory = r.Key.SubCateogory,
                                  BGID = r.Key.BGID,
                                  BroadGroup = r.Key.BroadGroup,
                                  NGID = r.Key.NGID,
                                  NarrowGroup = r.Key.NarrowGroup,
                                  IdentID = r.Key.IdentID,
                                  IDENTIFICATION = r.Key.IDENTIFICATION,
                                  OBDebit = r.Sum(x => x.OBDebit),
                                  OBCredit = r.Sum(x => x.OBCredit),
                                  Debit = r.Sum(x => x.Debit),
                                  Credit = r.Sum(x => x.Credit)
                              }).ToList();
                        break;
                    }
                case 14:
                    {
                        returnData = data.GroupBy(x => new { x.CompanyName, x.CompanyAddress, x.CID, x.Category, x.SCID, x.SubCateogory, x.BGID, x.BroadGroup, x.NGID, x.NarrowGroup, x.IdentID, x.IDENTIFICATION, x.TopID, x.ITEM })
                              .Select(r => new TrialBalanceReportRM
                              {
                                  CompanyName = r.Key.CompanyName,
                                  CompanyAddress = r.Key.CompanyAddress,
                                  CID = r.Key.CID,
                                  Category = r.Key.Category,
                                  SCID = r.Key.SCID,
                                  SubCateogory = r.Key.SubCateogory,
                                  BGID = r.Key.BGID,
                                  BroadGroup = r.Key.BroadGroup,
                                  NGID = r.Key.NGID,
                                  NarrowGroup = r.Key.NarrowGroup,
                                  IdentID = r.Key.IdentID,
                                  IDENTIFICATION = r.Key.IDENTIFICATION,
                                  TopID = r.Key.TopID,
                                  ITEM = r.Key.ITEM,
                                  OBDebit = r.Sum(x => x.OBDebit),
                                  OBCredit = r.Sum(x => x.OBCredit),
                                  Debit = r.Sum(x => x.Debit),
                                  Credit = r.Sum(x => x.Credit)
                              }).ToList();
                        break;
                    }
                default:
                    break;

            }
            foreach (var item in returnData)
            {
                decimal debitSum = 0;
                decimal creditSum = 0;
                if (item.Category == "Assets" || item.Category == "Expenditure")
                {
                    debitSum = item.OBDebit + item.Debit - Math.Abs(item.OBCredit) - Math.Abs(item.Credit);
                }
                else
                {
                    creditSum =  Math.Abs(item.OBCredit) + Math.Abs(item.Credit)- item.OBDebit - item.Debit;
                }
                /*
                if (debitCreditSum > 0)
                    item.BalanceDebit = debitCreditSum;
                else
                    item.BalanceCredit = Math.Abs(debitCreditSum);
                */
                item.BalanceDebit = debitSum;
                item.BalanceCredit = creditSum;
                item.SelectLevel = SelectLevel;
                item.DateFrom = DateFrom.ToString("dd-MMM-yyyy");
                item.DateTo = DateTo.ToString("dd-MMM-yyyy");
            };
            return returnData;
        }

        public async Task<List<VoucherShortInfoRM>> GetVoucherShortInfo(int accountID, DateTime dateFrom, DateTime dateTo, bool needConversion=false, CancellationToken cancellationToken=default)
        {
            return await _accountsReportsRepository.GetVoucherShortInfo(accountID,dateFrom,dateTo,needConversion, cancellationToken);
        }

        public async Task<List<VoucherShortInfoTBRM>> GetVoucherShortInfoTB(int accountID, DateTime dateFrom, DateTime dateTo, bool needConversion = false, CancellationToken cancellationToken = default)
        {
            return await _accountsReportsRepository.GetVoucherShortInfoTB(accountID, dateFrom,dateTo, needConversion, cancellationToken);
        }
    }
}
