using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Setups;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Setups
{
    public class IC_ReturnableItemCategoryService : IIC_ReturnableItemCategoryService
    {
        private readonly IIC_ReturnableItemCategoryRepository iC_ReturnableItemCategoryRepository;

        public IC_ReturnableItemCategoryService(IIC_ReturnableItemCategoryRepository _iC_ReturnableItemCategoryRepository)
        {
            iC_ReturnableItemCategoryRepository = _iC_ReturnableItemCategoryRepository;
        }

        public async Task<List<SelectListItem>> DDLIC_ReturnableItemCategory()
        {
            return await iC_ReturnableItemCategoryRepository.DDLIC_ReturnableItemCategory();
        }
    }
}
