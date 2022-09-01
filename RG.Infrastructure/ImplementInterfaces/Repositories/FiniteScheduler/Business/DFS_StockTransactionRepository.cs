using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Business;
using RG.DBEntities.FiniteScheduler.Business;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;
using RG.Application.Common.Models;
using RG.Application.Enums;
using RG.Application.Contracts.FiniteScheduler.Business.DFS_StockTransactions.Queries.RequestResponseModel;
using Snickler.EFCore;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.Business
{
    public class DFS_StockTransactionRepository : GenericRepository<DFS_StockTransaction>, IDFS_StockTransactionRepository
    {
        private FiniteSchedulerDBContext dbCon;
        private readonly IMapper mapper;
        public DFS_StockTransactionRepository(FiniteSchedulerDBContext context, IMapper mapper)
            : base(context)
        {
            dbCon = context;
            this.mapper = mapper;
        }
        /*   public Task<RResult> SaveDFSStockTransaction(DFS_StockTransactionViewModel dfsStockTransaction, int createdBy, bool saveChanges = true)
           {
               throw new NotImplementedException();
           }

           public async Task<RResult> SaveDFSStockTransaction(List<DFS_StockTransactionViewModel> dfsStockTransaction, int createdBy, bool saveChanges = true)
           {
               RResult rResult = new RResult();
               try
               {
                   var dfsStockTransactionEntity = mapper.Map<List<DFS_StockTransactionViewModel>, List<DFS_StockTransaction>>(dfsStockTransaction);
                   //dfsStockTransactionEntity.ForEach(x => { x.IsActive = true; x.IsRemoved = false; x.CreatedBy = createdBy; x.CreatedDate = DateTime.Now; });

                   dbCon.DFS_StockTransaction.AddRange(dfsStockTransactionEntity);
                   await dbCon.SaveChangesAsync();
                   rResult.result = 1;
                   rResult.message = ReturnMessage.InsertMessage;
               }
               catch (Exception e)
               {
                   throw new Exception(e.Message);
               }
               return rResult;
           }
           */
        public async Task<RResult> GetFabricQuantityAndPantoneByLotID(long LotID)
        {
            RResult returnObj = await (from lmm in dbCon.DFS_LotMakingMaster
                                       join dst in dbCon.DFS_StockTransaction on lmm.ID equals dst.DocumentNo
                                       where dst.DocumentNo == LotID && dst.DocumentTypeID == (long)enum_LotGenerationDocumentType.Lot_Making
                                       group dst by new { dst.PantoneNo } into g
                                       select new RResult
                                       {
                                           data = new
                                           {
                                               PantoneNo = g.Key.PantoneNo.Trim(),
                                               FabricQuantity = g.Sum(dst => dst.Quantity)
                                           },
                                           result = 1

                                       }).FirstOrDefaultAsync();
            return returnObj;
        }

        public async Task<OrderWiseFabricStatusAndLotInfoSVM> GetDailyOrderFabricWastageExceededLot(DateTime? CurrentDate = null)
        {

            var fabric = new List<OrderFabricInfo>();
            var lotList = new List<OrderLotInfo>();

            var returnList = new OrderWiseFabricStatusAndLotInfoSVM();
            try
            {
                await dbCon.LoadStoredProc("rpt.USP_DailyOrderFabricWastageExceededLot")
                               .WithSqlParam("ReportDate", CurrentDate)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 fabric = handler.ReadToList<OrderFabricInfo>() as List<OrderFabricInfo>;
                                 handler.NextResultAsync();
                                 lotList = handler.ReadToList<OrderLotInfo>() as List<OrderLotInfo>;
                             });

                foreach (var fab in fabric)
                {
                    var lotItem = lotList.Where(b => b.OrderID==fab.OrderID && b.FabricComposition == fab.FabricComposition 
                                                && b.FabricType == fab.FabricType
                                      && b.FabricQuality == fab.FabricQuality && b.WestagePercent>fab.GWS_PERCENTAGE).ToList();
                    if (lotItem.Count > 0)
                    {
                        fab.FabricLot.AddRange(lotItem);
                    }
                    if (fab.FabricLot.Count() > 0)
                    {
                        returnList.OrderFabrincWithLot.Add(fab);
                    }
                } 

                return returnList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
