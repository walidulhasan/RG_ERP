using AutoMapper;
using System;
using System.Threading.Tasks;

using RG.Application.Interfaces.Repositories.FiniteScheduler.Business;
using RG.DBEntities.FiniteScheduler.Business;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.Business
{
    public class DFS_ReceivingMasterRepository : GenericRepository<DFS_ReceivingMaster>, IDFS_ReceivingMasterRepository
    {
        private FiniteSchedulerDBContext dbCon;
        private readonly IMapper mapper;
        public DFS_ReceivingMasterRepository(FiniteSchedulerDBContext context, IMapper mapper)
            : base(context)
        {
            dbCon = context;
            this.mapper = mapper;
        }
     
        /*public async Task<RResult> SaveDFSReceivingMaster(DFS_ReceivingMasterViewModel dfsReceivingMaster, int createdBy, bool saveChanges = true)
        {
            RResult rResult = new RResult();
            try
            {
                var dfsReceivingMasterEntity = mapper.Map<DFS_ReceivingMasterViewModel, DFS_ReceivingMaster>(dfsReceivingMaster);
                dfsReceivingMasterEntity.ReceivingDate = DateTime.Now;
                //dfsReceivingMasterEntity.IsActive = true;
                //dfsReceivingMasterEntity.IsRemoved = false;
                //dfsReceivingMasterEntity.CreatedBy = createdBy;
                //dfsReceivingMasterEntity.CreatedDate = DateTime.Now;
                //dfsReceivingMasterEntity.DFSReturnRolls.ToList().ForEach(x => { x.ReturnDate = DateTime.Now; x.IsActive = true; x.IsRemoved = false; x.CreatedBy = createdBy; x.CreatedDate = DateTime.Now; });


                dbCon.DFS_ReceivingMaster.Add(dfsReceivingMasterEntity);
                await dbCon.SaveChangesAsync();

                rResult.result = 1;
                rResult.longId = dfsReceivingMasterEntity.ID;
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
        */
    }
}
