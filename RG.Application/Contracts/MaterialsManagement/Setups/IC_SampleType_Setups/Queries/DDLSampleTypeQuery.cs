using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.IC_SampleType_Setups.Queries
{
    public class DDLSampleTypeQuery : IRequest<List<SelectListItem>>
    {

    }
    public class DDLSampleTypeQueryHandler : IRequestHandler<DDLSampleTypeQuery, List<SelectListItem>>
    {
        private readonly IIC_SampleType_SetupService _iIC_SampleType_SetupService;

        public DDLSampleTypeQueryHandler(IIC_SampleType_SetupService iIC_SampleType_SetupService)
        {
            _iIC_SampleType_SetupService = iIC_SampleType_SetupService;
        }
        public async Task<List<SelectListItem>> Handle(DDLSampleTypeQuery request, CancellationToken cancellationToken)
        {
            return await _iIC_SampleType_SetupService.DDLSampleType_Setup(cancellationToken);
        }
    }
}
