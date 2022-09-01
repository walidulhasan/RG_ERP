using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.DBEntities.AlgoHR.Business;
using RG.Infrastructure.Persistence.AlgoHRDB;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Business
{
    public class TrainingDocumentsRepository : GenericRepository<TrainingDocuments>, ITrainingDocumentsRepository
    {
        private AlgoHRDBContext dbCon;
        public TrainingDocumentsRepository(AlgoHRDBContext context)
            : base(context)
        {
            dbCon = context;

        }
    }
}
