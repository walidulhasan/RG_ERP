using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Business.YarnIssuanceToKnitter.Commands.DataTransferModel;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Business
{
    public class Yarn_KnitterStockTransactionsService : IYarn_KnitterStockTransactionsService
    {
        private readonly IYarn_KnitterStockTransactionsRepository _yarn_KnitterStockTransactionsRepository;

        public Yarn_KnitterStockTransactionsService(IYarn_KnitterStockTransactionsRepository yarn_KnitterStockTransactionsRepository)
        {
            _yarn_KnitterStockTransactionsRepository = yarn_KnitterStockTransactionsRepository;
        }
        public async Task<RResult> Yarn_KnitterStockTransactionsSaveForYarnIssue(List<YKNCBatchDTM> models, long yarnKNIssID, bool saveChanges = true)
        {
            RResult rResult = new();

            List<Yarn_KnitterStockTransactions> entities = new();
            models.ForEach(x => entities.Add(new Yarn_KnitterStockTransactions
            {
                TransactionDate=DateTime.Now,
                MRPItemCode=x.MRPItemCode,
                AttributeInstanceID=x.AttributeInstanceID,
                SupplierID=x.SupplierID,
                MfgDate=DateTime.Now,////////
                BrandID=x.BrandID,
                PackagingID=x.PackagingID,
                ConesPerProcurementUnit=x.ConesPerProcurementUnit,
                UnitID=x.UnitID,
                rate=x.Rate,
                rateUnitID=x.RateUnitID,
                MovingAverage=x.MovingAverage,
               TransactionQty=x.TransactionQty,
               ProgramTypeID=x.ProgramTypeID,
               LotNo=x.LotNo,
               RateWRTBaseUnit=x.RateWRTBaseUnit,
               KnittingContractID=x.YarnKnittingContractID,
               IssuanceToKnitterID= yarnKNIssID
            }));
            await _yarn_KnitterStockTransactionsRepository.Yarn_KnitterStockTransactionsSaveForYarnIssue(entities, saveChanges);

            return rResult;

        }
    }
}
