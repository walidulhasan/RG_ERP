using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
    public class DFS_IssuanceMasterRepository : GenericRepository<DFS_IssuanceMaster>, IDFS_IssuanceMasterRepository
    {
        private FiniteSchedulerDBContext dbCon;
        private readonly IMapper mapper;
        public DFS_IssuanceMasterRepository(FiniteSchedulerDBContext context, IMapper mapper)
            : base(context)
        {
            dbCon = context;
            this.mapper = mapper;
        }
        /*
        public async Task<List<DyeingIssuance_ChallansViewModel>> Get_All_DyeingIssuance_Challans(DateTime? DateFrom = null, DateTime? DateTo = null)
        {
            List<DyeingIssuance_ChallansViewModel> dyeingIssuance = new List<DyeingIssuance_ChallansViewModel>();
            try
            {

                await dbCon.LoadStoredProc("ajt.usp_Get_All_DyeingIssuance_Challans")
                .WithSqlParam("DateFrom", DateFrom)
                .WithSqlParam("DateTo", DateTo)
                .ExecuteStoredProcAsync((handler) =>
                {
                    dyeingIssuance = handler.ReadToList<DyeingIssuance_ChallansViewModel>() as List<DyeingIssuance_ChallansViewModel>;
                });
            }
            catch (Exception e)
            {
                // var dd = this.Test();

                throw new Exception(e.Message);
            }
            return dyeingIssuance;
        }

        public async Task<DyeingRollDetailsViewModel> Get_Dyeing_Roll_details_On_ChallanID(long IssuanceID)
        {
            DyeingRollDetailsViewModel Dyeing_Roll = new DyeingRollDetailsViewModel();
            List<ReadJsonSP> readJsonData = new List<ReadJsonSP>();
            try
            {

                await dbCon.LoadStoredProc("ajt.usp_Get_Dyeing_Roll_details_On_ChallanID")
                .WithSqlParam("IssuanceID", IssuanceID)
                .ExecuteStoredProcAsync((handler) =>
                {
                    readJsonData = handler.ReadToList<ReadJsonSP>() as List<ReadJsonSP>;
                });
                Dyeing_Roll = JsonConvert.DeserializeObject<DyeingRollDetailsViewModel>(readJsonData.FirstOrDefault().Result);
            }
            catch (Exception e)
            {
                // var dd = this.Test();

                throw new Exception(e.Message);
            }
            return Dyeing_Roll; ;
        }
        */
        public async Task<RResult> UpdateReceivedStatus(long IssuanceID,bool ReceivedStatus, int CreateBy)
        {
            RResult rResult = new RResult();
            try
            {
                var issuance = await dbCon.DFS_IssuanceMaster.FindAsync(IssuanceID);
                issuance.isReceived = ReceivedStatus;
                //issuance.UpdatedBy = CreateBy;
                //issuance.UpdatedDate = DateTime.Now;
                await this.UpdateAsync(issuance, true);
                rResult.result = 1;
                rResult.message = "";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rResult;
        }
        

        public async Task<List<SelectListItem>> DDLLotListForIssuance()
        {
            List<SelectListItem> lotList = new List<SelectListItem>();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GetAllLotForIssuance")
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

        public async Task<List<SelectListItem>> DDLDCListForIssuance(int LotId)
        {
            List<SelectListItem> lotList = new List<SelectListItem>();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GetAllDCForIssuance")
                     .WithSqlParam("LotId", LotId)
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

        public async Task<string> GetLotDetailForIssuance(int lotId)
        {
            ReadJsonSP returnStr = new ReadJsonSP();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GetLotDetailForIssuance")
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

     /*   public async Task<RResult> SaveDFS_IssuanceMaster(DFS_IssuanceMasterViewModel lotIssuanceMaster, int createdBy, bool saveChanges = true)
        {
            RResult rResult = new RResult();
            try
            {
                var model = mapper.Map<DFS_IssuanceMasterViewModel, DFS_IssuanceMaster>(lotIssuanceMaster);
                
                model.UserID = createdBy;
                model.IssuanceDate = DateTime.Now;
                model.isReceived = false;
                //model.IsActive = true;
                //model.IsRemoved = false;
                //model.CreatedBy = createdBy;
                //model.CreatedDate = DateTime.Now;
                dbCon.DFS_IssuanceMaster.Add(model);
                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;
                rResult.longId = model.ID;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rResult;
        }
        */
    }
}
