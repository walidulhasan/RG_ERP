using Microsoft.AspNetCore.Mvc.Rendering;
using RG.DBEntities.MaterialsManagement.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.MaterialsManagement.Setups
{
    public interface IIC_DocumentCategoriesRepository : IGenericRepository<IC_DocumentCategories>
    {
        Task<List<SelectListItem>> DDLGetICDocumentCategoriesList(int documentID, CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLGetICDocumentCategoriesForAccountsApprovalList(int documentID, CancellationToken cancellationToken);
    }
}
