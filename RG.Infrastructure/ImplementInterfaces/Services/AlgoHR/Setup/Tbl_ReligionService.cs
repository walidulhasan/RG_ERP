using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Setup
{
    public class Tbl_ReligionService : ITbl_ReligionService
    {
        
        private readonly ITbl_ReligionRepository _tbl_ReligionRepository;

        public Tbl_ReligionService(ITbl_ReligionRepository tbl_ReligionRepository)
        {
            
            _tbl_ReligionRepository = tbl_ReligionRepository;
        }
        public async Task<List<SelectListItem>> DDLReligion(CancellationToken cancellationToken)
        {
            return await _tbl_ReligionRepository.DDLReligion(cancellationToken);
        }
    }
}
