using RG.Application.Common.Models;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.MaterialsManagement.Business
{
    public interface IYarn_StockTransactionsRepository:IGenericRepository<Yarn_StockTransactions>
    {
        Task<RResult> Yarn_StockTransactionsSaveForYarnIssue(List<Yarn_StockTransactions> entities,  bool saveChanges = true);

    }
}
