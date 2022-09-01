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
    public class DFS_InspectionMasterRepository : GenericRepository<DFS_InspectionMaster>, IDFS_InspectionMasterRepository
    {
        private FiniteSchedulerDBContext dbCon;
        private readonly IMapper mapper;
        public DFS_InspectionMasterRepository(FiniteSchedulerDBContext context, IMapper mapper)
            : base(context)
        {
            dbCon = context;
            this.mapper = mapper;
        }
    /*    public async Task<RResult> SaveDFS_InspectionMaster(DFS_InspectionMasterViewModel dfsLotInspectionMaster, int createdBy, bool saveChanges = true)
        {
            RResult rResult = new RResult();
            try
            {
                var model = mapper.Map<DFS_InspectionMasterViewModel, DFS_InspectionMaster>(dfsLotInspectionMaster);
                model.InspectionDate = DateTime.Now;
                model.UserID = createdBy;
                //model.IsActive = true;
                //model.IsRemoved = false;
                //model.CreatedBy = createdBy;
                //model.CreatedDate = DateTime.Now;
                dbCon.DFS_InspectionMaster.Add(model);
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
