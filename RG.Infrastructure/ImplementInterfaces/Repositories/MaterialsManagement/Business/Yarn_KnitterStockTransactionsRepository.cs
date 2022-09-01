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
    public class Yarn_KnitterStockTransactionsRepository:GenericRepository<Yarn_KnitterStockTransactions>, IYarn_KnitterStockTransactionsRepository
    {
        private readonly MaterialsManagementDBContext _dbCon;
        public Yarn_KnitterStockTransactionsRepository(MaterialsManagementDBContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }

        public async Task<RResult> Yarn_KnitterStockTransactionsSaveForYarnIssue(List<Yarn_KnitterStockTransactions> entities, bool saveChanges = true)
        {
            RResult rResult = new();
            await _dbCon.AddRangeAsync(entities);
            await _dbCon.SaveChangesAsync();
            return rResult;
        }
    }
}
