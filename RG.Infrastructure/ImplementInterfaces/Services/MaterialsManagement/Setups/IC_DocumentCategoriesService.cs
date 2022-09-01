using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Setups;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Setups
{
    public class IC_DocumentCategoriesService : IIC_DocumentCategoriesService
    {
        private readonly IIC_DocumentCategoriesRepository iC_DocumentCategoriesRepository;

        public IC_DocumentCategoriesService(IIC_DocumentCategoriesRepository _iC_DocumentCategoriesRepository)
        {
            iC_DocumentCategoriesRepository = _iC_DocumentCategoriesRepository;
        }

        public async Task<List<SelectListItem>> DDLGetICDocumentCategoriesForAccountsApprovalList(int documentID, CancellationToken cancellationToken)
        {
            return await iC_DocumentCategoriesRepository.DDLGetICDocumentCategoriesForAccountsApprovalList(documentID, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLGetICDocumentCategoriesList(int documentID, CancellationToken cancellationToken)
        {
            return await iC_DocumentCategoriesRepository.DDLGetICDocumentCategoriesList(documentID, cancellationToken);
        }
    }
}
