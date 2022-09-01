using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Business.YarnIssuanceToKnitter.Commands.DataTransferModel;
using RG.Application.Interfaces.Repositories.Embro.Business;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Business
{
    public class Yarn_IssuanceToKnitterMasterService : IYarn_IssuanceToKnitterMasterService
    {
        private readonly IYarn_IssuanceToKnitterMasterRepository _yarn_IssuanceToKnitterMasterRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IYarn_KnittingContractMasterService _yarn_KnittingContractMasterService;
        private readonly IYarn_KnitterStockTransactionsService _yarn_KnitterStockTransactionsService;
        private readonly IYarn_StockTransactionsService _yarn_StockTransactionsService;
        private readonly ITEMP_Yarn_IssueService _tEMP_Yarn_IssueService;
        private readonly IVoucherRepository _voucherRepository;

        public Yarn_IssuanceToKnitterMasterService(IYarn_IssuanceToKnitterMasterRepository yarn_IssuanceToKnitterMasterRepository
            , ICurrentUserService currentUserService, IYarn_KnittingContractMasterService yarn_KnittingContractMasterService
            , IYarn_KnitterStockTransactionsService yarn_KnitterStockTransactionsService
            , IYarn_StockTransactionsService yarn_StockTransactionsService
            ,ITEMP_Yarn_IssueService tEMP_Yarn_IssueService,
            IVoucherRepository voucherRepository)

        {

            _yarn_IssuanceToKnitterMasterRepository = yarn_IssuanceToKnitterMasterRepository;
            _currentUserService = currentUserService;
            _yarn_KnittingContractMasterService = yarn_KnittingContractMasterService;
            _yarn_KnitterStockTransactionsService = yarn_KnitterStockTransactionsService;
            _yarn_StockTransactionsService = yarn_StockTransactionsService;
            _tEMP_Yarn_IssueService = tEMP_Yarn_IssueService;
            _voucherRepository = voucherRepository;
        }
        public async Task<RResult> IssuanceSave(AllocatedYarnIssueDTM model, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            RResult rResult = new();
            string VouchersNo = "";
            long IssuanceNo = 0;
            var yknc = await _yarn_KnittingContractMasterService.GetYarn_KnittingContractMaster(model.ID);
    

            using (TransactionScope scope = new(TransactionScopeAsyncFlowOption.Enabled)) {
                try
                {
                    Yarn_IssuanceToKnitterMaster knitterMaster = new()
                    {
                        YarnKNContractID = model.ID,
                        IssuanceDate = DateTime.Now,
                        CompanyID = yknc.CompanyID,
                        BusinessID = _currentUserService.BusinessID
                    };
                    await _yarn_IssuanceToKnitterMasterRepository.InsertAsync(knitterMaster, saveChanges);
                    model.YKNCBatch.ForEach(b => { b.OrderID = yknc.OrderID; b.OrderNo = yknc.OrderNo; });

                    await _yarn_StockTransactionsService.Yarn_StockTransactionsSaveForYarnIssue(model.YKNCBatch, knitterMaster.YarnKNIssID, saveChanges);

                    await _yarn_KnitterStockTransactionsService.Yarn_KnitterStockTransactionsSaveForYarnIssue(model.YKNCBatch, knitterMaster.YarnKNIssID, saveChanges);

                    await _tEMP_Yarn_IssueService.TEMP_Yarn_issueSave(model.YKNCBatch, saveChanges);

                   
                    IssuanceNo = knitterMaster.YarnKNIssID;
                    rResult.result = 1;
                    rResult.message = $"Issuance No :{knitterMaster.YarnKNIssID} <br/>  Vouchers : {VouchersNo}";
                    scope.Complete();
                }
                catch (Exception e)
                {
                    IssuanceNo = 0;
                    scope.Dispose();
                } 
            }

            if (IssuanceNo > 0)
            {
                var rateSum = model.YKNCBatch.Sum(c => c.Rate);
                var quantitySum = model.YKNCBatch.Sum(c => c.IssuedQty);
                var amountSum = model.YKNCBatch.Sum(c => ((decimal)c.Rate * c.IssuedQty));
                var lotCompanyID = model.YKNCBatch.First().CompanyID;

                using (TransactionScope voucherScope = new(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        VouchersNo = await _voucherRepository.SaveYarnIssuanceVoucher(IssuanceNo, yknc.YarnKNContractID, (int)yknc.CompanyID, (int)lotCompanyID, _currentUserService.BusinessID, (decimal)rateSum, quantitySum, amountSum, yknc.ContractDate);
                        voucherScope.Complete();

                        rResult.result = 1;
                        rResult.message = $"Issuance No :{IssuanceNo} <br/>  Vouchers : {VouchersNo}";
                    }
                    catch(Exception e)
                    {
                        rResult.message = "OOoops!! Error occured";
                        voucherScope.Dispose();
                    }
                }
            }

            return rResult;
        }
    }
}
