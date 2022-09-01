using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.YarnRackSetups.Queries
{
    public class DDLLotNowithRackWiseLotnoQuery:IRequest<List<SelectListItem>>
    {
        public int RackID { get; set; }
        public string Predict { get; set; }
    }
    public class DDLLotNowithRackWiseLotnoQueryHandler : IRequestHandler<DDLLotNowithRackWiseLotnoQuery, List<SelectListItem>>
    {
        private readonly IYarnRackSetupService _yarnRackSetupService;

        public DDLLotNowithRackWiseLotnoQueryHandler(IYarnRackSetupService yarnRackSetupService)
        {
            _yarnRackSetupService = yarnRackSetupService;
        }
        public async Task<List<SelectListItem>> Handle(DDLLotNowithRackWiseLotnoQuery request, CancellationToken cancellationToken)
        {
            return await _yarnRackSetupService.DDLLotNowithRackWiseLotno(request.RackID,request.Predict,cancellationToken);
        }
    }
}
