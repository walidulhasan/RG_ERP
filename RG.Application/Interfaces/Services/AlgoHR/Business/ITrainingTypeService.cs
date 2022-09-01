using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Business
{
    public interface ITrainingTypeService
    {
        Task<List<SelectListItem>> DDLTrainingType(CancellationToken cancellationToken);
    }
}
