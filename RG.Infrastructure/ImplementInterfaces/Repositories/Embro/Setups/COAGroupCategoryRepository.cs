using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Contracts.Embro.Setups.COAGroupCategorys.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.DBEntities.Embro.Setup;
using RG.Infrastructure.Persistence.EmbroDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Embro.Setups
{
    public class COAGroupCategoryRepository : GenericRepository<COAGroupCategory>, ICOAGroupCategoryRepository
    {
        private readonly EmbroDBContext _dbCon;

        public COAGroupCategoryRepository(EmbroDBContext dbCon):base(dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<List<SelectListItem>> GetDDLGroupCategory(CancellationToken cancellationToken)
        {
            var query =  _dbCon.COAGroupCategorie
                        .Where(x => x.IsActive == true && x.IsRemoved == false)
                        .Select(r => new SelectListItem()
                        {
                            Value = r.GroupCategoryID.ToString(),
                            Text = r.GroupCategoryName.Trim()
                        });
           return await query.ToListAsync();
        }
    }
}
