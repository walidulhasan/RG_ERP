using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.FloorTypes.Quries
{
    public class GetDDLFloorTypeQuery:IRequest<List<SelectListItem>>
    {
    }
    public class GetDDLFloorTypeQueryHandler : IRequestHandler<GetDDLFloorTypeQuery, List<SelectListItem>>
    {
        private readonly IFloorTypeService _floorTypeService;

        public GetDDLFloorTypeQueryHandler(IFloorTypeService floorTypeService)
        {
            _floorTypeService = floorTypeService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLFloorTypeQuery request, CancellationToken cancellationToken)
        {
            return await _floorTypeService.GetDDLFloorType(cancellationToken);
        }
    }
}
