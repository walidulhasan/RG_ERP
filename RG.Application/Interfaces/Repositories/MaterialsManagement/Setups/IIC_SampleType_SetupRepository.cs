using Microsoft.AspNetCore.Mvc.Rendering;
using RG.DBEntities.MaterialsManagement.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.MaterialsManagement.Setups
{
    public interface IIC_SampleType_SetupRepository : IGenericRepository<IC_SampleType_Setup>
    {
        Task<List<SelectListItem>> DDLSampleType_Setup(CancellationToken cancellationToken = default);

    }
}
