using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.DBEntities.AlgoHR.Business;
using RG.Infrastructure.Persistence.AlgoHRDB;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Business
{
    public class KPIParticularValuesRepository : GenericRepository<KPIParticularValues>, IKPIParticularValuesRepository
    {
        private AlgoHRDBContext dbCon;
        public KPIParticularValuesRepository(AlgoHRDBContext context)
            : base(context)
        {
            dbCon = context;

        }
    }
}
