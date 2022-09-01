using Microsoft.EntityFrameworkCore;
using RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Maxco.Business;
using RG.Application.Interfaces.Services.Maxco.Business;
using RG.Application.ViewModel.Maxco.Business.OrderPlanReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Maxco.Business
{
    public class OrderPlanReportsService : IOrderPlanReportsService
    {
        private readonly IOrderPlanReportsRepository orderPlanReportsRepository;

        public OrderPlanReportsService(IOrderPlanReportsRepository _orderPlanReportsRepository)
        {
            orderPlanReportsRepository = _orderPlanReportsRepository;
        }

        //public async Task<WeeklySummaryVM> GetBuyerWiseFabricSummary(DateTime DateFrom, DateTime DateTo, int BuyerID, int OrderID)
        //{
        //    var rawData = await orderPlanReportsRepository.GetBuyerWiseFabricSummary(DateFrom, DateTo, BuyerID, OrderID);
        //    foreach (var itemRaw in rawData.OrderInfo)
        //    {
        //        var greigeData = rawData.OrderGreigeFabric.Where(x => x.OrderID == itemRaw.OrderID).FirstOrDefault();
        //        var greigeQty = greigeData == null ? 0 : greigeData.GreigeQuantity;
        //        if (greigeQty > itemRaw.PlanKnittingQty)
        //        {
        //            itemRaw.KnittingQty = itemRaw.PlanKnittingQty;
        //            rawData.OrderGreigeFabric.Where(x => x.OrderID == itemRaw.OrderID).First().GreigeQuantity = greigeQty - itemRaw.PlanKnittingQty;
        //        }
        //        else
        //        {
        //            itemRaw.KnittingQty = greigeQty;
        //            if (greigeData != null)
        //                rawData.OrderGreigeFabric.Where(x => x.OrderID == itemRaw.OrderID).First().GreigeQuantity = 0;
        //        }
        //        itemRaw.KnittingBalance = itemRaw.KnittingQty - itemRaw.PlanKnittingQty;

        //        var batchData = rawData.OrderFinishFabric.Where(c => c.OrderID == itemRaw.OrderID && c.PantoneNo == itemRaw.PantoneNo).FirstOrDefault();
        //        var batchQty = batchData == null ? 0 : batchData.BatchQty;
        //        if (batchQty > itemRaw.PlanKnittingQty)
        //        {
        //            itemRaw.BatchQty = itemRaw.PlanKnittingQty;
        //            rawData.OrderFinishFabric.Where(c => c.OrderID == itemRaw.OrderID && c.PantoneNo == itemRaw.PantoneNo).First().BatchQty = batchQty - itemRaw.PlanKnittingQty;
        //        }
        //        else
        //        {
        //            itemRaw.BatchQty = batchQty;
        //            if (batchData != null)
        //                rawData.OrderFinishFabric.Where(c => c.OrderID == itemRaw.OrderID && c.PantoneNo == itemRaw.PantoneNo).First().BatchQty = 0;
        //        }
        //        itemRaw.BatchBalance = itemRaw.BatchQty - itemRaw.PlanKnittingQty;

        //        var finishedFabricQty = batchData == null ? 0 : batchData.FinishQty;
        //        if (finishedFabricQty > itemRaw.FinFabricBooking)
        //        {
        //            itemRaw.FinishFabricDeliveryQty = itemRaw.FinFabricBooking;
        //            rawData.OrderFinishFabric.Where(c => c.OrderID == itemRaw.OrderID && c.PantoneNo == itemRaw.PantoneNo).First().FinishQty = finishedFabricQty - itemRaw.FinFabricBooking;
        //        }
        //        else
        //        {
        //            itemRaw.FinishFabricDeliveryQty = finishedFabricQty;
        //            if (batchData != null)
        //                rawData.OrderFinishFabric.Where(c => c.OrderID == itemRaw.OrderID && c.PantoneNo == itemRaw.PantoneNo).First().FinishQty = 0;
        //        }
        //        itemRaw.FinishFabricDeliveryBal = itemRaw.FinishFabricDeliveryQty - itemRaw.FinFabricBooking;
        //    }
        //    return rawData;
        //}

        public async Task<List<GarmentAssortmentAndFabricsInfoRM>> GetBuyerWiseFabricSummaryReport(DateTime DateFrom, DateTime DateTo, int BuyerID, int OrderID)
        {
            var rawData = await GetGarmentAssortmentAndFabricsInfo(DateFrom, DateTo, BuyerID, OrderID);
            var calculatedData = rawData.Where(x => x.DeliveryDate >= DateFrom && x.DeliveryDate <= DateTo).ToList();

            var noOfOrder = calculatedData.Select(x => new
            {
                x.FabricMonthSl,
                x.FabricMonth,
                x.BuyerID,
                x.BuyerName,
                x.FabricWeek,
                x.DeliveryDate,
                x.OrderID
            }).Distinct();

            var returnData = calculatedData
                .GroupBy(x => new { x.FabricMonthSl, x.FabricMonth, x.BuyerID, x.BuyerName, x.FabricWeek, x.DeliveryDate })
                .Select(x => new GarmentAssortmentAndFabricsInfoRM
                {
                    FabricMonthSl = x.Key.FabricMonthSl,
                    FabricMonth = x.Key.FabricMonth,
                    BuyerID = x.Key.BuyerID,
                    BuyerName = x.Key.BuyerName,
                    FabricWeek = x.Key.FabricWeek,
                    DeliveryDate = x.Key.DeliveryDate,
                    NoOfOrders = noOfOrder.Where(b => b.BuyerID == x.Key.BuyerID
                                        && b.FabricMonthSl == x.Key.FabricMonthSl
                                        && b.DeliveryDate == x.Key.DeliveryDate
                                        && b.FabricWeek == x.Key.FabricWeek
                                        ).Select(b => b.OrderID).Count(),
                    NumberofGarments = x.Sum(s => s.NumberofGarments),
                    FinFabricBooking = x.Sum(s => s.TotalFinFabricBooking),
                    PlanKnittingQty = x.Sum(s => s.PlanKnittingQty),
                    KnittingQty = x.Sum(s => s.KnittingQty),
                    KnittingBalance = x.Sum(s => s.KnittingBalance),
                    BatchQty = x.Sum(s => s.BatchQty),
                    BatchBalance = x.Sum(s => s.BatchBalance),
                    FinishFabricDeliveryQty = x.Sum(s => s.FinishFabricDeliveryQty),
                    RibQty = x.Sum(s => s.RibQty),
                    FinishFabricDeliveryBal = x.Sum(s => s.FinishFabricDeliveryBal)
                }).OrderBy(x => x.FabricMonthSl).ThenBy(x => x.BuyerID).ThenBy(x => x.FabricWeek).ToList();
            return returnData;
        }

        public async Task<List<GarmentAssortmentAndFabricsInfoRM>> GetBuyerWiseStatusReport(DateTime DateFrom, DateTime DateTo, int BuyerID, int OrderID)
        {
            var rawData = await GetGarmentAssortmentAndFabricsInfo(DateFrom, DateTo, BuyerID, OrderID);
            var calculatedData = rawData.Where(x => x.DeliveryDate >= DateFrom && x.DeliveryDate <= DateTo).ToList();

            var additionalData = await orderPlanReportsRepository.GetOrderAdditionalInfo(DateFrom, DateTo, BuyerID, OrderID);

            foreach (var itemData in calculatedData)
            {
                var batchCommitment = additionalData.BatchCommitment.Where(x => x.OrderID == itemData.OrderID).ToList();
                itemData.BatchCommitmentDateMsg = batchCommitment.Count > 0 ? batchCommitment.Max(x => x.CommitmentDate).ToString("dd-MMM-yyyy") : "";
                var artWork = additionalData.ArtWork.Where(x => x.OrderID == itemData.OrderID && x.PantoneNo == itemData.PantoneNo).FirstOrDefault();
                itemData.ArtWork = artWork == null ? "" : artWork.ArtWorkName;
                var dyeingUnit = additionalData.DyeingProductionLocation.Where(x => x.OrderID == itemData.OrderID).FirstOrDefault();
                itemData.DyeingProductionUnit = dyeingUnit == null ? "" : dyeingUnit.LocationName;

                var deliveryCommitment = additionalData.DeliveryCommitment.Where(x => x.OrderID == itemData.OrderID).ToList();
                itemData.DeliveryCommitmentDateMsg = deliveryCommitment.Count == 0 ? "" : deliveryCommitment.Max(x => x.CommitmentDate).ToString("dd-MMM-yyyy");
            }
            return calculatedData;
        }

        public async Task<List<GarmentAssortmentAndFabricsInfoRM>> GetFabricTypeWiseOrderStatusReport(DateTime DateFrom, DateTime DateTo, int BuyerID, int OrderID)
        {
            var rawData = await GetGarmentAssortmentAndFabricsInfo(DateFrom, DateTo, BuyerID, OrderID);
            var calculatedData = rawData.Where(x => x.DeliveryDate >= DateFrom && x.DeliveryDate <= DateTo).ToList();

            var additionalData = await orderPlanReportsRepository.GetOrderAdditionalInfo(DateFrom, DateTo, BuyerID, OrderID);

            foreach (var itemData in calculatedData)
            {
                var batchCommitment = additionalData.BatchCommitment.Where(x => x.OrderID == itemData.OrderID).ToList();
                itemData.BatchCommitmentDateMsg = batchCommitment.Count > 0 ? batchCommitment.Max(x => x.CommitmentDate).ToString("dd-MMM-yyyy") : "";
                var artWork = additionalData.ArtWork.Where(x => x.OrderID == itemData.OrderID && x.PantoneNo == itemData.PantoneNo).FirstOrDefault();
                itemData.ArtWork = artWork == null ? "" : artWork.ArtWorkName;
                var dyeingUnit = additionalData.DyeingProductionLocation.Where(x => x.OrderID == itemData.OrderID).FirstOrDefault();
                itemData.DyeingProductionUnit = dyeingUnit == null ? "" : dyeingUnit.LocationName;

                var deliveryCommitment = additionalData.DeliveryCommitment.Where(x => x.OrderID == itemData.OrderID).ToList();
                itemData.DeliveryCommitmentDateMsg = deliveryCommitment.Count == 0 ? "" : deliveryCommitment.Max(x => x.CommitmentDate).ToString("dd-MMM-yyyy");
            }
            return calculatedData;
        }

        public async Task<List<GarmentAssortmentAndFabricsInfoRM>> GetGarmentAssortmentAndFabricsInfo(DateTime DateFrom, DateTime DateTo, int BuyerID, int OrderID)
        {
            var rawData = await orderPlanReportsRepository.GetGarmentAssortmentAndFabricsInfo(DateFrom, DateTo, BuyerID, OrderID);
            foreach (var itemRaw in rawData.FabricInfo)
            {
                #region
                var greigeData = rawData.GreigeFabric.Where(x => x.OrderID == itemRaw.OrderID).FirstOrDefault();

                var greigeQty = greigeData == null ? 0 : greigeData.GreigeQuantity;
                if (greigeQty > 0 && greigeQty > itemRaw.PlanKnittingQty)
                {
                    itemRaw.KnittingQty = itemRaw.PlanKnittingQty;
                    rawData.GreigeFabric.Where(x => x.OrderID == itemRaw.OrderID).First().GreigeQuantity = greigeQty - itemRaw.PlanKnittingQty;
                }
                else
                {
                    itemRaw.KnittingQty = greigeQty;
                    if (greigeData != null)
                        rawData.GreigeFabric.Where(x => x.OrderID == itemRaw.OrderID).First().GreigeQuantity = 0;
                }
                itemRaw.KnittingBalance = itemRaw.KnittingQty - itemRaw.PlanKnittingQty;
                #endregion

                var batchData = rawData.FinishFabric.Where(c => c.OrderID == itemRaw.OrderID
                                                             && c.PantoneNo == itemRaw.PantoneNo
                                                             && c.BatchQty > 0).FirstOrDefault();
                #region Batch

                var batchQty = batchData == null ? 0 : batchData.BatchQty;
                if (batchQty > 0 && batchQty > itemRaw.PlanKnittingQty)
                {
                    itemRaw.BatchQty = itemRaw.PlanKnittingQty;
                    rawData.FinishFabric.Where(c => c.OrderID == itemRaw.OrderID && c.PantoneNo == itemRaw.PantoneNo).First().BatchQty = batchQty - itemRaw.PlanKnittingQty;
                }
                else
                {
                    itemRaw.BatchQty = batchQty;
                    if (batchData != null)
                        rawData.FinishFabric.Where(c => c.OrderID == itemRaw.OrderID && c.PantoneNo == itemRaw.PantoneNo).First().BatchQty = 0;
                }
                itemRaw.BatchBalance = itemRaw.BatchQty - itemRaw.PlanKnittingQty;
                #endregion

                var finishData = rawData.FinishFabric.Where(c => c.OrderID == itemRaw.OrderID
                                                             && c.PantoneNo == itemRaw.PantoneNo
                                                             && c.FinishQty > 0).FirstOrDefault();
                #region Finish
                var finishedFabricQty = finishData == null ? 0 : finishData.FinishQty;
                if (finishedFabricQty > itemRaw.FinFabricBooking)
                {
                    itemRaw.FinishFabricDeliveryQty = itemRaw.FinFabricBooking;
                    rawData.FinishFabric
                           .Where(c => c.OrderID == itemRaw.OrderID && c.PantoneNo == itemRaw.PantoneNo)
                           .First().FinishQty = finishedFabricQty - itemRaw.FinFabricBooking;
                }
                else
                {
                    itemRaw.FinishFabricDeliveryQty = finishedFabricQty;
                    if (finishData != null)
                        rawData.FinishFabric.Where(c => c.OrderID == itemRaw.OrderID && c.PantoneNo == itemRaw.PantoneNo).First().FinishQty = 0;
                }
                #endregion

                var ribData = rawData.FinishFabric.Where(c => c.OrderID == itemRaw.OrderID
                                                            && c.PantoneNo == itemRaw.PantoneNo
                                                            && c.RibQty > 0).FirstOrDefault();
                #region Rib
                var ribQty = ribData == null ? 0 : ribData.RibQty;
                if (ribQty > 0 && ribQty > itemRaw.RibBooking)
                {
                    itemRaw.RibQty = itemRaw.RibBooking;
                    rawData.FinishFabric
                           .Where(c => c.OrderID == itemRaw.OrderID && c.PantoneNo == itemRaw.PantoneNo)
                           .First().RibQty = ribQty - itemRaw.RibBooking;
                }
                else
                {
                    itemRaw.RibQty = ribQty;
                    if (ribData != null)
                        rawData.FinishFabric.Where(c => c.OrderID == itemRaw.OrderID && c.PantoneNo == itemRaw.PantoneNo).First().RibQty = 0;
                }

                #endregion

                itemRaw.FinishFabricDeliveryBal = itemRaw.FinishFabricDeliveryQty + itemRaw.RibQty - itemRaw.FinFabricBooking - itemRaw.RibBooking;
            }
            return rawData.FabricInfo;
        }

        public async Task<List<GarmentAssortmentAndFabricsInfoRM>> GetOrderWiseStatusReport(DateTime DateFrom, DateTime DateTo, int BuyerID, int OrderID)
        {
            var rawData = await GetGarmentAssortmentAndFabricsInfo(DateFrom, DateTo, BuyerID, OrderID);
            var calculatedData = rawData.Where(x => x.DeliveryDate >= DateFrom && x.DeliveryDate <= DateTo).ToList();

            var additionalData = await orderPlanReportsRepository.GetOrderAdditionalInfo(DateFrom, DateTo, BuyerID, OrderID);

            foreach (var itemData in calculatedData)
            {
                var batchCommitment = additionalData.BatchCommitment.Where(x => x.OrderID == itemData.OrderID).ToList();
                itemData.BatchCommitmentDateMsg = batchCommitment.Count > 0 ? batchCommitment.Max(x => x.CommitmentDate).ToString("dd-MMM-yyyy") : "";
                var artWork = additionalData.ArtWork.Where(x => x.OrderID == itemData.OrderID && x.PantoneNo == itemData.PantoneNo).FirstOrDefault();
                itemData.ArtWork = artWork == null ? "" : artWork.ArtWorkName;
                var dyeingUnit = additionalData.DyeingProductionLocation.Where(x => x.OrderID == itemData.OrderID).FirstOrDefault();
                itemData.DyeingProductionUnit = dyeingUnit == null ? "" : dyeingUnit.LocationName;

                var deliveryCommitment = additionalData.DeliveryCommitment.Where(x => x.OrderID == itemData.OrderID).ToList();
                itemData.DeliveryCommitmentDateMsg = deliveryCommitment.Count == 0 ? "" : deliveryCommitment.Max(x => x.CommitmentDate).ToString("dd-MMM-yyyy");
            }
            return calculatedData;
        }

        //public async Task<OrderStatusVM> GetPlannedOrderStatus(DateTime DateFrom, DateTime DateTo, int BuyerID, int OrderID = 0)
        //{
        //    return await orderPlanReportsRepository.GetPlannedOrderStatus(DateFrom, DateTo, BuyerID, OrderID);
        //}
        public async Task<List<GarmentAssortmentAndFabricsInfoRM>> GetPlannedOrderStatusReport(DateTime DateFrom, DateTime DateTo, int BuyerID, int OrderID = 0)
        {
            var rawData = await GetGarmentAssortmentAndFabricsInfo(DateFrom, DateTo, BuyerID, OrderID);
            var calculatedData = rawData.Where(x => x.DeliveryDate >= DateFrom && x.DeliveryDate <= DateTo).ToList();

            var additionalData = await orderPlanReportsRepository.GetOrderAdditionalInfo(DateFrom, DateTo, BuyerID, OrderID);

            foreach (var itemData in calculatedData)
            {
                var batchCommitment = additionalData.BatchCommitment.Where(x => x.OrderID == itemData.OrderID).ToList();
                itemData.BatchCommitmentDateMsg = batchCommitment.Count > 0 ? batchCommitment.Max(x => x.CommitmentDate).ToString("dd-MMM-yyyy") : "";
                var artWork = additionalData.ArtWork.Where(x => x.OrderID == itemData.OrderID && x.PantoneNo == itemData.PantoneNo).FirstOrDefault();
                itemData.ArtWork = artWork == null ? "" : artWork.ArtWorkName;
            }
            return calculatedData;
        }

        public async Task<List<GarmentAssortmentAndFabricsInfoRM>> GetWeekWiseStatusReport(DateTime DateFrom, DateTime DateTo, int BuyerID, int OrderID)
        {
            var rawData = await GetGarmentAssortmentAndFabricsInfo(DateFrom, DateTo, BuyerID, OrderID);
            var calculatedData = rawData.Where(x => x.DeliveryDate >= DateFrom && x.DeliveryDate <= DateTo).ToList();

            var additionalData = await orderPlanReportsRepository.GetOrderAdditionalInfo(DateFrom, DateTo, BuyerID, OrderID);

            foreach (var itemData in calculatedData)
            {
                var batchCommitment = additionalData.BatchCommitment.Where(x => x.OrderID == itemData.OrderID).ToList();
                itemData.BatchCommitmentDateMsg = batchCommitment.Count > 0 ? batchCommitment.Max(x => x.CommitmentDate).ToString("dd-MMM-yyyy") : "";
                var artWork = additionalData.ArtWork.Where(x => x.OrderID == itemData.OrderID && x.PantoneNo == itemData.PantoneNo).FirstOrDefault();
                itemData.ArtWork = artWork == null ? "" : artWork.ArtWorkName;
                var dyeingUnit = additionalData.DyeingProductionLocation.Where(x => x.OrderID == itemData.OrderID).FirstOrDefault();
                itemData.DyeingProductionUnit = dyeingUnit == null ? "" : dyeingUnit.LocationName;

                var deliveryCommitment = additionalData.DeliveryCommitment.Where(x => x.OrderID == itemData.OrderID).ToList();
                itemData.DeliveryCommitmentDateMsg = deliveryCommitment.Count == 0 ? "" : deliveryCommitment.Max(x => x.CommitmentDate).ToString("dd-MMM-yyyy");
            }
            return calculatedData;
        }

        public async Task<List<ArtWorkPlanRM>> GetPlanArtWorkReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken)
        {
            List<ArtWorkPlanRM> OrderArtWorkData = new List<ArtWorkPlanRM>();

            var planArtWork = await orderPlanReportsRepository.GetArtWorkPlanDaa(DateFrom, DateTo, BuyerID, OrderID, cancellationToken);
            var greigeFabricData = await orderPlanReportsRepository.GetPlan_OrderGreigeQuantityReport(DateFrom, DateTo, BuyerID, OrderID).ToListAsync(cancellationToken);
            var finishFabricQuery = orderPlanReportsRepository.GetPlan_OrderBatchAndFinishQuantityReport(DateFrom, DateTo, BuyerID, OrderID);

            var finisFabric = await (from fin in finishFabricQuery
                                     group fin by fin.OrderID into grp
                                     select new ArtWorkPlanRM
                                     {
                                         OrderID = grp.Key,
                                         BatchKg = grp.Sum(s => s.BatchQty),
                                         FinishFabricDeliveryKg = grp.Sum(s => s.FinishQty),
                                         RibQty = grp.Sum(s => s.RibQty),
                                         FinishFabricDeliveryBalanceKg = grp.Sum(s => s.FinishQty + s.RibQty),
                                     }).ToListAsync(cancellationToken);

            foreach (var d in planArtWork)
            {
                ArtWorkPlanRM singleData = new ArtWorkPlanRM();


                decimal planKnittingKg = d.OrderTotalArtWorkFinishKg + d.OrderTotalArtWorkFinishKg * d.WastagePercent / 100;
                var greigeFabricRow = greigeFabricData.Where(b => b.OrderID == d.OrderID).FirstOrDefault();
                var orderFinishFabricRow = finisFabric.Where(b => b.OrderID == d.OrderID).FirstOrDefault();

                singleData.FabricMonthSl = d.FabricMonthSl;
                singleData.FabricMonth = d.FabricMonth;
                singleData.Buyer = d.Buyer;
                singleData.BuyerID = d.BuyerID;
                singleData.OrderID = d.OrderID;
                singleData.ArtWork = d.ArtwarkName;
                singleData.OrderQty = (int)d.ArtQuantity;
                singleData.FinishFabricBookingKg = d.OrderTotalArtWorkFinishKg;
                singleData.PlanKnittingKg = planKnittingKg;

                if (greigeFabricRow != null && greigeFabricRow.GreigeQuantity > 0)
                {
                    if (greigeFabricRow.GreigeQuantity >= singleData.PlanKnittingKg)
                    {
                        singleData.KnittingKg = singleData.PlanKnittingKg;

                    }
                    else
                    {
                        singleData.KnittingKg = greigeFabricRow.GreigeQuantity;
                    }
                }
                else
                {
                    singleData.KnittingKg = 0;
                }
                /// update proeuce Greige Data.
                greigeFabricData.Where(w => w.OrderID == d.OrderID).ToList().ForEach(u => u.GreigeQuantity -= singleData.KnittingKg);

                singleData.KnittingBalanceKg = singleData.KnittingKg - singleData.PlanKnittingKg;

                ///Batch
                if (orderFinishFabricRow != null && orderFinishFabricRow.BatchKg > 0)
                {
                    if (orderFinishFabricRow.BatchKg >= singleData.KnittingKg)
                    {
                        singleData.BatchKg = singleData.KnittingKg;
                    }
                    else
                    {
                        singleData.BatchKg = orderFinishFabricRow.BatchKg;
                    }

                }
                else
                {
                    singleData.BatchKg = 0;
                }

                singleData.BatchBalance = singleData.BatchKg - singleData.KnittingKg;

                ///finish
                if (orderFinishFabricRow != null && orderFinishFabricRow.FinishFabricDeliveryKg > 0)
                {
                    if (orderFinishFabricRow.FinishFabricDeliveryKg >= d.OrderMainArtWorkFinishKg)
                    {
                        singleData.FinishFabricDeliveryKg = d.OrderMainArtWorkFinishKg;
                    }
                    else
                    {
                        singleData.FinishFabricDeliveryKg = orderFinishFabricRow.FinishFabricDeliveryKg;
                    }
                }
                else
                {
                    singleData.FinishFabricDeliveryKg = 0;
                }

                //Rib
                if (orderFinishFabricRow != null && orderFinishFabricRow.RibQty > 0)
                {
                    if (orderFinishFabricRow.RibQty >= d.OrderRibArtWorkFinishKg)
                    {
                        singleData.RibQty = d.OrderRibArtWorkFinishKg;
                    }
                    else
                    {
                        singleData.RibQty = orderFinishFabricRow.RibQty;
                    }


                }
                else
                {
                    singleData.RibQty = 0;
                }
                singleData.FinishFabricDeliveryBalanceKg = singleData.FinishFabricDeliveryKg + singleData.RibQty - singleData.FinishFabricBookingKg;

                //// Update Finish Fabric 
                finisFabric.Where(w => w.OrderID == d.OrderID)
                    .ToList()
                    .ForEach(u =>
                    {
                        u.BatchKg -= singleData.BatchKg;
                        u.FinishFabricDeliveryKg -= singleData.FinishFabricDeliveryKg;
                        u.RibQty -= singleData.RibQty;
                    });

                OrderArtWorkData.Add(singleData);
            }
            var rtnData = OrderArtWorkData
                .GroupBy(g => new { g.FabricMonthSl, g.FabricMonth, g.Buyer, g.BuyerID, g.ArtWork })
                .Select(s => new ArtWorkPlanRM()
                {
                    FabricMonthSl = s.Key.FabricMonthSl,
                    FabricMonth = s.Key.FabricMonth,
                    Buyer = s.Key.Buyer,
                    BuyerID = s.Key.BuyerID,
                    ArtWork = s.Key.ArtWork,
                    OrderQty = s.Sum(q => q.OrderQty),
                    FinishFabricBookingKg = s.Sum(k => k.FinishFabricBookingKg),
                    PlanKnittingKg = s.Sum(k => k.PlanKnittingKg),
                    KnittingKg = s.Sum(k => k.KnittingKg),
                    KnittingBalanceKg = s.Sum(k => k.KnittingBalanceKg),
                    BatchKg = s.Sum(k => k.BatchKg),
                    BatchBalance = s.Sum(k => k.BatchBalance),
                    FinishFabricDeliveryKg = s.Sum(k => k.FinishFabricDeliveryKg),
                    RibQty = s.Sum(k => k.RibQty),
                    FinishFabricDeliveryBalanceKg = s.Sum(k => k.FinishFabricDeliveryBalanceKg)
                })
                .OrderBy(o => o.FabricMonthSl)
                .ThenBy(t => t.BuyerID)
                .ToList();

            return rtnData;
        }
        public async Task Plan_GenerateReportData_Schedue()
        {
            await orderPlanReportsRepository.Plan_GenerateReportData_Schedue();
        }

        public async Task<List<DyeingUnitProductionFabricWeekRM>> GetDyeingProductionFinishFabricWeek(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken)
        {
            List<DyeingUnitProductionFabricWeekRM> OrderArtWorkData = new List<DyeingUnitProductionFabricWeekRM>();

            var planDyeingProduction = await orderPlanReportsRepository.GetDyeingProductionFinishFabricWeek(DateFrom, DateTo, BuyerID, OrderID, cancellationToken);

            var finishFabricQuery = orderPlanReportsRepository.GetPlan_OrderBatchAndFinishQuantityReport(DateFrom, DateTo, BuyerID, OrderID);

            var finisFabric = await (from fin in finishFabricQuery
                                     group fin by fin.OrderID into grp
                                     select new ArtWorkPlanRM
                                     {
                                         OrderID = grp.Key,
                                         BatchKg = grp.Sum(s => s.BatchQty),
                                         FinishFabricDeliveryKg = grp.Sum(s => s.FinishQty),
                                         RibQty = grp.Sum(s => s.RibQty),
                                         FinishFabricDeliveryBalanceKg = grp.Sum(s => s.FinishQty + s.RibQty),
                                     }).ToListAsync(cancellationToken);
            int sl = 0;
            foreach (var d in planDyeingProduction)
            {
                DyeingUnitProductionFabricWeekRM singleData = new DyeingUnitProductionFabricWeekRM();
                var orderFinishFabricRow = finisFabric.Where(b => b.OrderID == d.OrderID).FirstOrDefault();

                singleData.MonthSl = d.MonthSl;
                singleData.Buyer = d.Buyer;
                singleData.BuyerID = d.BuyerID;
                singleData.OrderID = d.OrderID;
                singleData.DyeingProductinUnit = d.DyeingProductinUnit;
                singleData.OrderQty = d.OrderQty;
                singleData.FabricWeek = d.FabricWeek;
                singleData.FabricBookingKg = d.FabricBookingKg;
                singleData.DyeingPlanKg = d.DyeingPlanKg;


                ///Batch


                ///finish
                if (orderFinishFabricRow != null && orderFinishFabricRow.FinishFabricDeliveryKg > 0)
                {
                    if (orderFinishFabricRow.FinishFabricDeliveryBalanceKg >= d.FabricBookingKg)
                    {
                        singleData.FinishedFabricKg = d.FabricBookingKg;
                    }
                    else
                    {
                        singleData.FinishedFabricKg = orderFinishFabricRow.FinishFabricDeliveryBalanceKg;
                    }
                }
                else
                {
                    singleData.FinishedFabricKg = 0;
                }



                //// Update Finish Fabric 
                finisFabric.Where(w => w.OrderID == d.OrderID)
                    .ToList()
                    .ForEach(u =>
                    {
                        u.FinishFabricDeliveryBalanceKg -= singleData.FinishedFabricKg;
                    });

                OrderArtWorkData.Add(singleData);
            }

            var rtnData = OrderArtWorkData
                .GroupBy(g => new { g.MonthSl, g.BuyerID, g.Buyer, g.FabricWeek, g.DyeingProductinUnit })
                .Select(s => new DyeingUnitProductionFabricWeekRM()
                {
                    MonthSl = s.Key.MonthSl,
                    Buyer = s.Key.Buyer,
                    BuyerID = s.Key.BuyerID,
                    FabricWeek = s.Key.FabricWeek,
                    DyeingProductinUnit = s.Key.DyeingProductinUnit,
                    OrderQty = s.Sum(q => q.OrderQty),
                    FabricBookingKg = s.Sum(k => k.FabricBookingKg),
                    DyeingPlanKg = s.Sum(k => k.DyeingPlanKg),
                    FinishedFabricKg = s.Sum(k => k.FinishedFabricKg),
                    PlanBalanceKg = s.Sum(k => k.FabricBookingKg - k.FinishedFabricKg)
                })
                .OrderBy(o => o.MonthSl)
                .ThenBy(o => o.FabricWeek)
                .ThenBy(t => t.BuyerID)
                .ToList();

            return rtnData;
        }

        public async Task<List<GreigeFabricPlanRM>> GetPlanGreigeFabricReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken)
        {
            return await orderPlanReportsRepository.GetPlanGreigeFabricReport(DateFrom, DateTo, BuyerID, OrderID, cancellationToken);
        }

        public async Task<List<PlanNewOrderRM>> PlanNewOrderReport(DateTime DateFrom, DateTime DateTo, int BuyerID, int OrderID, CancellationToken cancellationToken)
        {
            var returnList = new List<PlanNewOrderRM>();
            var rawData = await GetGarmentAssortmentAndFabricsInfo(DateFrom, DateTo, BuyerID, OrderID);
            //var calculatedData = rawData.Where(x => x.DeliveryDate >= DateFrom && x.DeliveryDate <= DateTo).ToList();

            var additionalData = await orderPlanReportsRepository.GetOrderAdditionalInfo(DateFrom, DateTo, BuyerID, OrderID);

            foreach (var row in rawData)
            {
                var newItem = new PlanNewOrderRM()
                {
                    BuyerID = row.BuyerID,
                    BuyerName = row.BuyerName,
                    OrderID = row.OrderID,
                    OrderNO = row.OrderName,
                    ShipmentMonth = row.FabricMonth,
                    ShipmentMonthSL = row.FabricMonthSl,
                    FabricWeek = row.FabricWeek,
                    PoReceivedDate = row.OrderReceiveDate,
                    ShipmentDate = row.DeliveryDate,
                    StyleName = row.StyleName,
                    ColorName = row.ColorName,
                    PantoneNo = row.PantoneNo,
                    FabricQuality = row.Quality,
                    GSM = row.GSM,
                    FinishedWidth = row.FinishedWidth,
                   ShipmentOrderQuantity = row.NumberofGarments,
                   FinishFabricBookingKg = row.FinFabricBooking,
                   PlanKnittingKg = row.PlanKnittingQty,
                   KnittingKG = row.KnittingQty,
                   KnittingBalance = row.KnittingBalance,
                   BatchKg = row.BatchQty,
                   BatchBalance = row.BatchBalance,
                   FinishFabricMain = row.FinishFabricDeliveryQty,
                   FinishFabricRib = row.RibQty,
                   FinishFabricBalance = row.FinishFabricDeliveryBal

                };

                var planKnitting = additionalData.DeliveryCommitment.Where(x => x.OrderID == row.OrderID).ToList();

                newItem.KnittingStartDate = planKnitting.Count == 0 ? null : planKnitting.Min(x => x.CommitmentDate);
                newItem.KnittingEndDate = planKnitting.Count == 0 ? null : planKnitting.Max(x => x.CommitmentDate);
                if (planKnitting.Count > 0)
                {
                    newItem.KnittingDuration =(int)(newItem.KnittingEndDate - newItem.KnittingStartDate).Value.TotalDays;
                }

                var batchCommitment = additionalData.BatchCommitment.Where(x => x.OrderID == row.OrderID).ToList();
                newItem.PlanBatchCommitmentDate = batchCommitment.Count > 0 ? batchCommitment.Max(x => x.CommitmentDate):null;
                var artWork = additionalData.ArtWork
                                            .Where(x => x.OrderID == row.OrderID && x.PantoneNo == row.PantoneNo&& x.ArtWorkDate == row.DeliveryDate)
                                            .FirstOrDefault();
                newItem.ArtWorkName = artWork == null ? "" : artWork.ArtWorkName;

                var dyeingUnit = additionalData.DyeingProductionLocation.Where(x => x.OrderID == row.OrderID &&  x.ProductionDate==row.DeliveryDate).FirstOrDefault();
                newItem.PlanDyeingProductionUnit = dyeingUnit == null ? "" : dyeingUnit.LocationName;

                var deliveryCommitment = additionalData.DeliveryCommitment.Where(x => x.OrderID == row.OrderID).ToList();

                newItem.PlanFabricDeliveryStartDate = deliveryCommitment.Count == 0 ? null : deliveryCommitment.Min(x => x.CommitmentDate);
                newItem.PlanFabricDeliveryEndDate = deliveryCommitment.Count == 0 ? null : deliveryCommitment.Max(x => x.CommitmentDate);

                returnList.Add(newItem);
                 
            }
            return returnList;
        }

        public async Task<List<DailyBatchRM>> GetDailyBatchReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken)
        {
            return await orderPlanReportsRepository.GetDailyBatchReport(DateFrom, DateTo, BuyerID, OrderID, cancellationToken);
        }

        public async Task<List<FinishFabricDeliveryRM>> GetDailyFinishFabricDeliveryReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken)
        {
            return await orderPlanReportsRepository.GetDailyFinishFabricDeliveryReport(DateFrom, DateTo, BuyerID, OrderID, cancellationToken);
        }

        public async Task<List<FabricFloorStatusRM>> GetFabricFloorStatusReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken)
        {
            return await orderPlanReportsRepository.GetFabricFloorStatusReport(DateFrom, DateTo, BuyerID, OrderID, cancellationToken);
        }

        public async Task<List<DailyPrintProductionRM>> GetDailyPrintProductionSummeryReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken)
        {
            return await orderPlanReportsRepository.GetDailyPrintProductionSummeryReport(DateFrom, DateTo, BuyerID, OrderID, cancellationToken);
        }

        public async Task<List<PlanUsedFabricCuttingSectionRM>> GetUsedFabricCuttingSection(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken)
        {
            return await orderPlanReportsRepository.GetUsedFabricCuttingSection(DateFrom, DateTo,  BuyerID,  OrderID,cancellationToken);
        }

        public async Task<List<ManagementStatusRM>> GetManagementStatusReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken)
        {
            var data= await orderPlanReportsRepository.GetManagementStatusReport(DateFrom, DateTo, BuyerID, OrderID, cancellationToken);

            //var returnData = data.GroupBy(x =>  x.StatusDate )
            //    .Select(n => new ManagementStatusRM
            //    {
            //        StatusDate=n.Key,
            //        KnittingInhouse=n.Sum(g=>g.KnittingInhouse),
            //        KnittingOutSide=n.Sum(g=>g.KnittingOutSide),

            //        BatchAOP=n.Sum(g=>g.BatchAOP),
            //        BatchCPB = n.Sum(g => g.BatchCPB),
            //        BatchCBL = n.Sum(g => g.BatchCBL),

            //        DyeingAOP=n.Sum(x=>x.DyeingAOP),
            //        DyeingCPB = n.Sum(x => x.DyeingCPB),
            //        DyeingCBL = n.Sum(x => x.DyeingCBL),

            //        AdditionalReq=n.Sum(x=>x.AdditionalReq),
            //        AdditionalIssue = n.Sum(x => x.AdditionalIssue),
            //        AdditionalUtilized = n.Sum(x => x.AdditionalUtilized),
            //        FabricUtilized = n.Sum(x => x.FabricUtilized),

            //        GarmentsCutting=n.Sum(x=>x.GarmentsCutting),
            //        GarmentsSewing = n.Sum(x => x.GarmentsSewing),
            //        //GarmentsCutting = n.Sum(x => x.GarmentsCutting),
            //        GarmentsShipment = n.Sum(x => x.GarmentsShipment),
            //        GarmentsEfficiency=n.Sum(x => x.GarmentsEfficiency)

            //    }).OrderBy(x=>x.StatusDate).ToList();
            //return returnData;
            return data;
        }
    }
}
