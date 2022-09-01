using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.UploadedDocumentTypes.Queries
{
    public class GetDDLUploadedDocumentTypeQuery:IRequest<List<SelectListItem>>
    {
        public string ModuleName { get; set; }
    }
    public class GetDDLUploadedDocumentTypeQueryHandler : IRequestHandler<GetDDLUploadedDocumentTypeQuery,List<SelectListItem>>
    {
        private readonly IUploadedDocumentTypeService _uploadedDocumentTypeService;

        public GetDDLUploadedDocumentTypeQueryHandler(IUploadedDocumentTypeService uploadedDocumentTypeService)
        {
            _uploadedDocumentTypeService = uploadedDocumentTypeService;
        }

        public async Task<List<SelectListItem>> Handle(GetDDLUploadedDocumentTypeQuery request, CancellationToken cancellationToken)
        {
            return await _uploadedDocumentTypeService.DDLUploadedDocumentType(request.ModuleName, cancellationToken);
        }
    }
}
