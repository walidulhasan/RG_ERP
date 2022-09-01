using AutoMapper;
using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.Buisness.Plan_OrderFollowups.Commands.DataTransferModel;
using RG.Application.Interfaces.Repositories.Maxco.Business;
using RG.Application.Interfaces.Services.Maxco.Business;
using RG.Application.ViewModel.Maxco.Business.OrderPlanFollowup;
using RG.DBEntities.Maxco.Business;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Maxco.Business
{
    public class Plan_OrderFollowupService : IPlan_OrderFollowupService
    {
        private readonly IPlan_OrderFollowupRepository plan_OrderFlowupRepository;
        private readonly IMapper mapper;

        public Plan_OrderFollowupService(IPlan_OrderFollowupRepository _plan_OrderFlowupRepository, IMapper _mapper)
        {
            plan_OrderFlowupRepository = _plan_OrderFlowupRepository;
            mapper = _mapper;
        }

        public async Task<OrderPlanFollowupCreateVM> GetOrderPlanFollowup(int orderID, CancellationToken cancellationToken)
        {
            var returnData = new OrderPlanFollowupCreateVM();
            var data = await plan_OrderFlowupRepository.GetOrderPlanFollowup(orderID, cancellationToken);
            if (data != null)
            {
                returnData.FollowupID = data.FollowupID;
                returnData.OrderClassificationID = data.OrderClassificationID;
                returnData.AdditionalFromStock = data.AdditionalFromStock.ToString();
                returnData.ApprovedDate = data.ApprovedDate != null ? data.ApprovedDate.Value.ToString("dd-MMM-yyyy") : "";
                returnData.PackingCompleteDate = data.PackingCompleteDate != null ? data.PackingCompleteDate.Value.ToString("dd-MMM-yyyy") : "";
                returnData.PreFinalDate = data.PreFinalDate != null ? data.PreFinalDate.Value.ToString("dd-MMM-yyyy") : "";
                returnData.ApprovedDate = data.ApprovedDate != null ? data.ApprovedDate.Value.ToString("dd-MMM-yyyy") : "";
                returnData.IsOrderClosed = data.IsOrderClosed.ToString();
                returnData.ExpectedSampleDate = data.ExpectedSampleDate != null ? data.ExpectedSampleDate.Value.ToString("dd-MMM-yyyy") : "";
                returnData.PreProductionSampleApprovalDate = data.PreProductionSampleApprovalDate != null ? data.PreProductionSampleApprovalDate.Value.ToString("dd-MMM-yyyy") : "";
                returnData.Remarks = returnData.Remarks != null ? data.Remarks.ToString() : "";
            }
            return returnData;
        }



        public async Task<RResult> Plan_OrderFollowupSave(Plan_OrderFollowupDTM model)
        {
            var entity = mapper.Map<Plan_OrderFollowupDTM, Plan_OrderFollowup>(model);
            if (entity.FollowupID > 0)
                return await plan_OrderFlowupRepository.Plan_OrderFollowupUpdate(entity);
            else
                return await plan_OrderFlowupRepository.Plan_OrderFollowupSave(entity);
        }
    }
}
