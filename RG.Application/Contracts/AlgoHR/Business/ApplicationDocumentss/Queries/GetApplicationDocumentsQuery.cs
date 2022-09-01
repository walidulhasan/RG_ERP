using MediatR;
using RG.Application.Contracts.AlgoHR.Business.ApplicationDocumentss.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.ApplicationDocumentss.Queries
{
    public class GetApplicationDocumentsQuery : IRequest<List<ApplicationDocumentsRM>>
    {
        public int ApplicationID { get; set; }
    }
    public class GetApplicationDocumentsQueryHandler : IRequestHandler<GetApplicationDocumentsQuery, List<ApplicationDocumentsRM>>
    {
        private readonly IApplicationDocumentsService _applicationDocumentsService;

        public GetApplicationDocumentsQueryHandler(IApplicationDocumentsService applicationDocumentsService)
        {
            _applicationDocumentsService = applicationDocumentsService;
        }
        public async Task<List<ApplicationDocumentsRM>> Handle(GetApplicationDocumentsQuery request, CancellationToken cancellationToken)
        {
            return await _applicationDocumentsService.GetDocumentsByApplicationID(request.ApplicationID, cancellationToken);
        }
    }
}
