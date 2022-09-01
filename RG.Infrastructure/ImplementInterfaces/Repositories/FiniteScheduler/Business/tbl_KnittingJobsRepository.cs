using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Enums;
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
    public class tbl_KnittingJobsRepository : GenericRepository<tbl_KnittingJobs>, Itbl_KnittingJobsRepository
    {
        private FiniteSchedulerDBContext dbCon;
        private readonly IMapper mapper;
        public tbl_KnittingJobsRepository(FiniteSchedulerDBContext context, IMapper mapper)
            : base(context)
        {
            dbCon = context;
            this.mapper = mapper;
        }
        public async Task<List<SelectListItem>> DDLKnittingJobsByYKNC(long ykncId)
        {
            try
            {
                var jobList = await FindAllAsync(b =>  b.YarnKnittingContractID == ykncId);//b.IsRemoved == false && b.IsActive == true &&
                var list = jobList.Select(row => new SelectListItem
                {
                    Text = row.JobName,
                    Value = row.JobID.ToString()
                }).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
     /*   public async Task<tbl_KnittingJobsViewModel> GetKnittingJobByYKNCId(long ykncId)
        {
            tbl_KnittingJobsViewModel knittingJobs = new tbl_KnittingJobsViewModel();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GetKnittingJobByYKNCId")
                .WithSqlParam("YarnKnittingContractId", ykncId)
                .ExecuteStoredProcAsync((handler) =>
                {
                    knittingJobs = handler.ReadToList<tbl_KnittingJobsViewModel>().FirstOrDefault() as tbl_KnittingJobsViewModel;
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return knittingJobs;
        }
        public async Task<tbl_KnittingJobsViewModel> GetKnittingJobMachineAssociate(int jobId)
        {
            tbl_KnittingJobsViewModel knittingJobs = new tbl_KnittingJobsViewModel();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GetKnittingJobMachineAssociate")
                .WithSqlParam("JobId", Convert.ToInt64(jobId))
                .ExecuteStoredProcAsync((handler) =>
                {
                    knittingJobs = handler.ReadToList<tbl_KnittingJobsViewModel>().FirstOrDefault() as tbl_KnittingJobsViewModel;
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return knittingJobs;
        }
      */  public async Task<RResult> tbl_KnittingJobsSave(tbl_KnittingJobs entity)
        {
            RResult rResult = new RResult();
            try
            {
                await dbCon.AddAsync(entity);
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

        public async Task<RResult> Updatetbl_KnittingJobsStatusToCompleted(int jobId)
        {
            RResult rResult = new RResult();
               var data = from kj in dbCon.tbl_KnittingJobs
                       join st in dbCon.tbl_KnittingStockTransaction on kj.JobID equals st.JobID
                       where st.DocumentTypeID == (int)enum_KnittingDocumentType.RollCreation_JobConfirmation
                       select new { kj.JobID, kj.Quantity, st.RollWeight };

            var _newData = from od in data
                           group od by new { od.JobID, od.Quantity } into gData
                           select new { RemainingBalance=gData.Key.Quantity - gData.Sum(b => b.RollWeight) };
            var Balance = (await _newData.ToListAsync()).FirstOrDefault();
            if (Balance!=null && Balance.RemainingBalance<=0)
            {
                var job = await GetByIdAsync(jobId);
                job.JobStatusID = 5;
                await UpdateAsync(job,true);                
            }

            return rResult;
        }
    }
}
