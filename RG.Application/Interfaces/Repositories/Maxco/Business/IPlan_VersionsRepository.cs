using RG.Application.Common.Models;
using RG.DBEntities.Maxco.Business;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Maxco.Business
{
    public interface IPlan_VersionsRepository : IGenericRepository<Plan_Versions>
    {
        Task<Plan_Versions> GetOrderWiseActivePlanVersion(int orderID, CancellationToken cancellationToken);
        Task<List<Plan_Versions>> GetOrderWisePlanVersions(int orderID, CancellationToken cancellationToken);
    }
}
