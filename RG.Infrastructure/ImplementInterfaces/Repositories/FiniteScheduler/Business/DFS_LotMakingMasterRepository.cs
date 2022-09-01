using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Business;
using RG.DBEntities.FiniteScheduler.Business;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.Business
{
    public class DFS_LotMakingMasterRepository : GenericRepository<DFS_LotMakingMaster>, IDFS_LotMakingMasterRepository
    {
        private readonly FiniteSchedulerDBContext dbCon;
        private readonly IMapper mapper;
        public DFS_LotMakingMasterRepository(FiniteSchedulerDBContext context, IMapper mapper)
            : base(context)
        {
            dbCon = context;
            this.mapper = mapper;
        }
        public async Task<List<SelectListItem>> DDLLotListForConfirmation()
        {
            List<SelectListItem> lotList = new List<SelectListItem>();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GetAllLotForConfirmation")
                .ExecuteStoredProcAsync((handler) =>
                {
                    lotList = handler.ReadToList<SelectListItem>() as List<SelectListItem>;
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lotList;
        }
        public async Task<string> GetLotDetailForConfirmation(int lotId)
        {
            ReadJsonSP returnStr = new ReadJsonSP();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GetLotDetailForConfirmation")
                .WithSqlParam("LotId", lotId)
                .ExecuteStoredProcAsync((handler) =>
                {
                    returnStr = handler.ReadToList<ReadJsonSP>().First() as ReadJsonSP;
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return returnStr.Result;
        }
        public async Task<string> GetLotDetailForInspection(int lotId)
        {
            ReadJsonSP returnStr = new ReadJsonSP();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GetLotDetailForInspection")
                .WithSqlParam("LotId", lotId)
                .ExecuteStoredProcAsync((handler) =>
                {
                    returnStr = handler.ReadToList<ReadJsonSP>().First() as ReadJsonSP;
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return returnStr.Result;
        }
     /*   public async Task<RResult> SaveDFSLotMakingMaster(DFS_LotMakingMasterViewModel dfsLotMakingMaster, int createdBy, bool saveChanges = true)
        {
            RResult rResult = new RResult();
            try
            {
                if (! await IsDuplicateLot(dfsLotMakingMaster.LotNo)) {
                    var lotMakingMasterEntity = mapper.Map<DFS_LotMakingMasterViewModel, DFS_LotMakingMaster>(dfsLotMakingMaster);
                    lotMakingMasterEntity.Status = false;
                    lotMakingMasterEntity.CreationDate = DateTime.Now;
                    lotMakingMasterEntity.UserID = createdBy;
                    //lotMakingMasterEntity.IsActive = true;
                    //lotMakingMasterEntity.IsRemoved = false;
                    //lotMakingMasterEntity.CreatedBy = createdBy;
                    //lotMakingMasterEntity.CreatedDate = DateTime.Now;
                    //lotMakingMasterEntity.DFS_DCAssociationforLot.IsActive = true;
                    //lotMakingMasterEntity.DFS_DCAssociationforLot.IsRemoved = false;
                    //lotMakingMasterEntity.DFS_DCAssociationforLot.CreatedBy = createdBy;
                    //lotMakingMasterEntity.DFS_DCAssociationforLot.CreatedDate = DateTime.Now;

                    dbCon.DFS_LotMakingMaster.Add(lotMakingMasterEntity);
                    await dbCon.SaveChangesAsync();

                    var dfsStockTransaction = mapper.Map<List<DFS_StockTransactionViewModel>, List<DFS_StockTransaction>>(dfsLotMakingMaster.DFS_StockTransaction);
                    dfsStockTransaction.ForEach(x => { x.DocumentTypeID = (int)enum_KnittingDocumentType.LabTest; x.DocumentNo = lotMakingMasterEntity.ID; });//x.IsActive = true; x.IsRemoved = false; x.CreatedBy = createdBy; x.CreatedDate = DateTime.Now;
                    dbCon.DFS_StockTransaction.AddRange(dfsStockTransaction);
                    await dbCon.SaveChangesAsync();
                    rResult.result = 1;
                    rResult.message = ReturnMessage.InsertMessage;
                }
                else
                {
                    rResult.result = 0;
                    rResult.message = "Lot No Already Exists";
                }

            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = ReturnMessage.ErrorMessage;
                throw new Exception(e.Message);
            }
            return rResult;
        }
        public async Task<RResult> UpdateDuringLotConfirmation(DFS_LotMakingMasterViewModel lotMakingMaster, int createdBy, bool saveChanges)
        {
            RResult rResult = new RResult();
            try
            {
                var entity = await GetByIdAsync(lotMakingMaster.ID);
                var updatedEntity = entity;
                updatedEntity.HeatSetTemp = lotMakingMaster.HeatSetTemp;
                updatedEntity.HeatSetSpeed = lotMakingMaster.HeatSetSpeed;
                updatedEntity.HeatSetOverFeed = lotMakingMaster.HeatSetOverFeed;
                updatedEntity.HeatSetBlowSpeed = lotMakingMaster.HeatSetBlowSpeed;

                updatedEntity.FinishSetTemp = lotMakingMaster.FinishSetTemp;
                updatedEntity.FinishSetSpeed = lotMakingMaster.FinishSetSpeed;
                updatedEntity.FinishSetOverFeed = lotMakingMaster.FinishSetOverFeed;

                updatedEntity.CompactorTemp = lotMakingMaster.CompactorTemp;
                updatedEntity.CompactorSpeed = lotMakingMaster.CompactorSpeed;
                updatedEntity.CompactorOverFeed = lotMakingMaster.CompactorOverFeed;

                //updatedEntity.UpdatedBy = createdBy;
                //updatedEntity.UpdatedDate = DateTime.Now;
                dbCon.Entry(entity).CurrentValues.SetValues(updatedEntity);
                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.UpdateMessage;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rResult;
        }
      */  public async Task<List<SelectListItem>> DDLLotListForInspection()
        {
            List<SelectListItem> lotList = new List<SelectListItem>();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GetAllLotForInspection")
                .ExecuteStoredProcAsync((handler) =>
                {
                    lotList = handler.ReadToList<SelectListItem>() as List<SelectListItem>;
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lotList;
        }

        public async Task<List<SelectListItem>> DDLLotListByDCID(long dcid)
        {
            var lotList = await (from lmm in dbCon.DFS_LotMakingMaster
                                 join st in dbCon.DFS_StockTransaction on lmm.ID equals st.DocumentNo
                                 where st.DCID==dcid && st.DocumentTypeID==2
                                 select new SelectListItem
                                 {
                                     Text = lmm.LotNo,
                                     Value = lmm.ID.ToString()
                                 }).Distinct().ToListAsync();
            return lotList;
        }

        public async Task<bool> IsDuplicateLot(string lotNo)
        {
            var data = await dbCon.DFS_LotMakingMaster.Where(x => x.LotNo.Trim() == lotNo).ToListAsync();
            if (data.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
