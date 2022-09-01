using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.IC_ReturnableItemCategorys.Queries
{
    public class GetDDLIC_ReturnableItemCategoryQuery : IRequest<List<SelectListItem>>
    {
    }
    public class GetDDLIC_ReturnableItemCategoryQueryHandler : IRequestHandler<GetDDLIC_ReturnableItemCategoryQuery, List<SelectListItem>>
    {
        private readonly IIC_ReturnableItemCategoryService iC_ReturnableItemCategoryService;
        public GetDDLIC_ReturnableItemCategoryQueryHandler(IIC_ReturnableItemCategoryService _iC_ReturnableItemCategoryService)
        {
            iC_ReturnableItemCategoryService = _iC_ReturnableItemCategoryService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLIC_ReturnableItemCategoryQuery request, CancellationToken cancellationToken)
        {
            return await iC_ReturnableItemCategoryService.DDLIC_ReturnableItemCategory();
        }
    }
}
