using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Setups;
using RG.DBEntities.MaterialsManagement.Setup;
using RG.Infrastructure.Persistence.MaterialsManagementDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.MaterialsManagement.Setups
{
    public class IC_DocumentCategoriesRepository : GenericRepository<IC_DocumentCategories>, IIC_DocumentCategoriesRepository
    {
        private readonly MaterialsManagementDBContext dbCon;

        public IC_DocumentCategoriesRepository(MaterialsManagementDBContext _dbCon) : base(_dbCon)
        {
            dbCon = _dbCon;
        }

        public async Task<List<SelectListItem>> DDLGetICDocumentCategoriesForAccountsApprovalList(int documentID, CancellationToken cancellationToken)
        {
            var rtnList = await dbCon.IC_DocumentCategories.Where(b => b.DocumentID == documentID && b.IsAccountsApprovalRequired == true)
                .Select(b => new SelectListItem()
                {
                    Text = b.Name,
                    Value = b.ID.ToString()
                }).OrderBy(x => x.Value).ToListAsync(cancellationToken);
            return rtnList;
        }

        public async Task<List<SelectListItem>> DDLGetICDocumentCategoriesList(int documentID, CancellationToken cancellationToken)
        {
            var rtnList = await dbCon.IC_DocumentCategories.Where(b => b.DocumentID == documentID)
                  .Select(b => new SelectListItem()
                  {
                      Text = b.Name,
                      Value = b.ID.ToString()
                  }).OrderBy(x => x.Value).ToListAsync(cancellationToken);
            return rtnList;
        }
    }
}
