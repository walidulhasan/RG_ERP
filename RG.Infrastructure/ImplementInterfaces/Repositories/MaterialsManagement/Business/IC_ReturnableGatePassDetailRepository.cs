using RG.Application.Common.Models;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using RG.DBEntities.MaterialsManagement.Business;
using RG.Infrastructure.Persistence.MaterialsManagementDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.MaterialsManagement.Business
{
    public class IC_ReturnableGatePassDetailRepository : GenericRepository<IC_ReturnableGatePassDetail>, IIC_ReturnableGatePassDetailRepository
    {
        private readonly MaterialsManagementDBContext dbCon;

        public IC_ReturnableGatePassDetailRepository(MaterialsManagementDBContext _dbCon) : base(_dbCon)
        {
            dbCon = _dbCon;
        }

        public async Task<RResult> UpdateIC_ReturnableGatePassDetail(IC_ReturnableGatePassDetail entity, CancellationToken cancellationToken)
        {
            RResult rResult = new RResult();
            dbCon.IC_ReturnableGatePassDetail.Update(entity);
            await dbCon.SaveChangesAsync(cancellationToken);
            rResult.result = 1;
            rResult.message = ReturnMessage.UpdateMessage;
            return rResult;
        }
    }
}
