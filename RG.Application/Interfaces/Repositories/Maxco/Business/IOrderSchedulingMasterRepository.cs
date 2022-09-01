using RG.Application.Contracts.Maxco.Buisness.OrderSchedulingMasters.Queries.RequestResponseModel;
using RG.Application.ViewModel.Maxco.Business.OrderScheduling;
using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Maxco.Business
{
    public interface IOrderSchedulingMasterRepository:IGenericRepository<OrderScheduling>
    {
        Task<OrderSchedulingMasterVM> GetOrderSchedulingInfo(int orderID, CancellationToken cancellationToken);
       
    }
}
