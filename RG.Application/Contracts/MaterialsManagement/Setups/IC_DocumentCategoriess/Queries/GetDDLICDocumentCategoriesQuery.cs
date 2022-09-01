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
    public class GetDDLICDocumentCategoriesQuery : IRequest<List<SelectListItem>>
    {
        public static int DocumentID { get { return 1; } }
    }
    public class GetDDLICDocumentCategoriesQueryHandler : IRequestHandler<GetDDLICDocumentCategoriesQuery, List<SelectListItem>>
    {
        private readonly IIC_DocumentCategoriesService iC_DocumentCategoriesService;

        public GetDDLICDocumentCategoriesQueryHandler(IIC_DocumentCategoriesService _iC_DocumentCategoriesService)
        {
            iC_DocumentCategoriesService = _iC_DocumentCategoriesService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLICDocumentCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await iC_DocumentCategoriesService.DDLGetICDocumentCategoriesList(GetDDLICDocumentCategoriesQuery.DocumentID, cancellationToken);
        }
    }
}
