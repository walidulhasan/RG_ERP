using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.Buisness.OrderSchedulingMasters.Commands.DataTransferModel;
using RG.Application.ViewModel.Maxco.Business.OrderScheduling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Maxco.Business
{
    public  interface IOrderSchedulingMasterService
    {
        Task<OrderSchedulingMasterVM> GetOrderSchedulingInfo(int orderID, CancellationToken cancellationToken);
        Task<RResult> Create(OrderSchedulingMastersDTM model, bool saveChange);
    }
}
