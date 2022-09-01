using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.Application.Interfaces.Services.Embro.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Embro.Setups
{
    public class COAGroupCategoryService : ICOAGroupCategoryService
    {
        private readonly ICOAGroupCategoryRepository _cOAGroupCategoryRepository;

        public COAGroupCategoryService(ICOAGroupCategoryRepository cOAGroupCategoryRepository)
        {
            _cOAGroupCategoryRepository = cOAGroupCategoryRepository;
        }
        public async Task<List<SelectListItem>> GetDDLGroupCategory(CancellationToken cancellationToken)
        {
            return await _cOAGroupCategoryRepository.GetDDLGroupCategory(cancellationToken);
        }
    }
}
