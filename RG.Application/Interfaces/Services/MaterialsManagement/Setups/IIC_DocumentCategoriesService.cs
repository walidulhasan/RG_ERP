using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.MaterialsManagement.Setups
{
    public interface IIC_DocumentCategoriesService
    {
        Task<List<SelectListItem>> DDLGetICDocumentCategoriesList(int documentID, CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLGetICDocumentCategoriesForAccountsApprovalList(int documentID, CancellationToken cancellationToken);
    }
}
