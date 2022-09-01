using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Setups;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Setups
{
    public class IC_SampleType_SetupService : IIC_SampleType_SetupService
    {
        private readonly IIC_SampleType_SetupRepository _iIC_SampleType_SetupRepository;

        public IC_SampleType_SetupService(IIC_SampleType_SetupRepository iIC_SampleType_SetupRepository)
        {
            _iIC_SampleType_SetupRepository = iIC_SampleType_SetupRepository;
        }
        public async Task<List<SelectListItem>> DDLSampleType_Setup(CancellationToken cancellationToken = default)
        {
            return await _iIC_SampleType_SetupRepository.DDLSampleType_Setup(cancellationToken);
        }
    }
}
