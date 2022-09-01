using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.Buisness.Plan_OrderFollowups.Commands.DataTransferModel;
using RG.Application.ViewModel.Maxco.Business.OrderPlanFollowup;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Maxco.Business
{
    public interface IPlan_OrderFollowupService
    {
        Task<OrderPlanFollowupCreateVM> GetOrderPlanFollowup(int orderID, CancellationToken cancellationToken);
        Task<RResult> Plan_OrderFollowupSave(Plan_OrderFollowupDTM model);
        
    }
}
