using AutoMapper;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Business;
using RG.DBEntities.FiniteScheduler.Business;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.Business
{
    public class DFS_ConfirmationMasterRepository : GenericRepository<DFS_ConfirmationMaster>, IDFS_ConfirmationMasterRepository
    {
        private readonly FiniteSchedulerDBContext dbCon;
        private readonly IMapper mapper;
        public DFS_ConfirmationMasterRepository(FiniteSchedulerDBContext context, IMapper mapper)
            : base(context)
        {
            dbCon = context;
            this.mapper = mapper;
        }
     /*   public async Task<RResult> SaveDFS_ConfirmationMaster(DFS_ConfirmationMasterViewModel ConfirmationMaster, int createdBy, bool saveChanges = true)
        {
            RResult rResult = new RResult();
            try
            {
                var model = mapper.Map<DFS_ConfirmationMasterViewModel, DFS_ConfirmationMaster>(ConfirmationMaster);
                model.STATUS = 0;
                //model.IsActive = true;
                //model.IsRemoved = false;
                //model.CreatedBy = createdBy;
                //model.CreatedDate = DateTime.Now;
                dbCon.DFS_ConfirmationMaster.Add(model);
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
