using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.MaterialsManagement.Setups
{
    public interface IIC_ReturnableItemCategoryService
    {
        Task<List<SelectListItem>> DDLIC_ReturnableItemCategory();
    }
}
