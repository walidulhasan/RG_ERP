using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.YarnSubRackSetup.Queries
{
    public class GetDDLRackWiseSubRackQuery : IRequest<List<SelectListItem>>
    {
        public int RackID { get; set; }
        public bool WithStorageLimit { get; set; } = false;
    }
    public class GetDDLRackWiseSubRackQueryHandler : IRequestHandler<GetDDLRackWiseSubRackQuery, List<SelectListItem>>
    {
        private readonly IYarnSubRackSetupService _yarnSubRackSetupService;

        public GetDDLRackWiseSubRackQueryHandler(IYarnSubRackSetupService yarnSubRackSetupService)
        {
            _yarnSubRackSetupService = yarnSubRackSetupService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLRackWiseSubRackQuery request, CancellationToken cancellationToken)
        {
            return await _yarnSubRackSetupService.DDLRackWiseSubRack(request.RackID,request.WithStorageLimit, cancellationToken);
        }
    }
}
