using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.Buisness.OrderDyeingSchedulings.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Maxco.Business;
using RG.Application.Interfaces.Services.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Maxco.Business
{
    public class OrderDyeingSchedulingService : IOrderDyeingSchedulingService
    {
        private readonly IOrderDyeingSchedulingRepository _orderDyeingSchedulingRepository;
        private readonly IOrderSchedulingMasterRepository _orderSchedulingMasterRepository;

        public OrderDyeingSchedulingService(IOrderDyeingSchedulingRepository orderDyeingSchedulingRepository, IOrderSchedulingMasterRepository orderSchedulingMasterRepository)
        {
            _orderDyeingSchedulingRepository = orderDyeingSchedulingRepository;
            _orderSchedulingMasterRepository = orderSchedulingMasterRepository;
        }

        public async Task<RResult> DeleteDyeingFinishFabric(int id, bool SaveChanges)
        {
            RResult result = new();
            if (id > 0)
            {
                var entity = await _orderDyeingSchedulingRepository.GetByIdAsync(id);
                entity.IsRemoved = true;
                await _orderDyeingSchedulingRepository.UpdateAsync(entity, entity.DyeingScheduleID, SaveChanges);
                result.result = 1;
                result.message = "Dyeing Scheduling  Successfully Remove.";
            }
            else
            {
                result.result = 0;
                result.message = "Remove failed";
            }
            return result;
        }

        public async Task<List<OrderDyeingSchedulingRM>> GetListDyeingFinishFabric(int OrderId, int GSM, int FabricQualityID, string FabricComposition, string PantoneNo, decimal FinishedWidth, CancellationToken cancellationToken)
        {
            return await _orderDyeingSchedulingRepository.GetListDyeingFinishFabric(OrderId,GSM,FabricQualityID,FabricComposition,PantoneNo,FinishedWidth,cancellationToken);
        }
    }
}
