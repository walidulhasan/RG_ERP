using AutoMapper;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Business;
using RG.DBEntities.FiniteScheduler.Business;
using RG.Infrastructure.ImplementInterfaces.Repositories;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.FiniteScheduler
{
    public class DFS_Return_RollsRepositor : GenericRepository<DFS_Return_Rolls>, IDFS_Return_RollsRepository
    {
        private readonly FiniteSchedulerDBContext dbCon;
        private readonly IMapper mapper;
        public DFS_Return_RollsRepositor(FiniteSchedulerDBContext context, IMapper mapper)
          : base(context)
        {
            dbCon = context;
            this.mapper = mapper;
        }
     /*   public async Task<RResult> SaveDFS_Return_RollsList(List<DFS_Return_RollsViewModel> dFS_Return_Rolls, int createdBy)
        {
            RResult rResult = new RResult();
            try
            {
                var entityList = mapper.Map<List<DFS_Return_RollsViewModel>, List<DFS_Return_Rolls>>(dFS_Return_Rolls);
                entityList.ForEach(x => { x.Return_Date = DateTime.Now; });//x.IsActive = true; x.IsRemoved = false; x.CreatedBy = createdBy; x.CreatedDate = DateTime.Now;
                dbCon.DFS_Return_Rolls.AddRange(entityList);
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
    }
}
