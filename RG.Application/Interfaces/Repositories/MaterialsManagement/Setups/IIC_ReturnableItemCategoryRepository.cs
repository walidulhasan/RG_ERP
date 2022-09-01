using Microsoft.AspNetCore.Mvc.Rendering;
using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.MaterialsManagement.Setups
{
    public interface IIC_ReturnableItemCategoryRepository : IGenericRepository<IC_ReturnableItemCategory>
    {
        Task<List<SelectListItem>> DDLIC_ReturnableItemCategory();
    }
}
