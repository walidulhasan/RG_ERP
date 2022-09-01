using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.Buisness.OrderCuttingSchedulings.Queries.RequestResponseModel;
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
    public class OrderCuttingSchedulingService : IOrderCuttingSchedulingService
    {
        private readonly IOrderCuttingSchedulingRepository _orderCuttingSchedulingRepository;

        public OrderCuttingSchedulingService(IOrderCuttingSchedulingRepository orderCuttingSchedulingRepository)
        {
            _orderCuttingSchedulingRepository = orderCuttingSchedulingRepository;
        }

        public async Task<RResult> DeleteCuttingScheduling(int id, bool SaveChanges)
        {
            RResult result = new();
            if (id > 0)
            {
                var entity = await _orderCuttingSchedulingRepository.GetByIdAsync(id);
                entity.IsRemoved = true;
                await _orderCuttingSchedulingRepository.UpdateAsync(entity, entity.CuttingScheduleID, SaveChanges);
                result.result = 1;
                result.message = "Cutting Scheduling  Successfully Remove.";
            }
            else
            {
                result.result = 0;
                result.message = "Remove failed";
            }
            return result;
        }

        public async Task<List<OrderCuttingSchedulingRM>> GetListCuttingScheduling(int OrderId, int GSM, int FabricQualityID, string FabricComposition, string PantoneNo, decimal FinishedWidth, CancellationToken cancellationToken)
        {
            return await _orderCuttingSchedulingRepository.GetListCuttingScheduling(OrderId,GSM,FabricQualityID,FabricComposition,PantoneNo,FinishedWidth,cancellationToken);
        }
    }
}
