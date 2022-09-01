using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.FiniteScheduler.Setup
{
    public interface IAssetFunctionalStatusService
    {
        Task<List<SelectListItem>> DDLAssetFunctionalStatus(CancellationToken cancellationToken);
    }
}
