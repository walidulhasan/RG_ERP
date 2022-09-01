using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.IC_SampleTypeProcess_Setups.Queries
{
    public class GetDDLIC_ProcessSetupQuery : IRequest<List<SelectListItem>>
    {
    }
    public class GetDDLIC_ProcessSetupQueryHandler : IRequestHandler<GetDDLIC_ProcessSetupQuery, List<SelectListItem>>
    {
        private readonly IIC_ProcessSetupService iC_ProcessSetupService;
        public GetDDLIC_ProcessSetupQueryHandler(IIC_ProcessSetupService _iC_ProcessSetupService)
        {
            iC_ProcessSetupService = _iC_ProcessSetupService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLIC_ProcessSetupQuery request, CancellationToken cancellationToken)
        {
            return await iC_ProcessSetupService.GetDDLIC_ProcessSetup();
        }
    }
}
