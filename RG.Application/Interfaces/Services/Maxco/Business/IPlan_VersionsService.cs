using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.Buisness.Plan_OrderMasters.Queries.RequestResponseModel;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Maxco.Business
{
    public interface IPlan_VersionsService
    {
        Task<RResult> InActivePlanVersion(int orderID);
        Task<List<Plan_VersionsRM>> GetOrderWisePlanVersions(int orderID, CancellationToken cancellationToken);
    }
}
