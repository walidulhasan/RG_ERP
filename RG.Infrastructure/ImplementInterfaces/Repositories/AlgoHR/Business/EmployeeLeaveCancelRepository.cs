using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.DBEntities.AlgoHR.Business;
using RG.Infrastructure.Persistence.AlgoHRDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Business
{
    public class EmployeeLeaveCancelRepository:GenericRepository<EmployeeLeaveCancel>, IEmployeeLeaveCancelRepository
    {
        private readonly AlgoHRDBContext _dbCon;

        public EmployeeLeaveCancelRepository(AlgoHRDBContext dbCon):base(dbCon)
        {
            _dbCon = dbCon;
        }
    }
}
