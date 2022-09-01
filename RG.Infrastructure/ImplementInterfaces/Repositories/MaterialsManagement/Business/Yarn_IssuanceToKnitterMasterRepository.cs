using RG.Application.Common.Models;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
using RG.DBEntities.MaterialsManagement.Business;
using RG.Infrastructure.Persistence.MaterialsManagementDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.MaterialsManagement.Business
{
    public class Yarn_IssuanceToKnitterMasterRepository : GenericRepository<Yarn_IssuanceToKnitterMaster>, IYarn_IssuanceToKnitterMasterRepository
    {
        private readonly MaterialsManagementDBContext dbCon;

        public Yarn_IssuanceToKnitterMasterRepository(MaterialsManagementDBContext _dbCon) : base(_dbCon)
        {
            dbCon = _dbCon;
        }

        public async Task<RResult> Yarn_IssuanceToKnitterMasterSave(Yarn_IssuanceToKnitterMaster entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
