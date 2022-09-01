using Microsoft.EntityFrameworkCore;
using RG.Application.Contracts.AOP.Business.tbl_challan_master.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AOP.Business;
using RG.DBEntities.AOP.Business;
using RG.Infrastructure.Persistence.AOPDB;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AOP.Business
{
    public class tbl_challan_masterRepository : GenericRepository<tbl_challan_master>, Itbl_challan_masterRepository
    {
        private readonly AOPDBContext dbCon;
        public tbl_challan_masterRepository(AOPDBContext _dbCon) : base(_dbCon)
        {
            dbCon = _dbCon;
        }

        public async Task<ChallanCustomerInfoRM> GetChallanCustomerInfo(long issuanceDetailID, CancellationToken cancellationToken)
        {
            var data= await (from d in dbCon.Tbl_Issuance_Details
                            join m in dbCon.Tbl_Issuance_Master on d.Transation_ID equals m.ID
                            join cm in dbCon.tbl_challan_master on m.challan_id equals cm.challan_id
                            where d.ID==issuanceDetailID
                            select new ChallanCustomerInfoRM
                            {
                                CustomerID = cm.SupplierID.Value,
                                CustomerName = cm.customername,
                                CustomerAddress = cm.address
                            }).FirstOrDefaultAsync(cancellationToken);
            return data;
        }
    }
}
