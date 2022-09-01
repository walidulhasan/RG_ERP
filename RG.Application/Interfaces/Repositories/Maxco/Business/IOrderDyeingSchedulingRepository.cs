using RG.Application.Contracts.Maxco.Buisness.OrderDyeingSchedulings.Queries.RequestResponseModel;
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
    public  interface IOrderDyeingSchedulingRepository:IGenericRepository<OrderDyeingScheduling>
    {
        Task<List<OrderDyeingSchedulingRM>> GetListDyeingFinishFabric(int OrderId,int GSM,int FabricQualityID,string FabricComposition,string PantoneNo,decimal FinishedWidth, CancellationToken cancellationToken);
    }
}
