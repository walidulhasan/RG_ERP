using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.MaterialsManagement.Setups
{
    public interface IIC_SampleType_SetupService
    {
        Task<List<SelectListItem>> DDLSampleType_Setup(CancellationToken cancellationToken = default);
    }
}
