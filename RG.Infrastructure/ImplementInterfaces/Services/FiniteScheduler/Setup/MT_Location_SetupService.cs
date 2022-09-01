using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.FiniteScheduler.Setup
{
    public class MT_Location_SetupService : IMT_Location_SetupService
    {
        private readonly IMT_Location_SetupRepository mt_Location_SetupRepository;

        public MT_Location_SetupService(IMT_Location_SetupRepository _mt_Location_SetupRepository)
        {
            mt_Location_SetupRepository = _mt_Location_SetupRepository;
        }
        public async Task<List<SelectListItem>> DDLCompanyWiseLocation(int companyID, CancellationToken cancellationToken)
        {
            return await mt_Location_SetupRepository.DDLCompanyWiseLocation(companyID, cancellationToken);
        }
    }
}
