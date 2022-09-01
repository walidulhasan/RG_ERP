using RG.Application.Common.Models;
using RG.DBEntities.Maxco.Business;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Maxco.Business
{
    public interface IPlan_OrderFollowupRepository : IGenericRepository<Plan_OrderFollowup>
    {
        Task<RResult> Plan_OrderFollowupSave(Plan_OrderFollowup entity);
        Task<RResult> Plan_OrderFollowupUpdate(Plan_OrderFollowup entity);
        Task<Plan_OrderFollowup> GetOrderPlanFollowup(int orderID, CancellationToken cancellationToken);

    }
}
