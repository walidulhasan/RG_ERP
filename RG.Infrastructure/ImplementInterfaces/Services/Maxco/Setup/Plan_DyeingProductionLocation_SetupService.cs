using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Contracts.Maxco.Setup.Plan_DyeingProductionLocation_Setup.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Maxco.Setup;
using RG.Application.Interfaces.Services.Maxco.Setup;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Maxco.Setup
{
    public class Plan_DyeingProductionLocation_SetupService : IPlan_DyeingProductionLocation_SetupService
    {
        private readonly IPlan_DyeingProductionLocation_SetupRepository _plan_DyeingProductionLocation_SetupRepository;

        public Plan_DyeingProductionLocation_SetupService(IPlan_DyeingProductionLocation_SetupRepository plan_DyeingProductionLocation_SetupRepository)
        {
            _plan_DyeingProductionLocation_SetupRepository = plan_DyeingProductionLocation_SetupRepository;
        }

        public async Task<List<SelectListItem>> DDLPlan_DyeingProductionLocation(CancellationToken cancellationToken = default)
        {
            var qryData = await _plan_DyeingProductionLocation_SetupRepository
                       .GetAll()
                       .Where(b => b.IsRemoved == false && b.IsActive == true)
                       .Select(s => new SelectListItem()
                       {
                           Value = s.ProductionLocationID.ToString(),
                           Text = s.LocationName
                       }).ToListAsync(cancellationToken);
            return qryData;
        }

        public async Task<ProductionLocationRM> GetDyeingProductionLocationByID(int LocationID, CancellationToken cancellationToken = default)
        {
            return await _plan_DyeingProductionLocation_SetupRepository.GetAll()
                .Where(b=>b.ProductionLocationID==LocationID)
                .Select(s=>new ProductionLocationRM()
                {
                    ID = s.ProductionLocationID,
                    LocationName=s.LocationName
                }).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
