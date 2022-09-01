using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.Maxco.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Setup.OrderClassifications.Queries
{
    public class GetDDLOrderClassificationQuery : IRequest<List<SelectListItem>>
    {
    }
    public class GetDDLOrderClassificationQueryHandler : IRequestHandler<GetDDLOrderClassificationQuery, List<SelectListItem>>
    {
        private readonly IOrderClassificationService orderClassificationService;

        public GetDDLOrderClassificationQueryHandler(IOrderClassificationService _orderClassificationService)
        {
            orderClassificationService = _orderClassificationService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLOrderClassificationQuery request, CancellationToken cancellationToken)
        {
            return await orderClassificationService.DDLOrderClassification(cancellationToken);
        }
    }
}
