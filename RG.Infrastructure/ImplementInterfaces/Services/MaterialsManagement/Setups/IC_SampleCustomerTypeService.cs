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
    public class IC_SampleCustomerTypeService : IIC_SampleCustomerTypeService
    {
        private readonly IIC_SampleCustomerTypeRepository iC_SampleCustomerTypeRepository;

        public IC_SampleCustomerTypeService(IIC_SampleCustomerTypeRepository _iC_SampleCustomerTypeRepository)
        {
            iC_SampleCustomerTypeRepository = _iC_SampleCustomerTypeRepository;
        }
        public async Task<List<SelectListItem>> DDLSampleCustomerType(CancellationToken cancellationToken = default)
        {
            return await iC_SampleCustomerTypeRepository.DDLSampleCustomerType(cancellationToken);
        }
    }
}
