using RG.Application.Contracts.Maxco.Buisness.OrderCuttingSchedulings.Queries.RequestResponseModel;
using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Maxco.Business
{
    public  interface IOrderCuttingSchedulingRepository:IGenericRepository<OrderCuttingScheduling>
    {
        Task<List<OrderCuttingSchedulingRM>> GetListCuttingScheduling(int OrderId, int GSM, int FabricQualityID, string FabricComposition, string PantoneNo, decimal FinishedWidth, CancellationToken cancellationToken);
    }
}
