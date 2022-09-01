using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.DBEntities.AlgoHR.Setup;
using RG.Infrastructure.Persistence.AlgoHRDB;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Setup
{
    public class Tbl_ShiftRepository : GenericRepository<tbl_Shift>, Itbl_ShiftRepository
    {
        private readonly AlgoHRDBContext _dbCon;

        public Tbl_ShiftRepository(AlgoHRDBContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }
    }
}
