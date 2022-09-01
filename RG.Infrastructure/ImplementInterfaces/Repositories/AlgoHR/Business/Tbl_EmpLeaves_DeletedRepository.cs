using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.DBEntities.AlgoHR.Business;
using RG.Infrastructure.Persistence.AlgoHRDB;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Business
{
    public class Tbl_EmpLeaves_DeletedRepository : GenericRepository<Tbl_EmpLeaves_Deleted>, ITbl_EmpLeaves_DeletedRepository
    {
        private readonly AlgoHRDBContext dbCon;

        public Tbl_EmpLeaves_DeletedRepository(AlgoHRDBContext context)
            : base(context)
        {
            dbCon = context;
        }
    }
}
