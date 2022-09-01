using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Setups;
using RG.DBEntities.MaterialsManagement.Setup;
using RG.Infrastructure.Persistence.MaterialsManagementDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.MaterialsManagement.Setups
{
    public class IC_ReturnableItemCategoryRepository : GenericRepository<IC_ReturnableItemCategory>, IIC_ReturnableItemCategoryRepository
    {
        private readonly MaterialsManagementDBContext dbCon;
        public IC_ReturnableItemCategoryRepository(MaterialsManagementDBContext _dbCon) : base(_dbCon)
        {
            dbCon = _dbCon;
        }
        public async Task<List<SelectListItem>> DDLIC_ReturnableItemCategory()
        {
            var data = await dbCon.IC_ReturnableItemCategory.Select(x => new SelectListItem
            {
                Text = x.ReturnableItemCategoryName,
                Value = x.ReturnableItemCategoryID.ToString()
            }).ToListAsync();
            return data;
        }
    }
}
