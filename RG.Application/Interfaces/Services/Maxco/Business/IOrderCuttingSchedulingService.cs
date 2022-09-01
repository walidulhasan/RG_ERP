using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.Buisness.OrderCuttingSchedulings.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Maxco.Business
{
    public  interface IOrderCuttingSchedulingService
    {
        Task<List<OrderCuttingSchedulingRM>> GetListCuttingScheduling(int OrderId, int GSM, int FabricQualityID, string FabricComposition, string PantoneNo, decimal FinishedWidth, CancellationToken cancellationToken);
        Task<RResult> DeleteCuttingScheduling(int id, bool SaveChanges);
    }
}
