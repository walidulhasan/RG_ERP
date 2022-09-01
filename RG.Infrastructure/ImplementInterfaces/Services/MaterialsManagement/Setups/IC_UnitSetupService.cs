using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Setups;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Setups
{
    public class IC_UnitSetupService : IIC_UnitSetupService
    {
        private readonly IIC_UnitSetupRepository iC_UnitSetupRepository;

        public IC_UnitSetupService(IIC_UnitSetupRepository _iC_UnitSetupRepository)
        {
            iC_UnitSetupRepository = _iC_UnitSetupRepository;
        }
        public async Task<List<SelectListItem>> DDLGetAllIC_UnitList(List<string> withShortName, CancellationToken cancellationToken)
        {
            return await iC_UnitSetupRepository.DDLGetAllIC_UnitList(withShortName, cancellationToken);
        }
    }
}
