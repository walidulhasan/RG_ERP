using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.MaterialsManagement.Business.Yarn_PermanentReceivingMasters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
using RG.DBEntities.MaterialsManagement.Business;
using RG.Infrastructure.Persistence.MaterialsManagementDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.MaterialsManagement.Business
{
    public class Yarn_PermanentReceivingMasterRepository : GenericRepository<Yarn_PermanentReceivingMaster>, IYarn_PermanentReceivingMasterRepository
    {
        private readonly MaterialsManagementDBContext _dbCon;
        private readonly ICurrentUserService _currentUserService;

        public Yarn_PermanentReceivingMasterRepository(MaterialsManagementDBContext dbCon, ICurrentUserService currentUserService) : base(dbCon)
        {
            _dbCon = dbCon;
            _currentUserService = currentUserService;
        }

        public async Task<List<SelectListItem>> DDLYarnReceivedBalanceLot(long SupplierID = 0, long POID = 0, int TopData = 500, string Predict = null, CancellationToken cancellationToken = default)
        {
            decimal quantityCondition = 0.99M;
            var query = from st in _dbCon.Yarn_StockTransactions
                        join lpr in _dbCon.Yarn_PermanentReceivingMaster on new { x1 = st.DocumentNo.HasValue ? st.DocumentNo.Value : 0, x2 = st.Status ?? 6 }
                                                                     equals new { x1 = lpr.YarnPermRecID, x2 = 6 } into stpr
                        from pr in stpr.DefaultIfEmpty()
                        where st.LotNo.Length > 0 && (Predict == null || st.LotNo.Contains(Predict))

                        select new
                        {
                            SupplierID = st.SupplierID,
                            POID = pr.YarnPOID,
                            LotNo = st.LotNo,
                            Qty = st.TransactionQty
                        };

            if (SupplierID > 0)
            {
                query = query.Where(b => b.SupplierID == SupplierID);
            }
            if (POID > 0)
            {
                query = query.Where(w => w.POID == POID);
            }
            var sss = query.ToQueryString();
            var groupQuery = from q in query
                             group q by q.LotNo into g
                             where g.Sum(b => b.Qty) > quantityCondition
                             orderby g.Key
                             select new SelectListItem
                             {
                                 //-}
                                 Text = $"{g.Key.Trim()} => {{{g.Sum(s => s.Qty):#.##}}}",
                                 Value = g.Key.Trim()
                             };
            var ss = groupQuery.Take(TopData).ToQueryString();
            return await groupQuery.Take(TopData).ToListAsync(cancellationToken);

        }

        public async Task<List<YarnReceivingByPoRM>> YarnReceivingByPOForRackAllocation(long SupplierID = 0, long POID = 0, long YarnPermRecID = 0, int TopData = 500, string LotNo = "", CancellationToken cancellationToken = default)
        {
            List<YarnReceivingByPoRM> rData = new List<YarnReceivingByPoRM>();

            #region Lot
            var query = from st in _dbCon.Yarn_StockTransactions
                        join leprm in _dbCon.Yarn_PermanentReceivingMaster on new { k1 = st.DocumentNo ?? 0, k3 = st.DocumentTypeID ?? 22 }
                                                               equals new { k1 = leprm.YarnPermRecID, k3 = 22 } into gr_prm
                        from prm in gr_prm.DefaultIfEmpty()
                        join lpo in _dbCon.Yarn_POMaster on prm.YarnPOID equals lpo.Yarn_POID into gr_po
                        from po in gr_po.DefaultIfEmpty()
                        join sup in _dbCon.Viw_Supplier on (int)st.SupplierID equals sup.SupplierID
                        join att in _dbCon.View_AttributeInstanceYarnInfo on st.AttributeInstanceID equals att.AttributeInstanceID

                        where st.CompanyID == _currentUserService.CompanyID  && st.TransactionQty > 0
                         && st.Status==6
                        orderby st.TransactionDate descending
                        select new YarnReceivingByPoRM
                        {
                            YarnStockTransactionID = st.YarnStockTransactionID,
                            SupplierName = sup.CompanyName,
                            SupplierID = sup.SupplierID,
                            POID = po == null ? 0 : po.Yarn_POID,
                            PONo = po == null ? "N/A" : po.YarnPONo,
                            PODate = po == null ? null : po.PODate,
                            LotNo = st.LotNo,
                            YarnPermRecID = prm == null ? 0 : prm.YarnPermRecID,
                            YarnPermRecNo = prm == null ? "N/A" : prm.YarnPermRecNo,
                            YarnPermRecDate = prm == null ? null : prm.YarnPermRecDate,
                            TransactionQty = st.TransactionQty.Value,
                            YarnColor = att.YarnColor,
                            YarnCount = att.YarnCount,
                            YarnComposition = att.YarnComposition,
                            YarnQuality = att.YarnQuality

                        };
            if (SupplierID > 0)
            {
                query = query.Where(w => w.SupplierID == SupplierID);
            }
            if (POID > 0)
            {
                query = query.Where(w => w.POID == POID);
            }
            if (YarnPermRecID > 0)
            {
                query = query.Where(w => w.YarnPermRecID == YarnPermRecID);
            }
            //   query = query.Take(TopData);
            if (!string.IsNullOrWhiteSpace(LotNo))
            {
                query = query.Where(w => w.LotNo == LotNo);
            }
            var sss = query.ToQueryString();
            rData = await query.OrderBy(b => b.YarnPermRecDate).ToListAsync(cancellationToken);

            #endregion Lot

            #region Lot in Rack
            var rackQuery = from yra in _dbCon.YarnRackAllocation
                            join sr in _dbCon.YarnSubRackSetup on new { ac = yra.IsActive, rmv = yra.IsRemoved, srID = yra.SubRackID } equals new { ac = true, rmv = false, srID = sr.SubRackID }
                            join r in _dbCon.YarnRackSetup on sr.RackID equals r.RackID
                            join fl in _dbCon.BuildingFloorInfo on r.BuildingFloorID equals fl.BuildingFloorID
                            join bl in _dbCon.BuildingInfo on fl.BuildingID equals bl.BuildingID
                            join st in _dbCon.Yarn_StockTransactions on new { stid = yra.YarnStockTransactionID } equals new { stid = st.YarnStockTransactionID }
                            join lprm in _dbCon.Yarn_PermanentReceivingMaster on st.DocumentNo equals lprm.YarnPermRecID into gr_prm
                            from prm in gr_prm.DefaultIfEmpty()
                            orderby yra.CreatedDate
                            select new
                            {
                                YarnStockTransactionID = st.YarnStockTransactionID,
                                AllocatedQuantity = yra.AllocatedQuantity,
                                BalanceQuantity = yra.BalanceQuantity,
                                RackAllocationID = yra.RackAllocationID,
                                BuildingID = bl.BuildingID,
                                BuildingName = bl.BuildingName,
                                BuildingFloorID = fl.BuildingFloorID,
                                BuildingFloor = fl.FloorName,
                                RackID = r.RackID,
                                RackName = r.RackName,
                                SubRackID = sr.SubRackID,
                                SubRackLimitQuantity = sr.StorageLimit,
                                SubRackName = sr.SubRackName,
                                StorageLimit = sr.StorageLimit,
                                POID = prm.YarnPOID ?? 0,
                                YarnPermRecID = prm == null ? 0 : prm.YarnPermRecID,
                                SupplierID = st.SupplierID
                            };
            if (SupplierID > 0)
            {
                rackQuery = rackQuery.Where(w => w.SupplierID == SupplierID);
            }
            if (POID > 0)
            {
                rackQuery = rackQuery.Where(w => w.POID == POID);
            }
            if (YarnPermRecID > 0)
            {
                rackQuery = rackQuery.Where(w => w.YarnPermRecID == YarnPermRecID);
            }
            var rackqueryStr = rackQuery.ToQueryString();
            var rackData = await rackQuery.Select(st => new YarnRackAllocationRM()
            {
                YarnStockTransactionID = st.YarnStockTransactionID,
                AllocatedQuantity = st.AllocatedQuantity,
                RackAllocationID = st.RackAllocationID,
                BuildingID = st.BuildingID,
                BuildingName = st.BuildingName,
                BuildingFloorID = st.BuildingFloorID,
                BuildingFloor = st.BuildingFloor,
                RackID = st.RackID,
                RackName = st.RackName,
                SubRackID = st.SubRackID,
                SubRackLimitQuantity = st.SubRackLimitQuantity,
                SubRackName = st.SubRackName,
                //  LimitRemaining = st.SubRackLimitQuantity - st.AllocatedQuantity,
                IsIssuedFromBalance = st.BalanceQuantity < st.AllocatedQuantity
            }).ToListAsync(cancellationToken);

            #endregion

            ///Sub Rack Total Allocacated 
            #region Subrack Total Allocated
            var rackIds = (from d in rackData
                           group d by d.SubRackID into dg
                           select dg.Key).ToList();

            var allocatedQuery = from al in _dbCon.YarnRackAllocation
                                 where al.IsRemoved == false && al.IsActive == true
                                 && (rackIds.Contains(al.SubRackID))
                                 group al by al.SubRackID into gal
                                 select new
                                 {
                                     SubRackID = gal.Key,
                                     CellAllocated = gal.Sum(b => b.AllocatedQuantity)
                                 };
            var allocatedData = await allocatedQuery.ToListAsync(cancellationToken);
            foreach (var r in rackData)
            {
                var hasData = allocatedData.Where(b => b.SubRackID == r.SubRackID).FirstOrDefault();
                if (hasData != null)
                {
                    r.TotalRackAllocated = hasData.CellAllocated;
                    r.LimitRemaining = r.SubRackLimitQuantity - hasData.CellAllocated;
                }

            }
            #endregion Subrack Total Allocated

            foreach (var rd in rData)
            {
                rd.YarnRackAllocation = rackData.Where(b => b.YarnStockTransactionID == rd.YarnStockTransactionID).ToList();

            }

            return rData;
        }
    }
}
