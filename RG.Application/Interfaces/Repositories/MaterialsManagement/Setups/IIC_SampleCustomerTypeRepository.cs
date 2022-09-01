using Microsoft.AspNetCore.Mvc.Rendering;
using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.MaterialsManagement.Setups
{
    public interface IIC_SampleCustomerTypeRepository : IGenericRepository<IC_SampleCustomerType>
    {
        Task<List<SelectListItem>> DDLSampleCustomerType(CancellationToken cancellationToken = default);
    }
}

