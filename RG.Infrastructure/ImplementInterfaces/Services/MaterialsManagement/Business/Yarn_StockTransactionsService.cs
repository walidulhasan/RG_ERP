using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class Yarn_StockTransactionsService : IYarn_StockTransactionsService
    {
        private readonly IMapper _mapper;
        private readonly IYarn_StockTransactionsRepository _yarn_StockTransactionsRepository;
        private readonly IYarnRackIssueService _yarnRackIssueService;
        private readonly IYarnRackAllocationService _yarnRackAllocationService;

        public Yarn_StockTransactionsService(IMapper mapper, IYarn_StockTransactionsRepository yarn_StockTransactionsRepository
            , IYarnRackIssueService yarnRackIssueService, IYarnRackAllocationService yarnRackAllocationService)
        {
            _mapper = mapper;
            _yarn_StockTransactionsRepository = yarn_StockTransactionsRepository;
            _yarnRackIssueService = yarnRackIssueService;
            _yarnRackAllocationService = yarnRackAllocationService;
        }
        public async Task<RResult> Yarn_StockTransactionsSaveForYarnIssue(List<YKNCBatchDTM> models, long yarnKNIssID, bool saveChanges = true)
        {
            RResult rResult = new();
            foreach (var item in models)
            {
                var moviingAverageQuery =  _yarn_StockTransactionsRepository.GetAll(b => b.AttributeInstanceID == item.AttributeInstanceID && b.MovingAverage > 0
                , null
                , b=>b.OrderByDescending(o=>o.YarnStockTransactionID));
                var aaa = moviingAverageQuery.ToQueryString();
                var moviingAverageData =await moviingAverageQuery.FirstOrDefaultAsync();
                item.MovingAverage = moviingAverageData != null ? moviingAverageData.MovingAverage.Value : 1;

                var entity = new Yarn_StockTransactions
                {
                    DocumentTypeID = 26,
                    DocumentNo = yarnKNIssID,
                    TransactionDate = DateTime.Now,
                    DocumentDate = DateTime.Now,
                    MRPItemCode = item.MRPItemCode,
                    AttributeInstanceID = item.AttributeInstanceID,
                    SupplierID = item.SupplierID,
                    MfgDate = DateTime.Now,
                    BrandID = item.BrandID,
                    PackagingID = item.PackagingID,
                    ConesPerProcurementUnit = item.ConesPerProcurementUnit,
                    UnitID = item.UnitID,
                    StoreLocationID = item.LocationID,
                    rate = item.Rate,
                    rateUnitID = item.RateUnitID,
                    MovingAverage = item.MovingAverage,
                    TransactionQty =  item.AllocatedYarnIssueFromRack.Sum(x => x.IssuedQuantity) * (-1),
                    ProgramTypeID = item.ProgramTypeID,
                    OrderID = item.OrderID,
                    OrderNo = item.OrderNo,
                    LotNo = item.LotNo,
                    Status = item.Status,
                    RateWRTBaseUnit = item.RateWRTBaseUnit,
                    YarnKnittingContractID = item.YarnKnittingContractID,
                    CompanyID = item.CompanyID,
                    BusinessID = item.BusinessID


                };
                await _yarn_StockTransactionsRepository.InsertAsync(entity, saveChanges);

                List<YarnRackIssue> rackIssue = new();
                item.AllocatedYarnIssueFromRack.ForEach(x => rackIssue.Add(new YarnRackIssue
                {
                    YarnStockTransactionID = entity.YarnStockTransactionID,
                    IssueQuantity = x.IssuedQuantity,
                    RackAllocationID = x.RackAllocationID
                }));
                await _yarnRackIssueService.YarnRackIssueSave(rackIssue, saveChanges);
                await _yarnRackAllocationService.UpdateRackAllocationAfterIssue(rackIssue, saveChanges);
            }
            return rResult;
        }
    }
}
