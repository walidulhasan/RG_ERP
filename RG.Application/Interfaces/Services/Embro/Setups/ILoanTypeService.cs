using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.Embro.Setups.LoanTypes.Queries.RequestResponseModel;
using RG.Application.ViewModel.Embro.Setup.LoanType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Embro.Setups
{
    public interface ILoanTypeService
    {
        Task<RResult> SaveAndUpdate(LoanTypeCreateVM model);
        IQueryable<LoanTypeRM> GetAllGridData();
        Task<RResult> Remove(int id, bool saveChange);
        Task<List<SelectListItem>> DDLLoanTypeName(CancellationToken cancellationToken);
    }
}
