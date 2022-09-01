using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.Embro.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.COAGroupCategorys.Queries
{
    public class GetDDLCOAGroupCategoryQuery : IRequest<List<SelectListItem>>
    {
    }
    public class GetDDLGroupCategoryQueryHandler : IRequestHandler<GetDDLCOAGroupCategoryQuery, List<SelectListItem>>
    {
        private readonly ICOAGroupCategoryService _cOAGroupCategoryService;

        public GetDDLGroupCategoryQueryHandler(ICOAGroupCategoryService cOAGroupCategoryService)
        {
            _cOAGroupCategoryService = cOAGroupCategoryService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLCOAGroupCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _cOAGroupCategoryService.GetDDLGroupCategory(cancellationToken);
        }
    }
}
