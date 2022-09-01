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
    public class Yarn_StockTransactionsRepository : GenericRepository<Yarn_StockTransactions>, IYarn_StockTransactionsRepository
    {
        private readonly MaterialsManagementDBContext dbCon;

        public Yarn_StockTransactionsRepository(MaterialsManagementDBContext _dbCon) : base(_dbCon)
        {
            dbCon = _dbCon;
        }

        public async Task<RResult> Yarn_StockTransactionsSaveForYarnIssue(List<Yarn_StockTransactions> entities, bool saveChanges = true)
        {
            RResult rResult = new();
            await dbCon.AddRangeAsync(entities);
            return rResult;
        }
    }
}
