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
    public class DFS_InspectionNewAttribute_SetupRepository : GenericRepository<DFS_InspectionNewAttribute_Setup>, IDFS_InspectionNewAttribute_SetupRepository
    {
        private readonly FiniteSchedulerDBContext dbCon;
        private readonly IMapper mapper;
        public DFS_InspectionNewAttribute_SetupRepository(FiniteSchedulerDBContext context, IMapper mapper)
            : base(context)
        {
            dbCon = context;
            this.mapper = mapper;
        }
    /*    public async Task<RResult> SaveDFS_InspectionNewAttribute_Setup(DFS_InspectionNewAttribute_SetupViewModel dfsInspectionNewAttribute, int createdBy, bool saveChanges = true)
        {
            RResult rResult = new RResult();
            try
            {
                var entity = mapper.Map<DFS_InspectionNewAttribute_SetupViewModel, DFS_InspectionNewAttribute_Setup>(dfsInspectionNewAttribute);
                //entity.IsActive = true;
                //entity.IsRemoved = false;
                //entity.CreatedBy = createdBy;
                //entity.CreatedDate = DateTime.Now;

                dbCon.DFS_InspectionNewAttribute_Setup.Add(entity);
                await dbCon.SaveChangesAsync();
                rResult.result =1;
                rResult.message =ReturnMessage.InsertMessage;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rResult;
        }

        public async Task<RResult> SaveDFS_InspectionNewAttribute_Setup(List<DFS_InspectionNewAttribute_SetupViewModel> dfsInspectionNewAttribute, int createdBy, bool saveChanges = true)
        {
            RResult rResult = new RResult();
            try
            {
                var entityList = mapper.Map<List<DFS_InspectionNewAttribute_SetupViewModel>,List< DFS_InspectionNewAttribute_Setup>>(dfsInspectionNewAttribute);
                //entityList.ForEach(x => { x.IsActive = true; x.IsRemoved = false; x.CreatedDate = DateTime.Now; x.CreatedBy = createdBy; });
                dbCon.DFS_InspectionNewAttribute_Setup.AddRange(entityList);
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
