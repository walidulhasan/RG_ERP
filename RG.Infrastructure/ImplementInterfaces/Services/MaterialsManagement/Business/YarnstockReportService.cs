using RG.Application.Contracts.MaterialsManagement.Business.YarnStockReport.RequestResponseModel;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Business
{
    public class YarnstockReportService : IYarnstockReportService
    {
        private readonly IYarnstockReportRepository _yarnstockReportRepository;

        public YarnstockReportService(IYarnstockReportRepository yarnstockReportRepository)
        {
            _yarnstockReportRepository = yarnstockReportRepository;
        }

        public async Task<List<YarnRackBalanceReportRM>> GetYarnRackBalanceReport(string LotNo = null, int BuildingID = 0, int FloorID = 0, int RackID = 0, int CompositionID = 0, string YarnCount = null, int OrderBy = 0)
        {
            return await _yarnstockReportRepository.GetYarnRackBalanceReport(LotNo, BuildingID, FloorID, RackID, CompositionID, YarnCount,OrderBy);
        }

        public async Task<List<YarnStockReportRM>> GetYarnStock(DateTime DateFrom, DateTime DateTo, int WithAllTransaction, int ShowEmptyClosing = 0)
        {
            return await _yarnstockReportRepository.GetYarnStock(DateFrom, DateTo, WithAllTransaction,ShowEmptyClosing);

        }

        public async Task<List<YarnStockReportRM>> GetYarnStockWithRack(DateTime DateFrom, DateTime DateTo, int WithAllTransaction, int ShowEmptyClosing = 0)
        {
            return await _yarnstockReportRepository.GetYarnStockWithRack(DateFrom, DateTo, WithAllTransaction, ShowEmptyClosing);
        }
    }
}
