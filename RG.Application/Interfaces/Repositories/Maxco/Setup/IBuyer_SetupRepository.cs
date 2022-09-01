using Microsoft.AspNetCore.Mvc.Rendering;
using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Maxco.Setup
{
    public interface IBuyer_SetupRepository:IGenericRepository<Buyer_Setup>
    {
        Task<List<SelectListItem>> DDLBuyerOfPlannedOrders(CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLBuyerAllQuery(DateTime? OrderDateLimit = null, CancellationToken cancellationToken = default);
    }
}
