using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.IC_SampleTypeProcess_Setups.Queries
{
    public class DDLCustomSampleTypeProcessQuery : IRequest<List<DropDownItem>>
    {
        public int SampleTypeID { get; set; }
    }
    public class DDLCustomSampleTypeProcessQueryHandler : IRequestHandler<DDLCustomSampleTypeProcessQuery, List<DropDownItem>>
    {
        private readonly IIC_SampleTypeProcess_SetupService iC_SampleTypeProcess_SetupService;
        public DDLCustomSampleTypeProcessQueryHandler(IIC_SampleTypeProcess_SetupService _iC_SampleTypeProcess_SetupService)
        {
            iC_SampleTypeProcess_SetupService = _iC_SampleTypeProcess_SetupService;
        }
        public async Task<List<DropDownItem>> Handle(DDLCustomSampleTypeProcessQuery request, CancellationToken cancellationToken)
        {
            return await iC_SampleTypeProcess_SetupService.DDLCustomSampleTypeProcess(request.SampleTypeID, cancellationToken);
        }
    }
}
