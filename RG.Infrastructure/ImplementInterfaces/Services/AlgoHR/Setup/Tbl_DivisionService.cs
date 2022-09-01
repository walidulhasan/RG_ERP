using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Utilities;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Setup
{
    public class Tbl_DivisionService : ITbl_DivisionService
    {
        private readonly ITbl_DivisionRepository _tbl_DivisionRepository;

        public Tbl_DivisionService(ITbl_DivisionRepository tbl_DivisionRepository)
        {
            _tbl_DivisionRepository = tbl_DivisionRepository;
        }

        public async Task<List<SelectListItem>> DDLDivision(int embroCompanyID, List<int> exceptDivision, string Predict = null, CancellationToken cancellationToken = default)
        {
            return await _tbl_DivisionRepository.DDLDivision(embroCompanyID, exceptDivision, Predict, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLDivision(List<int> embroCompanyID, List<int> exceptDivision, string Predict = null, CancellationToken cancellationToken = default)
        {
            return await _tbl_DivisionRepository.DDLDivision(embroCompanyID, exceptDivision, Predict, cancellationToken);
        }

        public async Task<List<IdNamePairRM>> DDLDivisionLookUp(List<int> embroCompanyID, List<int> exceptDivision, string Predict = null, CancellationToken cancellationToken = default)
        {
            return await _tbl_DivisionRepository.DDLDivisionLookUp(embroCompanyID, exceptDivision, Predict, cancellationToken);
        }
    }
}
