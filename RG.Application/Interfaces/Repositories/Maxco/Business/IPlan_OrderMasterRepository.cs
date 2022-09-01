using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.Buisness.Plan_OrderMasters.Queries.RequestResponseModel;
using RG.DBEntities.Maxco.Business;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Maxco.Business
{
    public interface IPlan_OrderMasterRepository : IGenericRepository<Plan_OrderMaster>
    {
        Task<RResult> PlanOrderMasterSave(Plan_OrderMaster entity);
        Task<RResult> PlanOrderMasterUpdate(Plan_OrderMaster entity);
        Task<RResult> PlanOrderMasterNewVersion(Plan_Versions entity);
        Task<List<PlanOrderDetailInfoRM>> GetPlanOrderDetailInfo(int orderID, CancellationToken cancellationToken);
        Task<Plan_OrderMaster> GetOrderPlanningVersionDetail(int orderID, int planVersionID);
        Task<List<SelectListItem>> DDLPlanOrders(bool? IsOrderClosed, string Predict = null, CancellationToken cancellationToken=default);
        Task<List<SelectListItem>> DDLBuyerWisePlanOrders(int BuyerID,bool? IsOrderClosed, string Predict = null, CancellationToken cancellationToken = default);
    }
}
