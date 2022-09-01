using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Business.Yarn_AllocationToKnitters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
using RG.DBEntities.MaterialsManagement.Business;
using RG.DBEntities.MaterialsManagement.DBViews;
using RG.Infrastructure.Persistence.MaterialsManagementDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.MaterialsManagement.Business
{
    public class Yarn_AllocationToKnitterRepository : GenericRepository<Yarn_AllocationToKnitter>, IYarn_AllocationToKnitterRepository
    {
        private readonly MaterialsManagementDBContext dbCon;
        private readonly IMapper _mapper;

        public Yarn_AllocationToKnitterRepository(MaterialsManagementDBContext _dbCon, IMapper mapper) : base(_dbCon)
        {
            dbCon = _dbCon;
            _mapper = mapper;
        }
        public async Task<List<DropDownItem>> GetDDLYarnRequisitionAfterAllocation(int KnitterID, int GatePassDetailID, string Predict = null, DateTime? DateFrom = null)
        {
            List<DropDownItem> requisitionList = new List<DropDownItem>();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GetDDLYarnRequisitionAfterAllocation")
                                  .WithSqlParam("KnitterID", KnitterID)
                                  .WithSqlParam("GatePassDetailID", GatePassDetailID)
                                  .WithSqlParam("Predict", Predict)
                                  .WithSqlParam("DateFrom", DateFrom)
                                  .ExecuteStoredProcAsync((handler) =>
                                  {
                                      requisitionList = handler.ReadToList<DropDownItem>() as List<DropDownItem>;
                                  });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return requisitionList;
        }
        public async Task<List<SelectListItem>> GetDDL_Order_WaitingForYarnIssue(DateTime dateFrom, DateTime dateTo, string predict = null, CancellationToken cancellationToken = default)
        {
            var dataQuery = GetOrder_Krs_Yknc_WaitingForYarnIssuance(dateFrom, dateTo);
            if (predict != null)
            {
                dataQuery = dataQuery.Where(x => x.OrderNo.Contains(predict));
            }

            var data = await dataQuery
                .Select(x => new SelectListItem
                {
                    Text = x.OrderNo,
                    Value = x.OrderID.ToString()
                }).Distinct().ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<SelectListItem>> GetDDL_KRS_WaitingForYarnIssue(DateTime dateFrom, DateTime dateTo, int orderID = 0, string predict = null, CancellationToken cancellationToken = default)
        {
            var dataQuery = GetOrder_Krs_Yknc_WaitingForYarnIssuance(dateFrom, dateTo);
            if (orderID > 0)
            {
                dataQuery = dataQuery.Where(x => x.OrderID == orderID);
            }
            if (predict != null)
            {
                dataQuery = dataQuery.Where(x => x.KRSName.Contains(predict));
            }
            var data = await dataQuery.Select(x => new SelectListItem
            {
                Text = x.KRSName,
                Value = x.KRSID.ToString()
            }).Distinct().ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<SelectListItem>> GetDDL_YKNC_WaitingForYarnIssue(DateTime dateFrom, DateTime dateTo, int orderID = 0, int krsID = 0, string predict = null, CancellationToken cancellationToken = default)
        {
            var dataQuery = GetOrder_Krs_Yknc_WaitingForYarnIssuance(dateFrom, dateTo);
            if (orderID > 0)
            {
                dataQuery = dataQuery.Where(x => x.OrderID == orderID);
            }
            if (krsID > 0)
            {
                dataQuery = dataQuery.Where(x => x.KRSID == krsID);
            }
            if (predict != null)
            {
                dataQuery = dataQuery.Where(x => x.YKNCName.Contains(predict));
            }
            var data = await dataQuery.Select(x => new SelectListItem
            {
                Text = x.YKNCName,
                Value = x.YKNCID.ToString()
            }).ToListAsync(cancellationToken);
            return data;
        }

        private IQueryable<OrderKrsYkncForYarnIssuanceRM> GetOrder_Krs_Yknc_WaitingForYarnIssuance(DateTime dateFrom, DateTime dateTo)
        {
            var queryYKNC = from yknc in dbCon.Yarn_KnittingContractMaster
                            join alloc in dbCon.Yarn_AllocationToKnitter on yknc.YarnKNContractID equals alloc.YKNCID
                            //join knit on dbCon.
                            where alloc.TransactionDate >= dateFrom && alloc.TransactionDate <= dateTo
                            group new { yknc, alloc } by new { yknc.YarnKNContractID, yknc.ContractName, yknc.KRS_ID, yknc.TotalQty } into grpYknc
                            // where grpYknc.Sum(s=>s..
                            select new
                            {
                                YKNCID = grpYknc.Key.YarnKNContractID,
                                YKNCName = grpYknc.Key.ContractName,
                                KRSID = grpYknc.Key.KRS_ID,
                                RequiredQty = grpYknc.Key.TotalQty,
                                IssuedQty = grpYknc.Sum(g => g.alloc.IssuedQty)
                            };

            var query = from yknc in queryYKNC
                        join krs in dbCon.vw_KRSOrder on yknc.KRSID equals krs.KRSID
                        where yknc.RequiredQty > yknc.IssuedQty
                        select new OrderKrsYkncForYarnIssuanceRM
                        {
                            KRSID = krs.KRSID,
                            KRSName = $"KRS-{krs.KRSID}",
                            YKNCID = yknc.YKNCID,
                            YKNCName = yknc.YKNCName,
                            OrderID = krs.OrderID,
                            OrderNo = krs.OrderNo
                        };

            return query;
        }

        public async Task<YarnLotForIssuanceRM> GetYarnLotForIssuance(long ykncID, CancellationToken cancellationToken)
        {
            YarnLotForIssuanceRM yarnLotForIssuance = new();

            List<YKNCMasterInfoRM> ykncMasterInfo = new();
            List<YKNCDetailInfoRM> ykncDetailInfo = new();
            List<YKNCLotMasterInfoRM> ykncLotMasterInfo = new();
            List<YKNCLotDetailInfoRM> ykncLotDetailInfo = new();

            try
            {
                await dbCon.LoadStoredProc("ajt.USP_GetYarnLotForIssuance")
                                  .WithSqlParam("YKNCID", ykncID)
                                  .ExecuteStoredProcAsync((handler) =>
                                  {
                                      ykncMasterInfo = handler.ReadToList<YKNCMasterInfoRM>() as List<YKNCMasterInfoRM>;
                                      handler.NextResult();
                                      ykncDetailInfo = handler.ReadToList<YKNCDetailInfoRM>() as List<YKNCDetailInfoRM>;
                                      handler.NextResult();
                                      ykncLotMasterInfo = handler.ReadToList<YKNCLotMasterInfoRM>() as List<YKNCLotMasterInfoRM>;
                                      handler.NextResult();
                                      ykncLotDetailInfo = handler.ReadToList<YKNCLotDetailInfoRM>() as List<YKNCLotDetailInfoRM>;
                                  });

                if (ykncMasterInfo.Count > 0)
                {
                    YKNCMasterDetailInfoRM ykncMasterDetailInfo = new();
                    List<YarnAttributeInfoRM> yarnAttributeInfo = new();
                    //List<YKNCLotMasterDetailInfoRM> ykncLotMasterDetailInfo = new();

                    ykncMasterDetailInfo.YKNCMasterInfo = ykncMasterInfo.First();
                    ykncMasterDetailInfo.YKNCDetailInfo = ykncDetailInfo;

                    foreach (var itemAttID in ykncLotMasterInfo.Select(x => x.AttributeInstanceID).Distinct())
                    {

                        var attributeDetail = await (from att in dbCon.View_AttributeInstanceYarnInfo
                                                     join mm in dbCon.MM_MRPItem on att.MRPItemCode equals mm.MRPItemCode
                                                     where att.AttributeInstanceID == itemAttID
                                                     select new YarnAttributeInfoRM()
                                                     {
                                                         YarnType = mm.MName.Trim(),
                                                         AttributeInstanceID = att.AttributeInstanceID,
                                                         YarnComposition = att.YarnComposition,
                                                         YarnCompositionID = att.YarnCompositionID ?? 0,
                                                         CountID = att.CountID ?? 0,
                                                         YarnCount = att.YarnCount,
                                                         YarnQuality = att.YarnQuality,
                                                         YarnQualityID = att.YarnQualityID ?? 0,
                                                         YarnColor = att.YarnColor ?? "N/A",
                                                         MRPItemCode = att.MRPItemCode
                                                     }).FirstOrDefaultAsync(cancellationToken);
                        if (attributeDetail != null)
                        {
                            YarnAttributeInfoRM attributeInfo = attributeDetail; //_mapper.Map<View_AttributeInstanceYarnInfo, YarnAttributeInfoRM>(attributeDetail);
                            List<YKNCLotMasterDetailInfoRM> lotMasterDetailInfo = new();

                            lotMasterDetailInfo = ykncLotMasterInfo.Where(x => x.AttributeInstanceID == itemAttID).Select(s => new YKNCLotMasterDetailInfoRM
                            {
                                MRPItemCode = s.MRPItemCode,
                                AttributeInstanceID = s.AttributeInstanceID,
                                YarnAttributeInstanceID = s.YarnAttributeInstanceID,
                                SupplierID = s.SupplierID,
                                BrandID = s.BrandID,
                                PackagingID = s.PackagingID,
                                ConesPerProcurementUnit = s.ConesPerProcurementUnit,
                                UnitID = s.UnitID,
                                UnitName = s.UnitName,
                                StoreLocationID = s.StoreLocationID,
                                LocationName = s.LocationName,
                                Rate = s.Rate,
                                RateUnitID = s.RateUnitID,
                                MovingAverage = s.MovingAverage,
                                TransactionQty = s.TransactionQty,
                                ProgramTypeID = s.ProgramTypeID,
                                LotNo = s.LotNo,
                                Status = s.Status,
                                RateWRTBaseUnit = s.RateWRTBaseUnit,
                                YKNCID = s.YKNCID,
                                AllocatedQty = s.AllocatedQty,
                                IssuedQty = s.IssuedQty,
                                CompanyID = s.CompanyID,
                                BusinessID = s.BusinessID,
                                YKNCLotDetailInfo = ykncLotDetailInfo.Where(x => x.LotNo == s.LotNo).ToList()

                            }).ToList();
                            attributeInfo.YKNCLotMasterDetailInfo = lotMasterDetailInfo;
                            yarnLotForIssuance.YarnAttributeInfo.Add(attributeInfo);
                        }

                    }
                    yarnLotForIssuance.YKNCMasterDetailInfo = ykncMasterDetailInfo;

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return yarnLotForIssuance;
        }
    }
}
