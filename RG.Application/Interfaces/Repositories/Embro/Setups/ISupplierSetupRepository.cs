using Microsoft.AspNetCore.Mvc.Rendering;
using RG.DBEntities.Embro.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Embro.Setups
{
    public interface ISupplierSetupRepository : IGenericRepository<SupplierSetup>
    {
        Task<List<SelectListItem>> DDLGetSupplierList(int companyID, List<int> AccCategoryID = null,List<int> NotInSupplier=null , string Predict = null, CancellationToken cancellationToken = default);
        Task<List<SelectListItem>> DDLSuppliers(int companyID, List<int> AccCategoryID = null, List<int> NotInSupplier = null, string Predict = null, CancellationToken cancellationToken = default);

    }
}
