using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Maxco.Setup
{
    public interface IOrderClassificationService
    {
        Task<List<SelectListItem>> DDLOrderClassification(CancellationToken cancellationToken);
    }
}
