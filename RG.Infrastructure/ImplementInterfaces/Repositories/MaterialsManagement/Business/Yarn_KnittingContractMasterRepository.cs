using Microsoft.EntityFrameworkCore;
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
    public class Yarn_KnittingContractMasterRepository : GenericRepository<Yarn_KnittingContractMaster>, IYarn_KnittingContractMasterRepository
    {
        private readonly MaterialsManagementDBContext _dbCon;
        public Yarn_KnittingContractMasterRepository(MaterialsManagementDBContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }

        public async Task<Yarn_KnittingContractMaster> GetYarn_KnittingContractMaster(long YarnKNContractID, CancellationToken cancellationToken = default)
        {
            var data = await _dbCon.Yarn_KnittingContractMaster
                       .Where(b => b.YarnKNContractID == YarnKNContractID)
                       .Include(y => y.Yarn_KnittingContractDetail)
                       .FirstOrDefaultAsync(cancellationToken);
            if (data.KRS_ID.HasValue)
            {
                var krsOrder = await _dbCon.vw_KRSOrder.Where(b => b.KRSID == data.KRS_ID.Value).FirstAsync(cancellationToken);
                data.OrderID =(int) krsOrder.OrderID;
                data.OrderNo = krsOrder.OrderNo;
            }
            
            return data;
        }
    }
}
