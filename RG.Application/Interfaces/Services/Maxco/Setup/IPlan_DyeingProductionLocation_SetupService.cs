using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.Maxco.Setup.Plan_DyeingProductionLocation_Setup.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Maxco.Setup
{
    public interface IPlan_DyeingProductionLocation_SetupService
    {
        Task<List<SelectListItem>> DDLPlan_DyeingProductionLocation(CancellationToken cancellationToken=default);
        Task<ProductionLocationRM> GetDyeingProductionLocationByID(int LocationID,CancellationToken cancellationToken = default);
    }
}
