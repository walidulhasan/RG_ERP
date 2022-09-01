using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.Embro.Setups.LoanTypes.Queries.RequestResponseModel;
using RG.Application.ViewModel.Embro.Setup.LoanType;
using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Embro.Setups
{
    public interface ILoanTypeRepository:IGenericRepository<LoanType>
    {
        Task<int> MaxTableId();
        IQueryable<LoanTypeRM> GetAllGridData();
        Task<bool> IsDuplicateValue(LoanTypeCreateVM model);
        Task<List<SelectListItem>> DDLLoanTypeName(CancellationToken cancellationToken);
    }
}
