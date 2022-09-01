using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Setup
{
    public interface ITbl_ReligionService
    {
        Task<List<SelectListItem>> DDLReligion(CancellationToken cancellationToken);
    }
}
