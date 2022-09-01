using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.Buisness.OrderSewingSchedulings.Queries.RequestResponseModel;
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
    public class OrderSewingSchedulingService: IOrderSewingSchedulingService
    {
        private readonly IOrderSewingSchedulingRepository _orderSewingSchedulingRepository;

        public OrderSewingSchedulingService(IOrderSewingSchedulingRepository orderSewingSchedulingRepository)
        {
            _orderSewingSchedulingRepository = orderSewingSchedulingRepository;
        }

        public async Task<RResult> DeleteSewingScheduling(int id, bool SaveChanges)
        {
            RResult result = new();
            if (id > 0)
            {
                var entity = await _orderSewingSchedulingRepository.GetByIdAsync(id);
                entity.IsRemoved = true;
                await _orderSewingSchedulingRepository.UpdateAsync(entity, entity.SewingScheduleID, SaveChanges);
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

        public async Task<List<OrderSewingSchedulingRM>> GetListSewingScheduling(int OrderId, int GSM, int FabricQualityID, string FabricComposition, string PantoneNo, decimal FinishedWidth, CancellationToken cancellationToken)
        {
            return await _orderSewingSchedulingRepository.GetListSewingScheduling( OrderId,  GSM,  FabricQualityID,  FabricComposition,  PantoneNo,  FinishedWidth, cancellationToken);
        }
    }
}
