using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.IC_DocumentCategoriess.Queries
{
    public class GetDDLICDocumentCategoriesForAccountsApprovalQuery : IRequest<List<SelectListItem>>
    {
        public int DocumentID { get { return 1; } }
    }
    public class GetDDLICDocumentCategoriesForAccountsApprovalQueryHandler : IRequestHandler<GetDDLICDocumentCategoriesForAccountsApprovalQuery, List<SelectListItem>>
    {
        private readonly IIC_DocumentCategoriesService iC_DocumentCategoriesService;
        public GetDDLICDocumentCategoriesForAccountsApprovalQueryHandler(IIC_DocumentCategoriesService _iC_DocumentCategoriesService)
        {
            iC_DocumentCategoriesService = _iC_DocumentCategoriesService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLICDocumentCategoriesForAccountsApprovalQuery request, CancellationToken cancellationToken)
        {
            return await iC_DocumentCategoriesService.DDLGetICDocumentCategoriesForAccountsApprovalList(request.DocumentID, cancellationToken);
        }
    }
}
