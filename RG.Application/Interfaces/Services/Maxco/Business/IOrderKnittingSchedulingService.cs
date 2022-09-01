using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.OrderKnittingSchedulings.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Maxco.Business
{
    public  interface IOrderKnittingSchedulingService
    {
        Task<List<OrderKnittingSchedulingRM>> GetListOrderKnittingScheduling(int krsid, int fabid, CancellationToken cancellationToken);
        Task<RResult> DeleteOrderKnittingScheduling(int id,bool SaveChanges);
    }
}
