using Microsoft.AspNetCore.Mvc.Rendering;
using RG.DBEntities.Maxco.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Maxco.Setup
{
    public interface IOrderClassificationRepository : IGenericRepository<OrderClassification>
    {
        Task<List<SelectListItem>> DDLOrderClassification(CancellationToken cancellationToken);
    }
}
