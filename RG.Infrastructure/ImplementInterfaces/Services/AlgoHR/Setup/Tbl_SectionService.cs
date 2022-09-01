using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Utilities;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Setup
{
    public class Tbl_SectionService : ITbl_SectionService
    {
        private readonly ITbl_SectionRepository _tbl_SectionRepository;

        public Tbl_SectionService(ITbl_SectionRepository tbl_SectionRepository)
        {
            _tbl_SectionRepository = tbl_SectionRepository;
        }
        public async Task<List<SelectListItem>> DDLSection(int departmentID, CancellationToken cancellationToken = default)
        {
            return await _tbl_SectionRepository.DDLSection(departmentID, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLSection(List<int> departmentID, string Predict = null, CancellationToken cancellationToken = default)
        {
            return await _tbl_SectionRepository.DDLSection(departmentID, Predict, cancellationToken);
        }

        public async Task<List<IdNamePairRM>> DDLSectionLookup(List<int> departmentID, string Predict = null, CancellationToken cancellationToken = default)
        {
            return await _tbl_SectionRepository.DDLSectionLookup(departmentID, Predict, cancellationToken);
        }
    }
}
