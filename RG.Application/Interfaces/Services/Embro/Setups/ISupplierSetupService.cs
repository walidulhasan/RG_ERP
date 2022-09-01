using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.Embro.Setups.SupplierSetups.Queries.RequestResponseModel;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Embro.Setups
{
    public interface ISupplierSetupService
    {
        Task<List<SelectListItem>> DDLGetSupplierList(int companyID, List<int> AccCategoryID = null, List<int> NotInSupplier = null, string Predict = null, CancellationToken cancellationToken = default);
        Task<SupplierSetupRM> GetSupplierInfo(int id);
        Task<List<SelectListItem>> DDLSuppliers(int companyID, List<int> AccCategoryID = null, List<int> NotInSupplier = null, string Predict = null, CancellationToken cancellationToken = default);
    }
}
