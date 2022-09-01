using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Setup
{
    public class UploadedDocumentTypeService : IUploadedDocumentTypeService
    {
        private readonly IUploadedDocumentTypeRepository _uploadedDocumentTypeRepository;

        public UploadedDocumentTypeService(IUploadedDocumentTypeRepository uploadedDocumentTypeRepository)
        {
            _uploadedDocumentTypeRepository = uploadedDocumentTypeRepository;
        }
        public async Task<List<SelectListItem>> DDLUploadedDocumentType(string modeuleName, CancellationToken cancellationToken = default)
        {
            return await _uploadedDocumentTypeRepository.DDLUploadedDocumentType(modeuleName, cancellationToken);
        }
    }
}
