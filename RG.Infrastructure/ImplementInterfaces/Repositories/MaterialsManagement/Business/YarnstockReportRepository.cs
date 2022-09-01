using Microsoft.EntityFrameworkCore;
using RG.Application.Contracts.MaterialsManagement.Business.YarnStockReport.RequestResponseModel;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
using RG.Infrastructure.Persistence.MaterialsManagementDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.MaterialsManagement.Business
{
    public class YarnstockReportRepository : IYarnstockReportRepository
    {
        private readonly MaterialsManagementDBContext _dbCon;
        public YarnstockReportRepository(MaterialsManagementDBContext dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<List<YarnStockReportRM>> GetYarnStock(DateTime DateFrom, DateTime DateTo, int WithAllTransaction = 1, int ShowEmptyClosing = 0)
        {
            var itemList = new List<YarnStockReportRM>();
            try
            {
                await _dbCon.LoadStoredProc("ajt.GetYarnStock", commandTimeout: 500)
                             .WithSqlParam("DateFrom", DateFrom)
                             .WithSqlParam("DateTo", DateTo)
                              .WithSqlParam("WithAllTransaction", WithAllTransaction)
                              .WithSqlParam("ShowEmptyClosing", ShowEmptyClosing)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<YarnStockReportRM>() as List<YarnStockReportRM>;
                             });
                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<YarnStockReportRM>> GetYarnStockWithRack(DateTime DateFrom, DateTime DateTo, int WithAllTransaction, int ShowEmptyClosing = 0)
        {
            try
            {
                var itemList = await GetYarnStock(DateFrom, DateTo, WithAllTransaction, ShowEmptyClosing);
                var rackQuery = from YRA in _dbCon.YarnRackAllocation
                                join YST in _dbCon.Yarn_StockTransactions on YRA.YarnStockTransactionID equals YST.YarnStockTransactionID
                                join YSRS in _dbCon.YarnSubRackSetup on YRA.SubRackID equals YSRS.SubRackID
                                join YR in _dbCon.YarnRackSetup on YSRS.RackID equals YR.RackID
                                join BFI in _dbCon.BuildingFloorInfo on YR.BuildingFloorID equals BFI.BuildingFloorID
                                join BI in _dbCon.BuildingInfo on BFI.BuildingID equals BI.BuildingID
                                group new { YRA, YST, YSRS, YR, BFI, BI } by new
                                {
                                    BI.BuildingName,
                                    BFI.FloorName,
                                    YR.RackID,
                                    YR.RackName,
                                    YR.RackShortName,
                                    YSRS.SubRackName,
                                    YSRS.SubRackShortName,
                                    YST.LotNo,
                                    YR.RackSerial,
                                    YSRS.SubRackSerial
                                } into gr
                                select new YarnSubRackAllocationBalanceRM()
                                {
                                    BalanceQuantity = gr.Sum(b => b.YRA.BalanceQuantity.Value),
                                    BuildingName = gr.Key.BuildingName,
                                    FloorName = gr.Key.FloorName,
                                    LotNo = gr.Key.LotNo,
                                    RackID = gr.Key.RackID,
                                    RackName = gr.Key.RackName,
                                    RackSerial = gr.Key.RackSerial,
                                    RackShortName = gr.Key.RackShortName,
                                    SubRackName = gr.Key.SubRackName,
                                    SubRackSerial = gr.Key.SubRackSerial,
                                    SubRackShortName = gr.Key.SubRackShortName
                                };
                var query = rackQuery.ToQueryString();
                var rackData = await rackQuery.ToListAsync();
                foreach (var lot in itemList)
                {
                    lot.YarnSubRackAllocationBalance = rackData.Where(b => b.LotNo == lot.LotNo).ToList();
                }

                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public async Task<List<YarnRackBalanceReportRM>> GetYarnRackBalanceReport(string LotNo = null, int BuildingID = 0, int FloorID = 0, int RackID = 0, int CompositionID = 0, string Count = null, int OrderBy = 0)
        {
            decimal conditionalQty = 1.0M;

            var lotCompanyQuery = from lt in _dbCon.Yarn_StockTransactions
                                  where lt.DocumentTypeID == 22
                                  select new
                                  {
                                      LotNo = lt.LotNo,
                                      CompanyID = lt.CompanyID
                                  };
            if (!string.IsNullOrEmpty(LotNo))
            {
                lotCompanyQuery = lotCompanyQuery.Where(b => b.LotNo == LotNo);
            }

                 var lotCompany = await (from lt in lotCompanyQuery
                                group lt by lt.LotNo into grp
                             select new YarnRackBalanceReportRM
                                {
                                    LotNo = grp.Key,
                                    CompanyID = grp.Min(b => b.CompanyID.Value)
                                }).ToListAsync();
             

            ///LotBalance
            #region LotBalance
            var lotBalanceQuery = from lot in _dbCon.Yarn_StockTransactions
                                  join att in _dbCon.View_AttributeInstanceYarnInfo on lot.AttributeInstanceID equals att.AttributeInstanceID
                                  join sup in _dbCon.Viw_Supplier on lot.SupplierID equals sup.SupplierID
                                  where lot.Status == 6
                                  && (CompositionID==0 || att.YarnCompositionID==CompositionID)
                                  && (Count == null || att.YarnCount == Count)
                                  group new { lot, sup } by new { lot.LotNo, lot.SupplierID, lot.AttributeInstanceID, sup.CompanyName } into grp
                                  where grp.Select(g=>g.lot.TransactionQty).Sum()>conditionalQty
                                  select new {
                                      grp.Key.LotNo,
                                      grp.Key.SupplierID,
                                      grp.Key.CompanyName,
                                      grp.Key.AttributeInstanceID,
                                      TransactionQty = grp.Sum(b => b.lot.TransactionQty),
                                      TransactionDate = grp.Min(b => b.lot.TransactionDate)
                                  };
            /*
                           .Where(b => b.Status == 6)
                           .GroupBy(g => new { g.LotNo, g.SupplierID, g.AttributeInstanceID })
                           .Select(s => new
                           {
                               s.Key.LotNo,
                               s.Key.SupplierID,
                               s.Key.AttributeInstanceID,
                               TransactionQty = s.Sum(b => b.TransactionQty),
                               TransactionDate = s.Min(b => b.TransactionDate)
                           }).Where(b => b.TransactionQty > conditionalQty)
                           .Select(s => new YarnRackBalanceReportRM
                           {
                               SupplierID = s.SupplierID,
                               AttributeInstanceID = s.AttributeInstanceID,
                               LotNo = s.LotNo,
                               TransactionDate = s.TransactionDate,
                               TransactionQty = s.TransactionQty.HasValue ? s.TransactionQty.Value : 0
                           });
            */
            //var toQueryStr = lotBalanceQuery.ToQueryString();
            var lotBalance = await lotBalanceQuery.ToListAsync();
            #endregion LotBalance
            ///Allocation 
            #region Lot Allocation
            var lotAllocationBalanceQuery = from st in _dbCon.Yarn_StockTransactions
                                            join att in _dbCon.View_AttributeInstanceYarnInfo on st.AttributeInstanceID equals att.AttributeInstanceID
                                            join rall in _dbCon.YarnRackAllocation on new { a = st.YarnStockTransactionID, b = false, c = true }
                                                                              equals new { a = rall.YarnStockTransactionID, b = rall.IsRemoved, c = rall.IsActive }
                                            join srck in _dbCon.YarnSubRackSetup on rall.SubRackID equals srck.SubRackID
                                            join rck in _dbCon.YarnRackSetup on srck.RackID equals rck.RackID
                                            join flr in _dbCon.BuildingFloorInfo on rck.BuildingFloorID equals flr.BuildingFloorID
                                            join bul in _dbCon.BuildingInfo on flr.BuildingID equals bul.BuildingID
                                            where st.Status == 6 && st.TransactionQty > 0
                                            && (BuildingID==0 || bul.BuildingID==BuildingID)
                                            && (FloorID==0 || flr.BuildingFloorID==FloorID)
                                            && (RackID==0 || rck.RackID==RackID)
                                            && (CompositionID==0 || att.YarnCompositionID==CompositionID)
                                            && (Count==null || att.YarnCount==Count)
                                            group new { st, rall, srck, rck, flr, bul }
                                            by new
                                            {
                                                st.SupplierID,
                                                st.AttributeInstanceID,
                                                st.LotNo,
                                                rall.SubRackID,
                                                srck.SubRackName,
                                                srck.SubRackSerial,
                                                rck.RackShortName,
                                                rck.RackSerial,
                                                flr.FloorName,
                                                bul.BuildingName,
                                            } into g_st_ral
                                            select new YarnRackBalanceReportRM
                                            {
                                                SupplierID = g_st_ral.Key.SupplierID,
                                                AttributeInstanceID = g_st_ral.Key.AttributeInstanceID,
                                                LotNo = g_st_ral.Key.LotNo,
                                                SubRackID = g_st_ral.Key.SubRackID,
                                                SubRackName = g_st_ral.Key.SubRackName,
                                                SubRackSerial = g_st_ral.Key.SubRackSerial,
                                                RackShortName = g_st_ral.Key.RackShortName,
                                                RackSerial = g_st_ral.Key.RackSerial,
                                                FloorName = g_st_ral.Key.FloorName,
                                                BuildingName = g_st_ral.Key.BuildingName,
                                                AllocatedQuantity = g_st_ral.Sum(s => s.rall.AllocatedQuantity),
                                            };
           

            var lotAllocationBalanceQueryStr = lotAllocationBalanceQuery.ToQueryString();
            var lotAllocationBalance = await lotAllocationBalanceQuery.ToListAsync();

            #endregion Lot Allocation

            #region Lot Issue
            var lotIssueQuery = from st in _dbCon.Yarn_StockTransactions
                                join RIssue in _dbCon.YarnRackIssue on new { a = st.YarnStockTransactionID, b = false, c = true }
                                                                  equals new { a = RIssue.YarnStockTransactionID, b = RIssue.IsRemoved, c = RIssue.IsActive }
                                join RAlloc in _dbCon.YarnRackAllocation on RIssue.RackAllocationID equals RAlloc.RackAllocationID
                                join srck in _dbCon.YarnSubRackSetup on RAlloc.SubRackID equals srck.SubRackID
                                join rck in _dbCon.YarnRackSetup on srck.RackID equals rck.RackID
                                join flr in _dbCon.BuildingFloorInfo on rck.BuildingFloorID equals flr.BuildingFloorID
                                group new { st, RIssue, RAlloc }
                                            by new
                                            {
                                                st.SupplierID,
                                                st.AttributeInstanceID,
                                                st.LotNo,
                                                RAlloc.SubRackID
                                            } into g_st_ral
                                select new YarnRackBalanceReportRM
                                {
                                    SupplierID = g_st_ral.Key.SupplierID,
                                    AttributeInstanceID = g_st_ral.Key.AttributeInstanceID,
                                    LotNo = g_st_ral.Key.LotNo,
                                    SubRackID = g_st_ral.Key.SubRackID,
                                    IssuedQuantity = g_st_ral.Sum(s => s.RIssue.IssueQuantity),
                                };
            //var lotIssueQueryString = lotIssueQuery.
            var lotIssue = await lotIssueQuery.ToListAsync();
            #endregion Lot ISSUE

            /// Attribute Info
            var attributeInfo = await _dbCon.View_AttributeInstanceYarnInfo.ToListAsync();

            var data = from lot in lotBalance 
                       join com in lotCompany on lot.LotNo equals com.LotNo
                       join att in attributeInfo on lot.AttributeInstanceID equals att.AttributeInstanceID
                       join _alloc in lotAllocationBalance on new { a = lot.LotNo, b = lot.AttributeInstanceID, c = lot.SupplierID }
                                                       equals new { a = _alloc?.LotNo, b = _alloc?.AttributeInstanceID, c = _alloc?.SupplierID }
                                                   into left__alloc
                       from alloc in left__alloc.DefaultIfEmpty()
                       join _issue in lotIssue on new { a = alloc?.LotNo, b = alloc?.AttributeInstanceID, c = alloc?.SupplierID, d = alloc?.SubRackID }
                                           equals new { a = _issue?.LotNo, b = _issue?.AttributeInstanceID, c = _issue?.SupplierID, d = _issue?.SubRackID }
                                           into left_issue
                       from issue in left_issue.DefaultIfEmpty()
                       select new YarnRackBalanceReportRM
                       {
                           LotNo = lot.LotNo,
                           CompanyName = com.CompanyID == 183 ? "RBL" : "CBL",
                           YarnComposition = att.YarnComposition,
                           YarnCount = att.YarnCount,
                           YarnQuality = att.YarnQuality,
                           YarnColor = att.YarnColor,
                           SupplierID = lot.SupplierID,
                           SupplierName=lot.CompanyName,
                           AttributeInstanceID = lot.AttributeInstanceID,
                           TransactionDate = lot.TransactionDate,
                           LotAge = (DateTime.Now-lot.TransactionDate.Value).TotalDays,
                           TransactionQty = lot.TransactionQty??0,
                           SubRackID = (alloc != null) ? alloc.SubRackID : 0,
                           SubRackName = (alloc != null) ? alloc.SubRackName : "",
                           SubRackSerial = (alloc != null) ? alloc.SubRackSerial : 999,
                           RackShortName = (alloc != null) ? alloc.RackShortName : "",
                           RackSerial = (alloc != null) ? alloc.RackSerial : 999,
                           FloorName = (alloc != null) ? alloc.FloorName : "",
                           BuildingName = (alloc != null) ? alloc.BuildingName : "",
                           SubRackBalanceQty = (alloc == null ? 0 : alloc.AllocatedQuantity) - (issue == null ? 0 : issue.IssuedQuantity),
                       };
            if (OrderBy == 1)
            {
                return data.OrderBy(x => x.LotNo).ToList();
            }
            else if (OrderBy == 2)
            {
                return data.OrderBy(x => x.RackSerial).ThenBy(x=>x.SubRackSerial).ToList();
            }
            else
            {
                return data.ToList();
            }


            

        }

    }
}
