using AutoMapper;
using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.Buisness.OrderSchedulingMasters.Commands.DataTransferModel;
using RG.Application.Interfaces.Repositories.Maxco.Business;
using RG.Application.Interfaces.Services.Maxco.Business;
using RG.Application.ViewModel.Maxco.Business.OrderScheduling;
using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services
{
    public class OrderSchedulingMasterService : IOrderSchedulingMasterService
    {
        private readonly IOrderSchedulingMasterRepository _orderSchedulingMasterRepository;
        private readonly IMapper _mapper;
        private readonly IOrderSchedulingRepository _orderSchedulingRepository;
        private readonly IOrderKnittingSchedulingRepository _orderKnittingSchedulingRepository;
        private readonly IOrderDyeingSchedulingRepository _orderDyeingSchedulingRepository;
        private readonly IOrderCuttingSchedulingRepository _orderCuttingSchedulingRepository;
        private readonly IOrderSewingSchedulingRepository _orderSewingSchedulingRepository;

        public OrderSchedulingMasterService(IOrderSchedulingMasterRepository orderSchedulingMasterRepository,
            IMapper mapper,
            IOrderSchedulingRepository orderSchedulingRepository,
            IOrderKnittingSchedulingRepository orderKnittingSchedulingRepository,
            IOrderDyeingSchedulingRepository orderDyeingSchedulingRepository,
            IOrderCuttingSchedulingRepository orderCuttingSchedulingRepository,
            IOrderSewingSchedulingRepository orderSewingSchedulingRepository
            )
        {
            _orderSchedulingMasterRepository = orderSchedulingMasterRepository;
            _mapper = mapper;
            _orderSchedulingRepository = orderSchedulingRepository;
            _orderKnittingSchedulingRepository = orderKnittingSchedulingRepository;
            _orderDyeingSchedulingRepository = orderDyeingSchedulingRepository;
            _orderCuttingSchedulingRepository = orderCuttingSchedulingRepository;
            _orderSewingSchedulingRepository = orderSewingSchedulingRepository;
        }

        public async Task<RResult> Create(OrderSchedulingMastersDTM model, bool saveChange)
        {
            try
            {
                RResult result = new();
                var entity = _mapper.Map<OrderSchedulingMastersDTM, OrderScheduling>(model);
                var scheduleCheck = _orderSchedulingRepository.FindAllAsync(x => x.OrderID == model.OrderID).Result;
                var schedulingId = _orderSchedulingMasterRepository.GetAll(x => x.OrderID == model.OrderID).FirstOrDefault();
                if (scheduleCheck.Count == 0)
                {
                    var obj = await _orderSchedulingRepository.InsertAsync(entity, true);
                    if (model.OrderID > 0)
                    {
                        result.result = 1;
                        result.message = "Data Insert Successfulluy";
                    }
                    else
                    {
                        result.result = 0;
                        result.message = ReturnMessage.ErrorMessage;
                    }
                }
                else if (scheduleCheck.Count > 0)
                {
                    if (model.OrderKnittingScheduling != null && model.FlgForAction == "Knitting")
                    {
                        model.OrderKnittingScheduling.ScheduleID = schedulingId.ScheduleID;
                        var orderKnittingSchedulingValue = _mapper.Map<OrderKnittingSchedulingDTM, OrderKnittingScheduling>(model.OrderKnittingScheduling);
                        await _orderKnittingSchedulingRepository.InsertAsync(orderKnittingSchedulingValue, true);
                        result.result = 1;
                        result.message = "Data Insert Successfulluy";
                    }
                    else if (model.OrderDyeingScheduling != null && model.FlgForAction == "Dyeing")
                    {
                        model.OrderDyeingScheduling.ScheduleID = schedulingId.ScheduleID;
                        var orderDyeingSchedulingValue = _mapper.Map<OrderDyeingSchedulingDTM, OrderDyeingScheduling>(model.OrderDyeingScheduling);
                        await _orderDyeingSchedulingRepository.InsertAsync(orderDyeingSchedulingValue, true);
                        result.result = 1;
                        result.message = "Data Insert Successfulluy";
                    }
                    else if (model.OrderCuttingScheduling != null && model.FlgForAction == "Cutting")
                    {
                        model.OrderCuttingScheduling.ScheduleID = schedulingId.ScheduleID;
                        var orderCuttingSchedulingValue = _mapper.Map<OrderCuttingSchedulingDTM, OrderCuttingScheduling>(model.OrderCuttingScheduling);
                        await _orderCuttingSchedulingRepository.InsertAsync(orderCuttingSchedulingValue, true);
                        result.result = 1;
                        result.message = "Data Insert Successfulluy";
                    }
                    else if (model.OrderSewingScheduling != null && model.FlgForAction == "Sewing")
                    {
                        model.OrderSewingScheduling.ScheduleID = schedulingId.ScheduleID;
                        var orderSewingSchedulingValue = _mapper.Map<OrderSewingSchedulingDTM, OrderSewingScheduling>(model.OrderSewingScheduling);
                        await _orderSewingSchedulingRepository.InsertAsync(orderSewingSchedulingValue, true);
                        result.result = 1;
                        result.message = "Data Insert Successfulluy";
                    }
                    else
                    {
                        result.result = 0;
                        result.message = ReturnMessage.ErrorMessage;
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<OrderSchedulingMasterVM> GetOrderSchedulingInfo(int orderID, CancellationToken cancellationToken)
        {
            return await _orderSchedulingMasterRepository.GetOrderSchedulingInfo(orderID, cancellationToken);
        }
    }
}
