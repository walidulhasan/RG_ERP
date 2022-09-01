using RG.Application.Interfaces.Repositories.FiniteScheduler.DbViews;
using RG.DBEntities.FiniteScheduler.DBViews;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.DbViews
{
    public class VW_BuildingInfoRepository : GenericRepository<VW_BuildingInfo>, IVW_BuildingInfoRepository
    {
        private readonly FiniteSchedulerDBContext _dbCon;
        public VW_BuildingInfoRepository(FiniteSchedulerDBContext context)
        : base(context)
        {
            _dbCon = context;
        }
    }
}
