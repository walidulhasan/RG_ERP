using RG.Application.Contracts.MaterialsManagement.Business.YarnStockReport.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.MaterialsManagement.Business
{
    public interface IYarnstockReportRepository
    {
        Task<List<YarnStockReportRM>> GetYarnStock(DateTime DateFrom, DateTime DateTo, int WithAllTransaction, int ShowEmptyClosing = 0);
        Task<List<YarnStockReportRM>> GetYarnStockWithRack(DateTime DateFrom, DateTime DateTo, int WithAllTransaction, int ShowEmptyClosing = 0);
        Task<List<YarnRackBalanceReportRM>> GetYarnRackBalanceReport(string LotNo = null, int BuildingID = 0, int FloorID = 0, int RackID = 0, int CompositionID = 0, string Count = null,int OrderBy=0);
    }
}
