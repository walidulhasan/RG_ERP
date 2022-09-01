using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Business.YarnIssuanceToKnitter.Commands.DataTransferModel;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.MaterialsManagement.Business
{
    public interface IYarn_KnitterStockTransactionsRepository:IGenericRepository<Yarn_KnitterStockTransactions>
    {
        Task<RResult> Yarn_KnitterStockTransactionsSaveForYarnIssue(List<Yarn_KnitterStockTransactions> entities, bool saveChanges = true);
    }
}
