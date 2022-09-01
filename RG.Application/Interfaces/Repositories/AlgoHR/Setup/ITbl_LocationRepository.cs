using Microsoft.AspNetCore.Mvc.Rendering;
using RG.DBEntities.AlgoHR;
using RG.DBEntities.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AlgoHR.Setup
{
    public interface ITbl_LocationRepository :IGenericRepository<Tbl_Location>
    {
        Task<List<SelectListItem>> DDLLocation(List<int> CompanyID, string Predict = null, CancellationToken cancellationToken = default);
    }
}
