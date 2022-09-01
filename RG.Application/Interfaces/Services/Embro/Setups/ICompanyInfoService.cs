using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Embro.Setups
{
    public interface ICompanyInfoService
    {
        Task<List<SelectListItem>> DDLCompany(CancellationToken cancellationToken);
    }
}
