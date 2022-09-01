using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.YarnSubRackSetup.Queries
{
   
    public class GetCustomDDLRackWiseSubRackQuery : IRequest<List<DropDownItem>>
    {
        public int RackID { get; set; }
        public bool WithStorageLimit { get; set; } = false;
    }
    public class GetCustomDDLRackWiseSubRackQueryHandler : IRequestHandler<GetCustomDDLRackWiseSubRackQuery, List<DropDownItem>>
    {
        private readonly IYarnSubRackSetupService _yarnSubRackSetupService;

        public GetCustomDDLRackWiseSubRackQueryHandler(IYarnSubRackSetupService yarnSubRackSetupService)
        {
            _yarnSubRackSetupService = yarnSubRackSetupService;
        }
        public async Task<List<DropDownItem>> Handle(GetCustomDDLRackWiseSubRackQuery request, CancellationToken cancellationToken)
        {
            return await _yarnSubRackSetupService.CustomDDLRackWiseSubRack(request.RackID, request.WithStorageLimit, cancellationToken);
        }
    }
}
