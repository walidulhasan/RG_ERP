using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.Maxco.Setup;
using RG.DBEntities.Maxco.Setup;
using RG.Infrastructure.Persistence.MaxcoDB;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Maxco.Setup
{
    public class Country_Assorment_SetupRepository : GenericRepository<Country_Assorment_Setup>, ICountry_Assorment_SetupRepository
    {
        private readonly MaxcoDBContext dbCon;

        public Country_Assorment_SetupRepository(MaxcoDBContext _dbCon) : base(_dbCon)
        {
            dbCon = _dbCon;
        }
        public async Task<List<SelectListItem>> DDLGetCountryList(CancellationToken cancellationToken)
        {
            var list = await dbCon.Country_Assorment_Setup
                .Select(b => new SelectListItem()
                {
                    Text = $"{b.Country_Name}-({b.Country_Abbrevation})",
                    Value = b.Country_ID.ToString()
                }).OrderBy(o => o.Value).ToListAsync();
            return list;
        }
    }
}
