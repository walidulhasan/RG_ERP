using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.Buisness.Plan_OrderMasters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Maxco.Business;
using RG.Application.Interfaces.Services.Maxco.Business;
using RG.DBEntities.Maxco.Business;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Maxco.Business
{
    public class Plan_OrderMasterService : IPlan_OrderMasterService
    {
        private readonly IPlan_OrderMasterRepository plan_OrderMasterRepository;
        private readonly IPlan_VersionsService plan_VersionsService;

        public Plan_OrderMasterService(IPlan_OrderMasterRepository _plan_OrderMasterRepository, IPlan_VersionsService _plan_VersionsService)
        {
            plan_OrderMasterRepository = _plan_OrderMasterRepository;
            plan_VersionsService = _plan_VersionsService;
        }

        public async Task<List<SelectListItem>> DDLBuyerWisePlanOrders(int BuyerID, bool? IsOrderClosed, string Predict = null, CancellationToken cancellationToken = default)
        {
            return await plan_OrderMasterRepository.DDLBuyerWisePlanOrders(BuyerID, IsOrderClosed, Predict, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLPlanOrders(bool? IsOrderClosed, string Predict = null, CancellationToken cancellationToken = default)
        {
            return await plan_OrderMasterRepository.DDLPlanOrders(IsOrderClosed, Predict, cancellationToken);
        }
        public async Task<Plan_OrderMaster> GetOrderPlanningVersionDetail(int orderID, int planVersionID)
        {
            return await plan_OrderMasterRepository.GetOrderPlanningVersionDetail(orderID, planVersionID);
        }
        public async Task<List<PlanOrderDetailInfoRM>> GetPlanOrderDetailInfo(int orderID, CancellationToken cancellationToken)
        {
            return await plan_OrderMasterRepository.GetPlanOrderDetailInfo(orderID, cancellationToken);
        }
        public async Task<RResult> PlanOrderMasterSave(Plan_OrderMaster entity)
        {
            if (entity.Plan_Versions.First().PlanVersionID == 0)
            {
                var versions = await plan_VersionsService.GetOrderWisePlanVersions(entity.OrderID, new CancellationToken());
                entity.Plan_Versions.First().VersionNo = versions.Count > 0 ? versions.Max(c => c.VersionNo) + 1 : 1;
                if (versions.Count > 0)
                    await plan_VersionsService.InActivePlanVersion(entity.OrderID);
            }
            if (entity.PlanID == 0 && entity.Plan_Versions.First().PlanVersionID == 0)
            {
                return await plan_OrderMasterRepository.PlanOrderMasterSave(entity);
            }
            else if (entity.PlanID > 0 && entity.Plan_Versions.First().PlanVersionID == 0)
            {
                var version = entity.Plan_Versions.First();
                version.PlanID = entity.PlanID;
                return await plan_OrderMasterRepository.PlanOrderMasterNewVersion(version);
            }
            else
            {
                return await plan_OrderMasterRepository.PlanOrderMasterUpdate(entity);
            }
            //return new RResult();
        }


    }
}
