using RG.Application.Interfaces.Repositories.FiniteScheduler.Business;
using RG.DBEntities.FiniteScheduler.Business;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.Business
{
    public class TempAssetRepository : GenericRepository<TempAsset>, ITempAssetRepository
    {
        private readonly FiniteSchedulerDBContext _dbCon;
        public TempAssetRepository(FiniteSchedulerDBContext context):base(context)
        {
            _dbCon = context;
        }
    }
}
