using RG.Application.Contracts.Maxco.Buisness.OrderSewingSchedulings.Queries.RequestResponseModel;
using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Maxco.Business
{
    public  interface IOrderSewingSchedulingRepository:IGenericRepository<OrderSewingScheduling>
    {
        Task<List<OrderSewingSchedulingRM>> GetListSewingScheduling(int OrderId, int GSM, int FabricQualityID, string FabricComposition, string PantoneNo, decimal FinishedWidth, CancellationToken cancellationToken);

    }
}
