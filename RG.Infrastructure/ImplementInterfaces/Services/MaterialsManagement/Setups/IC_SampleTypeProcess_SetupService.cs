using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Setups;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Setups
{
    public class IC_SampleTypeProcess_SetupService : IIC_SampleTypeProcess_SetupService
    {
        private readonly IIC_SampleTypeProcess_SetupRepository _iIC_SampleTypeProcess_SetupRepository;
        private readonly IMapper mapper;

        public IC_SampleTypeProcess_SetupService(IIC_SampleTypeProcess_SetupRepository iIC_SampleTypeProcess_SetupRepository, IMapper _mapper)
        {
            _iIC_SampleTypeProcess_SetupRepository = iIC_SampleTypeProcess_SetupRepository;
            mapper = _mapper;
        }

        public async Task<List<DropDownItem>> DDLCustomSampleTypeProcess(int SampleTypeID, CancellationToken cancellationToken = default)
        {
            return await _iIC_SampleTypeProcess_SetupRepository.DDLCustomSampleTypeProcess(SampleTypeID, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLSampleTypeProcess(int SampleTypeID, CancellationToken cancellationToken = default)
        {
            return await _iIC_SampleTypeProcess_SetupRepository.DDLSampleTypeProcess(SampleTypeID, cancellationToken);
        }
    }
}
