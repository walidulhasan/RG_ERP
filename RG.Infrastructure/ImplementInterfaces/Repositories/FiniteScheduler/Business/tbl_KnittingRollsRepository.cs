using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Enums;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Business;
using RG.DBEntities.FiniteScheduler.Business;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.Business
{
    public class tbl_KnittingRollsRepository : GenericRepository<tbl_KnittingRolls>, Itbl_KnittingRollsRepository
    {
        private readonly FiniteSchedulerDBContext dbCon;
        private readonly IMapper mapper;
        public tbl_KnittingRollsRepository(FiniteSchedulerDBContext context, IMapper mapper)
            : base(context)
        {
            dbCon = context;
            this.mapper = mapper;
        }

        public async Task<List<SelectListItem>> DDLRollsForPermanentReceivingByYKNC(long YKNCId)
        {
            var rollList = new List<SelectListItem>();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GetDDLRollsForPermanentReceivingByYKNC")
                .WithSqlParam("YKNCId", YKNCId)
                .ExecuteStoredProcAsync((handler) =>
                {
                    rollList = handler.ReadToList<SelectListItem>() as List<SelectListItem>;
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rollList;
        }
        /*
        public async Task<CommonDataPass> GetKnitterCompanyIdByRollCode(string rollCode)
        {
            CommonDataPass KnitterCompany = new CommonDataPass();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GetKnitterCompanyIdByRollCode")
                .WithSqlParam("RollCode", rollCode)
                .ExecuteStoredProcAsync((handler) =>
                {
                    KnitterCompany = handler.ReadToList<CommonDataPass>().First();
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return KnitterCompany;



            //CommonDataPass KnitterCompany = new CommonDataPass();
            //try
            //{
            //    KnitterCompany = await(from kr in dbCon.tbl_KnittingRolls
            //                           join kj in dbCon.tbl_KnittingJobs on kr.JobId equals kj.JobId
            //                           join ykncm in dbCon.YarnKnittingContractMaster on kj.YarnKnittingContractId equals ykncm.YarnKNContractId
            //                           where (kr.IsActive == true && kr.IsRemoved == false && kj.IsActive == true && kj.IsRemoved == false && ykncm.IsActive == true && ykncm.IsRemoved == false)
            //                           select new CommonDataPass
            //                           {
            //                               DefaultItem = ykncm.KnitterId,
            //                               Id = ykncm.KnitterCompanyId.Value
            //                           }).FirstAsync();

            //}
            //catch (Exception e)
            //{
            //    throw new Exception(e.Message);
            //}
            //return KnitterCompany;
        }
        
        public async Task<List<tbl_KnittingRollsViewModel>> GetKnittingRollsByJobId(int jobId)
        {
            var rollList = new List<tbl_KnittingRollsViewModel>();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GetKnittingRollsByJobId")
                .WithSqlParam("JobId", jobId)
                .ExecuteStoredProcAsync((handler) =>
                {
                    rollList = handler.ReadToList<tbl_KnittingRollsViewModel>() as List<tbl_KnittingRollsViewModel>;
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rollList;
        }
        public async Task<List<tbl_KnittingRollsViewModel>> GetKnittingRollsForInspection(int jobID)
        {
            var rList = new List<tbl_KnittingRollsViewModel>();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GetKnittingRollsForInspectionByJobId")
               .WithSqlParam("JobID", jobID)
               .ExecuteStoredProcAsync((handler) =>
               {
                   rList = handler.ReadToList<tbl_KnittingRollsViewModel>() as List<tbl_KnittingRollsViewModel>;
               });

            }
            catch (Exception)
            {
                throw;
            }
            return rList;
        }
        public async Task<List<tbl_KnittingRollsViewModel>> GetKnittingRollsForInspection(List<tbl_KnittingRollsViewModel> rollList)
        {
            var rList = new List<tbl_KnittingRollsViewModel>();
            try
            {
                var rollListJson = JsonConvert.SerializeObject(rollList);
                await dbCon.LoadStoredProc("ajt.usp_GetKnittingRollsForInspection")
               .WithSqlParam("rollListJson", rollListJson)
               .ExecuteStoredProcAsync((handler) =>
               {
                   rList = handler.ReadToList<tbl_KnittingRollsViewModel>() as List<tbl_KnittingRollsViewModel>;
               });

            }
            catch (Exception)
            {
                throw;
            }
            return rList;
        }

        public async Task<RResult> SaveTemporaryGateReceiving(List<tbl_KnittingRollsViewModel> KnittingRolls, int JobId, int createdBy, bool saveChanges = true)
        {
            RResult rResult = new RResult();
            try
            {
                var jobConfirmation = new tbl_KnittingJobConfirmation()
                {
                    JobID = JobId,
                    ConfirmationDate = DateTime.Now                    
                };
                dbCon.tbl_KnittingJobConfirmation.Add(jobConfirmation);
                await dbCon.SaveChangesAsync();
                if (jobConfirmation.ConfirmationID > 0)
                {
                    var maxRoleCode = await GetMaxRoleCode(JobId);
                    var ykncId = KnittingRolls[0].YKNC;

                    var knittingRollsList = mapper.Map<List<tbl_KnittingRollsViewModel>, List<tbl_KnittingRolls>>(KnittingRolls);
                    var knittingRollsID = (await GetTableMaxId("RollID", "long", "FiniteScheduler.dbo.tbl_KnittingRolls")).longID;
                    knittingRollsList.ForEach(x =>
                    {
                        x.RollID = ++knittingRollsID;
                        x.RollCode = GenerateAutoRollCode(ykncId, maxRoleCode, x.RollNo);
                        x.QualityID = 1;//default in db                         
                        x.RollCreationDate = DateTime.Now;                      

                        x.tbl_KnittingStockTransaction.DocumentTypeID = (int)enum_KnittingDocumentType.RollCreation_JobConfirmation;
                        x.tbl_KnittingStockTransaction.DocumentNo = jobConfirmation.ConfirmationID;                        
                    });

                    dbCon.tbl_KnittingRolls.AddRange(knittingRollsList);
                    await dbCon.SaveChangesAsync();
                }
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;
            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = ReturnMessage.ErrorMessage;
                throw new Exception(e.Message);
            }
            return rResult;
        }
    
        public async Task<RResult> UpdateWihlePermanentReceiving(List<Greige_StockTransactionsViewModel> greigeStockTransactions, int createdBy)
        {
            RResult rResult = new RResult();
            try
            {
                foreach (var roll in greigeStockTransactions)
                {
                    long rollID = Convert.ToInt64(roll.RollID);
                    var knittingRoll = await GetByIdAsync(rollID);//dbCon.tbl_KnittingRolls.Where(x => x.RollID == roll.RollID).First();
                    var updatedRoll = knittingRoll;
                    updatedRoll.Status = 5;                    
                    dbCon.Entry(knittingRoll).CurrentValues.SetValues(updatedRoll);
                }
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
        */
        private string GenerateAutoRollCode(long ykncId, int maxRoleCode, int rollNo)
        {
            var newRollCode = ykncId.ToString() + "-" + Convert.ToString((int)enum_KnittingMachineNo.MachineNo) + "-" + (maxRoleCode + rollNo).ToString().PadLeft(5, '0');
            return newRollCode;
        }
        private async Task<int> GetMaxRoleCode(int jobId)
        {
            SelectListItem maxRoleCode = new SelectListItem();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GetMaxRoleCode")
                .WithSqlParam("JobId", jobId)
                .ExecuteStoredProcAsync((handler) =>
                {
                    maxRoleCode = handler.ReadToList<SelectListItem>().First();
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return Convert.ToInt32(maxRoleCode.Value);
        }
        /*  public async Task<List<tbl_KnittingStockTransactionViewModel>> GetKnittingRollsDetailSpecification(List<PassingString> rollCodeList)
          {
              var rollDetailList = new List<tbl_KnittingStockTransactionViewModel>();
              try
              {
                  var rollListJson = JsonConvert.SerializeObject(rollCodeList);
                  await dbCon.LoadStoredProc("ajt.usp_GetKnittingRollsDetailSpecification")
                 .WithSqlParam("rollListJson", rollListJson)
                 .ExecuteStoredProcAsync((handler) =>
                 {
                     rollDetailList = handler.ReadToList<tbl_KnittingStockTransactionViewModel>() as List<tbl_KnittingStockTransactionViewModel>;
                 });

              }
              catch (Exception)
              {
                  throw;
              }
              return rollDetailList;
          }
        */


    }
}
