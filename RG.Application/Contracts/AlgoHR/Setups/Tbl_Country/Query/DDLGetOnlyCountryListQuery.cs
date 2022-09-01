using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.Tbl_Country.Query
{
    public class DDLGetOnlyCountryListQuery:IRequest<List<SelectListItem>>
    {
    }
    public class DDLGetOnlyCountryListQueryHandler : IRequestHandler<DDLGetOnlyCountryListQuery, List<SelectListItem>>
    {
        private readonly ITbl_CountryService _tbl_CountryService;

        public DDLGetOnlyCountryListQueryHandler(ITbl_CountryService tbl_CountryService)
        {
            _tbl_CountryService = tbl_CountryService;
        }
        public async Task<List<SelectListItem>> Handle(DDLGetOnlyCountryListQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_CountryService.DDLGetOnluCountryList(cancellationToken);
        }
    }
}
