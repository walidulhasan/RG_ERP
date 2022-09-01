using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.TrainingTypes.Queries
{
    public class GetDDLTrainingTypeQuery:IRequest<List<SelectListItem>>
    {
    }
    public class GetDDLTrainingTypeQueryHandler : IRequestHandler<GetDDLTrainingTypeQuery, List<SelectListItem>>
    {
        private readonly ITrainingTypeService _trainingTypeService;

        public GetDDLTrainingTypeQueryHandler(ITrainingTypeService trainingTypeService)
        {
            _trainingTypeService = trainingTypeService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLTrainingTypeQuery request, CancellationToken cancellationToken)
        {
            return await _trainingTypeService.DDLTrainingType(cancellationToken);
        }
    }
}
