using RG.Application.Common.Models;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
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
    public class IC_ReturnableRecieveGatePassDetailRepository : GenericRepository<IC_ReturnableRecieveGatePassDetail>, IIC_ReturnableRecieveGatePassDetailRepository
    {
        private readonly MaterialsManagementDBContext dbCon;

        public IC_ReturnableRecieveGatePassDetailRepository(MaterialsManagementDBContext _dbCon) : base(_dbCon)
        {
            dbCon = _dbCon;
        }
        public async Task<RResult> SaveReturnableRecieveGatePassDetail(List<IC_ReturnableRecieveGatePassDetail> entity, CancellationToken cancellationToken)
        {
            RResult rResult = new RResult();
            try
            {
                await dbCon.IC_ReturnableRecieveGatePassDetail.AddRangeAsync(entity);
                await dbCon.SaveChangesAsync(cancellationToken);
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return rResult;
        }
    }
}
