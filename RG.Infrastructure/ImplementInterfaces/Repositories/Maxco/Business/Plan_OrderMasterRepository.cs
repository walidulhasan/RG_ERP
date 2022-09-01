using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.Buisness.Plan_OrderMasters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Maxco.Business;
using RG.DBEntities.Maxco.Business;
using RG.Infrastructure.Persistence.MaxcoDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Maxco.Business
{
    public class Plan_OrderMasterRepository : GenericRepository<Plan_OrderMaster>, IPlan_OrderMasterRepository
    {
        private readonly MaxcoDBContext dbCon;
        public Plan_OrderMasterRepository(MaxcoDBContext _dbCon) : base(_dbCon)
        {
            dbCon = _dbCon;
        }

        public async Task<List<SelectListItem>> DDLBuyerWisePlanOrders(int BuyerID, bool? IsOrderClosed, string Predict = null, CancellationToken cancellationToken = default)
        {
            var query = dbCon.Plan_OrderMaster.Where(x => x.IsActive == true && x.IsRemoved == false);
            if (IsOrderClosed.HasValue)
            {
                IQueryable<Plan_OrderFollowup> followupQuery;
                if (IsOrderClosed.Value)
                    followupQuery = dbCon.Plan_OrderFollowup.Where(x => x.IsActive == true && x.IsRemoved == false && x.IsOrderClosed == true);
                else
                    followupQuery = dbCon.Plan_OrderFollowup.Where(x => x.IsActive == true && x.IsRemoved == false && x.IsOrderClosed == false);

                query = from q in query
                        join f in followupQuery on q.OrderID equals f.OrderID
                        select q;
            }
            var data = await (from q in query
                              join o in dbCon.Style on q.OrderID equals o.ID
                              join c in dbCon.Collection on o.CollectionID equals c.ID
                              join b in dbCon.Buyer_Setup on c.BuyerID equals b.ID
                              where b.ID==BuyerID && (Predict == null || o.OrderNo.Trim().Contains(Predict))
                              select new SelectListItem
                              {
                                  Text = o.OrderNo.Trim(),
                                  Value = o.ID.ToString()
                              }).Distinct().ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<SelectListItem>> DDLPlanOrders(bool? IsOrderClosed, string Predict = null, CancellationToken cancellationToken = default)
        {
            var query = dbCon.Plan_OrderMaster.Where(x => x.IsActive == true && x.IsRemoved == false);
            if (IsOrderClosed.HasValue)
            {
                IQueryable<Plan_OrderFollowup> followupQuery;
                if (IsOrderClosed.Value)
                    followupQuery = dbCon.Plan_OrderFollowup.Where(x => x.IsActive == true && x.IsRemoved == false && x.IsOrderClosed == true);
                else
                    followupQuery = dbCon.Plan_OrderFollowup.Where(x => x.IsActive == true && x.IsRemoved == false && x.IsOrderClosed == false);

                query = from q in query
                        join f in followupQuery on q.OrderID equals f.OrderID
                        select q;
            }
            var data = await (from q in query
                              join o in dbCon.Style on q.OrderID equals o.ID
                              where Predict == null || o.OrderNo.Trim().Contains(Predict)
                              select new SelectListItem {
                                  Text = o.OrderNo.Trim(),
                                  Value = o.ID.ToString()
                              }).Distinct().ToListAsync(cancellationToken);
            return data;
        }

        public async Task<Plan_OrderMaster> GetOrderPlanningVersionDetail(int orderID, int planVersionID)
        {
            try
            {
                Plan_OrderMaster orderMaster = new();
                orderMaster = await dbCon.Plan_OrderMaster.Where(x => x.OrderID == orderID & x.IsActive == true && x.IsRemoved == false).FirstOrDefaultAsync();
                orderMaster.Plan_Versions= await dbCon.Plan_Versions.Where(x => x.PlanVersionID==planVersionID && x.IsActive == true && x.IsRemoved == false).ToListAsync();
                
                foreach (var item in orderMaster.Plan_Versions)
                {
                    item.Plan_StyleFabrics= await dbCon.Plan_StyleFabrics.Where(y => y.PlanVersionID == item.PlanVersionID & y.IsActive == true && y.IsRemoved == false).ToListAsync();
                    foreach (var itemStyle in item.Plan_StyleFabrics)
                    {
                        itemStyle.Plan_Knitting= await dbCon.Plan_Knitting.Where(y => y.StyleFabricsID == itemStyle.StyleFabricsID & y.IsActive == true && y.IsRemoved == false).ToListAsync();
                        itemStyle.Plan_FabricBatchCommitment = await dbCon.Plan_FabricBatchCommitment.Where(y => y.StyleFabricsID == itemStyle.StyleFabricsID & y.IsActive == true && y.IsRemoved == false).ToListAsync();
                        itemStyle.Plan_FabricArtWork = await dbCon.Plan_FabricArtWork.Where(y => y.StyleFabricsID == itemStyle.StyleFabricsID & y.IsActive == true && y.IsRemoved == false).ToListAsync();

                        itemStyle.Plan_FabricDeliveryCommitment = await dbCon.Plan_FabricDeliveryCommitment.Where(y => y.StyleFabricsID == itemStyle.StyleFabricsID & y.IsActive == true && y.IsRemoved == false).ToListAsync();
                        itemStyle.Plan_DyeingProduction = await dbCon.Plan_DyeingProduction.Where(y => y.StyleFabricsID == itemStyle.StyleFabricsID & y.IsActive == true && y.IsRemoved == false).ToListAsync();
                        itemStyle.Plan_Cutting = await dbCon.Plan_Cutting.Where(y => y.StyleFabricsID == itemStyle.StyleFabricsID & y.IsActive == true && y.IsRemoved == false).ToListAsync();

                        itemStyle.Plan_Sewing = await dbCon.Plan_Sewing.Where(y => y.StyleFabricsID == itemStyle.StyleFabricsID & y.IsActive == true && y.IsRemoved == false).ToListAsync();
                        itemStyle.Plan_FinishFabric = await dbCon.Plan_FinishFabric.Where(y => y.StyleFabricsID == itemStyle.StyleFabricsID & y.IsActive == true && y.IsRemoved == false).ToListAsync();
                        itemStyle.Plan_Shipment = await dbCon.Plan_Shipment.Where(y => y.StyleFabricsID == itemStyle.StyleFabricsID & y.IsActive == true && y.IsRemoved == false).ToListAsync();
                    }
                }


                //var data =await (dbCon.Plan_OrderMaster
                //            .Where(x => x.OrderID == orderID)

                //            .Include(plan => plan.Plan_Versions.Where(x => x.PlanVersionID == planVersionID))
                //                .ThenInclude(fabric => fabric.Plan_StyleFabrics.Where(x => x.PlanVersionID == planVersionID))
                //                    .ThenInclude(x => x.Plan_FabricBatchCommitment.Where(x => x.IsActive == true && x.IsRemoved == false))

                //            .Include(plan => plan.Plan_Versions.Where(x => x.PlanVersionID == planVersionID))
                //                .ThenInclude(fabric => fabric.Plan_StyleFabrics.Where(x => x.PlanVersionID == planVersionID))
                //                    .ThenInclude(x => x.Plan_FabricArtWork.Where(x => x.IsActive == true && x.IsRemoved == false))

                //             .Include(plan => plan.Plan_Versions.Where(x => x.PlanVersionID == planVersionID))
                //                .ThenInclude(fabric => fabric.Plan_StyleFabrics.Where(x => x.PlanVersionID == planVersionID))
                //                    .ThenInclude(x => x.Plan_FabricDeliveryCommitment.Where(x => x.IsActive == true && x.IsRemoved == false))

                //             .Include(plan => plan.Plan_Versions.Where(x => x.PlanVersionID == planVersionID))
                //                .ThenInclude(fabric => fabric.Plan_StyleFabrics.Where(x => x.PlanVersionID == planVersionID))
                //                    .ThenInclude(x => x.Plan_DyeingProduction.Where(x => x.IsActive == true && x.IsRemoved == false))

                //             .Include(plan => plan.Plan_Versions.Where(x => x.PlanVersionID == planVersionID))
                //                .ThenInclude(fabric => fabric.Plan_StyleFabrics.Where(x => x.PlanVersionID == planVersionID))
                //                    .ThenInclude(x => x.Plan_Cutting.Where(x => x.IsActive == true && x.IsRemoved == false))

                //                         .Include(plan => plan.Plan_Versions.Where(x => x.PlanVersionID == planVersionID))
                //                .ThenInclude(fabric => fabric.Plan_StyleFabrics.Where(x => x.PlanVersionID == planVersionID))
                //                    .ThenInclude(x => x.Plan_Sewing.Where(x => x.IsActive == true && x.IsRemoved == false))

                //                    .Include(plan => plan.Plan_Versions.Where(x => x.PlanVersionID == planVersionID))
                //                .ThenInclude(fabric => fabric.Plan_StyleFabrics.Where(x => x.PlanVersionID == planVersionID))
                //                    .ThenInclude(x => x.Plan_Knitting.Where(x => x.IsActive == true && x.IsRemoved == false))

                //                    .Include(plan => plan.Plan_Versions.Where(x => x.PlanVersionID == planVersionID))
                //                .ThenInclude(fabric => fabric.Plan_StyleFabrics.Where(x => x.PlanVersionID == planVersionID))
                //                    .ThenInclude(x => x.Plan_FinishFabric.Where(x => x.IsActive == true && x.IsRemoved == false))

                //                    .Include(plan => plan.Plan_Versions.Where(x => x.PlanVersionID == planVersionID))
                //                .ThenInclude(fabric => fabric.Plan_StyleFabrics.Where(x => x.PlanVersionID == planVersionID))
                //                    .ThenInclude(x => x.Plan_Shipment.Where(x => x.IsActive == true && x.IsRemoved == false))
                //            ).ToQueryString();
                //var a = data.ToQueryString();
                //.FirstOrDefaultAsync();
                return orderMaster;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<List<PlanOrderDetailInfoRM>> GetPlanOrderDetailInfo(int orderID, CancellationToken cancellationToken)
        {
            List<PlanOrderDetailInfoRM> orderStyles = new();
            List<OrderDeliveryInfoRM> OrderDeliveryInfo = new();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GetPlanOrderDetailInfo")
                    .WithSqlParam("OrderID", orderID)
                                  .ExecuteStoredProcAsync((handler) =>
                                  {
                                      orderStyles = handler.ReadToList<PlanOrderDetailInfoRM>() as List<PlanOrderDetailInfoRM>;
                                      handler.NextResult();
                                      OrderDeliveryInfo= handler.ReadToList<OrderDeliveryInfoRM>() as List<OrderDeliveryInfoRM>;
                                  });

                orderStyles.ForEach(x => x.OrderDeliveryInfo = OrderDeliveryInfo.Where(y => y.StyleID == x.StyleID && y.PantoneNo == x.PantoneNo).ToList());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orderStyles;
        }

        public async Task<RResult> PlanOrderMasterNewVersion(Plan_Versions entity)
        {
            RResult rResult = new RResult();
            try
            {

                await dbCon.Plan_Versions.AddAsync(entity);
                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;
                return rResult;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<RResult> PlanOrderMasterSave(Plan_OrderMaster entity)
        {
            RResult rResult = new RResult();
            try
            {
                
                    await dbCon.Plan_OrderMaster.AddAsync(entity);
                    await dbCon.SaveChangesAsync();
                    rResult.result = 1;
                    rResult.message = ReturnMessage.InsertMessage;
                    return rResult;
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<RResult> PlanOrderMasterUpdate(Plan_OrderMaster entity)
        {
            RResult rResult = new RResult();
            try
            {
                var dbEntity = await GetOrderPlanningVersionDetail(entity.OrderID, entity.Plan_Versions.First().PlanVersionID);
                dbEntity.OrderReceiveDate = entity.OrderReceiveDate;
                // Delete children
                foreach (var detail in dbEntity.Plan_Versions.First().Plan_StyleFabrics)
                {
                    var updatedStyleFabric = entity.Plan_Versions.First().Plan_StyleFabrics.Where(x => x.FabricSL == detail.FabricSL).First();
                    foreach (var itemFabricBatch in detail.Plan_FabricBatchCommitment)
                    {
                        if (!updatedStyleFabric.Plan_FabricBatchCommitment.Any(c => c.FabricBatchCommitmentID == itemFabricBatch.FabricBatchCommitmentID))
                        {
                            itemFabricBatch.IsRemoved = true;
                            dbCon.Update(itemFabricBatch);
                        }
                    }
                    foreach (var itemFabricArt in detail.Plan_FabricArtWork)
                    {
                        if (!updatedStyleFabric.Plan_FabricArtWork.Any(c => c.FabricArtWorkID == itemFabricArt.FabricArtWorkID))
                        {
                            itemFabricArt.IsRemoved = true;
                            dbCon.Update(itemFabricArt);
                        }
                    }
                    foreach (var itemFabricDelivery in detail.Plan_FabricDeliveryCommitment)
                    {
                        if (!updatedStyleFabric.Plan_FabricDeliveryCommitment.Any(c => c.FabricDeliveryCommitmentID == itemFabricDelivery.FabricDeliveryCommitmentID))
                        {
                            itemFabricDelivery.IsRemoved = true;
                            dbCon.Update(itemFabricDelivery);
                        }
                    }

                    foreach (var itemCutting in detail.Plan_Cutting)
                    {
                        if (!updatedStyleFabric.Plan_Cutting.Any(c => c.CuttingID == itemCutting.CuttingID))
                        {
                            itemCutting.IsRemoved = true;
                            dbCon.Update(itemCutting);
                        }
                    }
                    foreach (var itemSewing in detail.Plan_Sewing)
                    {
                        if (!updatedStyleFabric.Plan_Sewing.Any(c => c.SewingID == itemSewing.SewingID))
                        {
                            itemSewing.IsRemoved = true;
                            dbCon.Update(itemSewing);
                        }
                    }
                    foreach (var itemKnitting in detail.Plan_Knitting)
                    {
                        if (!updatedStyleFabric.Plan_Knitting.Any(c => c.KnittingID == itemKnitting.KnittingID))
                        {
                            itemKnitting.IsRemoved = true;
                            dbCon.Update(itemKnitting);
                        }
                    }

                    foreach (var itemDyeing in detail.Plan_DyeingProduction)
                    {
                        if (!updatedStyleFabric.Plan_DyeingProduction.Any(c => c.DyeingProductionID == itemDyeing.DyeingProductionID))
                        {
                            itemDyeing.IsRemoved = true;
                            dbCon.Update(itemDyeing);
                        }
                    }
                    foreach (var itemFinish in detail.Plan_FinishFabric)
                    {
                        if (!updatedStyleFabric.Plan_FinishFabric.Any(c => c.FinishFabricID == itemFinish.FinishFabricID))
                        {
                            itemFinish.IsRemoved = true;
                            dbCon.Update(itemFinish);
                        }
                    }
                    foreach (var itemShipping in detail.Plan_Shipment)
                    {
                        if (!updatedStyleFabric.Plan_Shipment.Any(c => c.ShipmentID == itemShipping.ShipmentID))
                        {
                            itemShipping.IsRemoved = true;
                            dbCon.Update(itemShipping);
                        }
                    }
                }

                foreach (var detail in entity.Plan_Versions.First().Plan_StyleFabrics)
                {
                    var dbStyleFabrics = dbEntity.Plan_Versions.First().Plan_StyleFabrics.Where(x => x.FabricSL == detail.FabricSL).First();

                    //Update and Insert children
                    foreach (var itemFabricBatch in detail.Plan_FabricBatchCommitment)
                    {
                        var existingChild = dbStyleFabrics.Plan_FabricBatchCommitment
                            .Where(c => c.FabricBatchCommitmentID == itemFabricBatch.FabricBatchCommitmentID).FirstOrDefault();
                        // Update child
                        if (existingChild != null)
                        {
                            existingChild.CommitmentDate = itemFabricBatch.CommitmentDate;
                            existingChild.CommitmentQuantity = itemFabricBatch.CommitmentQuantity;
                            dbCon.Update(existingChild);
                        }
                        else
                        {
                            itemFabricBatch.StyleFabricsID = dbStyleFabrics.StyleFabricsID;
                            dbCon.Add(itemFabricBatch);
                        }
                    }
                    foreach (var itemArtWork in detail.Plan_FabricArtWork)
                    {
                        var existingChild = dbStyleFabrics.Plan_FabricArtWork
                            .Where(c => c.FabricArtWorkID == itemArtWork.FabricArtWorkID).FirstOrDefault();
                        // Update child
                        if (existingChild != null)
                        {
                            existingChild.ArtWorkID = itemArtWork.ArtWorkID;
                            existingChild.ArtWorkQuantity = itemArtWork.ArtWorkQuantity;
                            dbCon.Update(existingChild);
                        }
                        else
                        {
                            itemArtWork.StyleFabricsID = dbStyleFabrics.StyleFabricsID;
                            dbCon.Add(itemArtWork);
                        }
                    }
                    foreach (var itemFabricDelivery in detail.Plan_FabricDeliveryCommitment)
                    {
                        var existingChild = dbStyleFabrics.Plan_FabricDeliveryCommitment
                            .Where(c => c.FabricDeliveryCommitmentID == itemFabricDelivery.FabricDeliveryCommitmentID).FirstOrDefault();
                        // Update child
                        if (existingChild != null)
                        {
                            existingChild.CommitmentDate = itemFabricDelivery.CommitmentDate;
                            existingChild.CommitmentQuantity = itemFabricDelivery.CommitmentQuantity;
                            dbCon.Update(existingChild);
                        }
                        else
                        {
                            itemFabricDelivery.StyleFabricsID = dbStyleFabrics.StyleFabricsID;
                            dbCon.Add(itemFabricDelivery);
                        }
                    }

                    foreach (var itemDyeing in detail.Plan_DyeingProduction)
                    {
                        var existingChild = dbStyleFabrics.Plan_DyeingProduction
                            .Where(c => c.DyeingProductionID == itemDyeing.DyeingProductionID).FirstOrDefault();
                        // Update child
                        if (existingChild != null)
                        {
                            existingChild.ProductionUnit = itemDyeing.ProductionUnit;
                            existingChild.ProductionQuantity = itemDyeing.ProductionQuantity;
                            dbCon.Update(existingChild);
                        }
                        else
                        {
                            itemDyeing.StyleFabricsID = dbStyleFabrics.StyleFabricsID;
                            dbCon.Add(itemDyeing);
                        }
                    }
                    foreach (var itemCutting in detail.Plan_Cutting)
                    {
                        var existingChild = dbStyleFabrics.Plan_Cutting
                            .Where(c => c.CuttingID == itemCutting.CuttingID).FirstOrDefault();
                        // Update child
                        if (existingChild != null)
                        {
                            existingChild.CuttingDate = itemCutting.CuttingDate;
                            existingChild.CuttingQuantity = itemCutting.CuttingQuantity;
                            dbCon.Update(existingChild);
                        }
                        else
                        {
                            itemCutting.StyleFabricsID = dbStyleFabrics.StyleFabricsID;
                            dbCon.Add(itemCutting);
                        }
                    }
                    foreach (var itemSewing in detail.Plan_Sewing)
                    {
                        var existingChild = dbStyleFabrics.Plan_Sewing
                            .Where(c => c.SewingID == itemSewing.SewingID).FirstOrDefault();
                        // Update child
                        if (existingChild != null)
                        {
                            existingChild.SewingDate = itemSewing.SewingDate;
                            existingChild.SewingQuantity = itemSewing.SewingQuantity;
                            dbCon.Update(existingChild);
                        }
                        else
                        {
                            itemSewing.StyleFabricsID = dbStyleFabrics.StyleFabricsID;
                            dbCon.Add(itemSewing);
                        }
                    }

                    foreach (var itemKnitting in detail.Plan_Knitting)
                    {
                        var existingChild = dbStyleFabrics.Plan_Knitting
                            .Where(c => c.KnittingID == itemKnitting.KnittingID).FirstOrDefault();
                        // Update child
                        if (existingChild != null)
                        {
                            existingChild.KnittingDate = itemKnitting.KnittingDate;
                            existingChild.KnittingQuantity = itemKnitting.KnittingQuantity;
                            dbCon.Update(existingChild);
                        }
                        else
                        {
                            itemKnitting.StyleFabricsID = dbStyleFabrics.StyleFabricsID;
                            dbCon.Add(itemKnitting);
                        }
                    }
                    foreach (var itemFinish in detail.Plan_FinishFabric)
                    {
                        var existingChild = dbStyleFabrics.Plan_FinishFabric
                            .Where(c => c.FinishFabricID == itemFinish.FinishFabricID).FirstOrDefault();
                        // Update child
                        if (existingChild != null)
                        {
                            existingChild.FinishFabricDate = itemFinish.FinishFabricDate;
                            existingChild.FinishFabricQuantity = itemFinish.FinishFabricQuantity;
                            dbCon.Update(existingChild);
                        }
                        else
                        {
                            itemFinish.StyleFabricsID = dbStyleFabrics.StyleFabricsID;
                            dbCon.Add(itemFinish);
                        }
                    }
                    foreach (var itemShipment in detail.Plan_Shipment)
                    {
                        var existingChild = dbStyleFabrics.Plan_Shipment
                            .Where(c => c.ShipmentID == itemShipment.ShipmentID).FirstOrDefault();
                        // Update child
                        if (existingChild != null)
                        {
                            existingChild.ShipmentDate = itemShipment.ShipmentDate;
                            existingChild.ShipmentQuantity = itemShipment.ShipmentQuantity;
                            dbCon.Update(existingChild);
                        }
                        else
                        {
                            itemShipment.StyleFabricsID = dbStyleFabrics.StyleFabricsID;
                            dbCon.Add(itemShipment);
                        }
                    }
                }
                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.UpdateMessage;
                return rResult;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
