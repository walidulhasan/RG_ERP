using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.ApplicationDocumentss.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using RG.DBEntities.AlgoHR.Business;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Business
{
    public class ApplicationDocumentsService : IApplicationDocumentsService
    {
        private readonly IApplicationDocumentsRepository _applicationDocumentsRepository;

        public ApplicationDocumentsService(IApplicationDocumentsRepository applicationDocumentsRepository)
        {
            _applicationDocumentsRepository = applicationDocumentsRepository;
        }

        public async Task<List<ApplicationDocumentsRM>> GetDocumentsByApplicationID(int applicationID, CancellationToken cancellationToken = default)
        {
            return await _applicationDocumentsRepository.GetDocumentsByApplicationID(applicationID, cancellationToken);
        }

        public async Task<RResult> SaveApplicationDocuments(List<ApplicationDocuments> docs, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            return await _applicationDocumentsRepository.SaveApplicationDocuments(docs, saveChanges, cancellationToken);
        }
    }
}
