using RG.Application.Contracts.Maxco.OrderKnittingSchedulings.Queries.RequestResponseModel;
using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Maxco.Business
{
    public  interface IOrderKnittingSchedulingRepository:IGenericRepository<OrderKnittingScheduling>
    {
        Task<List<OrderKnittingSchedulingRM>> GetListOrderKnittingScheduling(int krsid,int fabid, CancellationToken cancellationToken);
    }
}
