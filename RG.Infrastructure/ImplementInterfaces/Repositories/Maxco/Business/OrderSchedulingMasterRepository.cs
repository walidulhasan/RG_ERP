using RG.Application.Contracts.Maxco.Buisness.OrderSchedulingMasters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Maxco.Business;
using RG.Application.ViewModel.Maxco.Business.OrderScheduling;
using RG.DBEntities.Maxco.Business;
using RG.Infrastructure.Persistence.MaxcoDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Maxco.Business
{
    public class OrderSchedulingMasterRepository :GenericRepository<OrderScheduling>, IOrderSchedulingMasterRepository
    {
        private readonly MaxcoDBContext _dbCon;

        public OrderSchedulingMasterRepository(MaxcoDBContext dbCon):base(dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<OrderSchedulingMasterVM> GetOrderSchedulingInfo(int orderID, CancellationToken cancellationToken)
        {
            OrderSchedulingMasterVM orderSchedulingInfo = new();

            try
            {
                


                    await _dbCon.LoadStoredProc("ajt.USP_OrderSchedulingProcessData")
                    .WithSqlParam("OrderID", orderID)
                                  .ExecuteStoredProcAsync((handler) =>
                                  {
                                      orderSchedulingInfo.KnittingScheduling = handler.ReadToList<KnittingSchedulingVM>() as List<KnittingSchedulingVM>;
                                      handler.NextResult();
                                      orderSchedulingInfo.DyeingScheduling = handler.ReadToList<DyeingSchedulingVM>() as List<DyeingSchedulingVM>;
                                      handler.NextResult();
                                      orderSchedulingInfo.CuttingScheduling = handler.ReadToList<CuttingSchedulingVM>() as List<CuttingSchedulingVM>;
                                      
                                  });

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orderSchedulingInfo;
        }

        
    }
}
