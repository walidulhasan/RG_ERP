using AutoMapper;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Business;
using RG.DBEntities.FiniteScheduler.Business;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.Business
{
    public class tbl_KnittingSubPickListDetailRepository : GenericRepository<tbl_KnittingSubPickListDetail>, Itbl_KnittingSubPickListDetailRepository
    {
        private FiniteSchedulerDBContext dbCon;
        private readonly IMapper mapper;
        public tbl_KnittingSubPickListDetailRepository(FiniteSchedulerDBContext context, IMapper mapper)
            : base(context)
        {
            dbCon = context;
            this.mapper = mapper;
        }

        /*
        public async Task<List<tbl_KnittingSubPickListDetailViewModel>> PickListQuantityByJobId(int jobId)
        {
            List<tbl_KnittingSubPickListDetailViewModel> pickListQty = new List<tbl_KnittingSubPickListDetailViewModel>();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GetPickListQuantityByJob")
                .WithSqlParam("JobId", jobId)
                .ExecuteStoredProcAsync((handler) =>
                {
                    pickListQty = handler.ReadToList<tbl_KnittingSubPickListDetailViewModel>() as List<tbl_KnittingSubPickListDetailViewModel>;
                });

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return pickListQty;
        }
        */
    }
}