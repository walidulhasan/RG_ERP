using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.OrderKnittingSchedulings.Queries.RequestResponseModel;
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
    public class OrderKnittingSchedulingService : IOrderKnittingSchedulingService
    {
        private readonly IOrderKnittingSchedulingRepository _orderKnittingSchedulingRepository;

        public OrderKnittingSchedulingService(IOrderKnittingSchedulingRepository orderKnittingSchedulingRepository)
        {
            _orderKnittingSchedulingRepository = orderKnittingSchedulingRepository;
        }

        public async Task<RResult> DeleteOrderKnittingScheduling(int id, bool SaveChanges)
        {
            RResult result = new();
            if (id > 0)
            {
                var entity = await _orderKnittingSchedulingRepository.GetByIdAsync(id);
                entity.IsRemoved = true;
                await _orderKnittingSchedulingRepository.UpdateAsync(entity, entity.KnittingScheduleID, SaveChanges);
                result.result = 1;
                result.message = "Order Knitting Scheduling  Successfully Remove.";
            }
            else
            {
                result.result = 0;
                result.message = "Remove failed";
            }
            return result;

        }

        public async Task<List<OrderKnittingSchedulingRM>> GetListOrderKnittingScheduling(int krsid, int fabid, CancellationToken cancellationToken)
        {
            return await _orderKnittingSchedulingRepository.GetListOrderKnittingScheduling(krsid,fabid,cancellationToken);
        }
    }
}
