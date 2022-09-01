using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Setup.Country_Assorment_Setups.Queries
{
    public class DDLGetCountryListQuery : IRequest<List<SelectListItem>>
    {

    }
    public class DDLGetCountryListQueryHandler : IRequestHandler<DDLGetCountryListQuery, List<SelectListItem>>
    {
        private readonly ICountry_Assorment_SetupService country_Assorment_SetupService;

        public DDLGetCountryListQueryHandler(ICountry_Assorment_SetupService _country_Assorment_SetupService)
        {
            country_Assorment_SetupService = _country_Assorment_SetupService;
        }
        public async Task<List<SelectListItem>> Handle(DDLGetCountryListQuery request, CancellationToken cancellationToken)
        {
            return await country_Assorment_SetupService.DDLGetCountryList(cancellationToken);
        }
    }
}
