using Microsoft.AspNetCore.Mvc.Rendering;
using RG.DBEntities.MaterialsManagement.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.MaterialsManagement.Setups
{
    public interface IIC_UnitSetupRepository : IGenericRepository<IC_UnitSetup>
    {
        Task<List<SelectListItem>> DDLGetAllIC_UnitList(List<string>withShortName, CancellationToken cancellationToken);
    }
}
