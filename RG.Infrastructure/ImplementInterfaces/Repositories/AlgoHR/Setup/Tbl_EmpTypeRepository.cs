using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.DBEntities.AlgoHR.Setup;
using RG.Infrastructure.Persistence.AlgoHRDB;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Setup
{
    public class Tbl_EmpTypeRepository : GenericRepository<Tbl_EmpType>, ITbl_EmpTypeRepository
    {
        private readonly AlgoHRDBContext _dbCon;

        public Tbl_EmpTypeRepository(AlgoHRDBContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }
    }
}
