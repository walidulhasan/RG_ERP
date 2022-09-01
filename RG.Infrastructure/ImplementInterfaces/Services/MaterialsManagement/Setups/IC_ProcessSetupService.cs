using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Setups;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Setups
{
    public class IC_ProcessSetupService : IIC_ProcessSetupService
    {
        private readonly IIC_ProcessSetupRepository iC_ProcessSetupRepository;
        public IC_ProcessSetupService(IIC_ProcessSetupRepository _iC_ProcessSetupRepository)
        {
            iC_ProcessSetupRepository = _iC_ProcessSetupRepository;
        }

        public async Task<List<SelectListItem>> GetDDLIC_ProcessSetup()
        {
            return await iC_ProcessSetupRepository.GetDDLIC_ProcessSetup();
        }
    }
}
