using Microsoft.AspNetCore.Mvc.Rendering;
using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Embro.Setups
{
    public interface ICOAGroupCategoryRepository : IGenericRepository<COAGroupCategory>
    {
        Task<List<SelectListItem>> GetDDLGroupCategory(CancellationToken cancellationToken);
    }
}
