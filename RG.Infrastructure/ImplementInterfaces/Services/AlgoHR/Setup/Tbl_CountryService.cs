using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Setup
{
    public class Tbl_CountryService : ITbl_CountryService
    {
        private readonly ITbl_CountryRepository _tbl_CountryRepository;

        public Tbl_CountryService(ITbl_CountryRepository tbl_CountryRepository)
        {
            _tbl_CountryRepository = tbl_CountryRepository;
        }
        public async Task<List<SelectListItem>> DDLGetOnluCountryList(CancellationToken cancellationToken)
        {
            return await _tbl_CountryRepository.DDLGetOnlyCountryList(cancellationToken);
        }
    }
}
