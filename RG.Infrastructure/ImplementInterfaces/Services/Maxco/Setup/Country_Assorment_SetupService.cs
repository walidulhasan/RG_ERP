using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.Maxco.Setup;
using RG.Application.Interfaces.Services.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Maxco.Setup
{
    public class Country_Assorment_SetupService : ICountry_Assorment_SetupService
    {
        private readonly ICountry_Assorment_SetupRepository country_Assorment_SetupRepository;

        public Country_Assorment_SetupService(ICountry_Assorment_SetupRepository _country_Assorment_SetupRepository)
        {
            country_Assorment_SetupRepository = _country_Assorment_SetupRepository;
        }
        public async Task<List<SelectListItem>> DDLGetCountryList(CancellationToken cancellationToken)
        {
            return await country_Assorment_SetupRepository.DDLGetCountryList(cancellationToken);
        }
    }
}
