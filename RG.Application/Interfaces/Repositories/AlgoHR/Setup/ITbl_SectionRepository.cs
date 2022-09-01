using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Utilities;
using RG.DBEntities.AlgoHR.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AlgoHR.Setup
{
    public interface ITbl_SectionRepository : IGenericRepository<Tbl_Section>
    {
        Task<List<SelectListItem>> DDLSection(int departmentID, CancellationToken cancellationToken = default);
        Task<List<SelectListItem>> DDLSection(List<int> departmentID, string Predict = null, CancellationToken cancellationToken = default);
        Task<List<IdNamePairRM>> DDLSectionLookup(List<int> departmentID, string Predict = null, CancellationToken cancellationToken = default);
    }
}
