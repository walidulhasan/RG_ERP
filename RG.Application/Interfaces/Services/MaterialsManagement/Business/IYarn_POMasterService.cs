using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.MaterialsManagement.Business
{
    public interface IYarn_POMasterService
    {
        Task<List<SelectListItem>> DDLYarnPONo(int supplierID, DateTime poDateFrom, DateTime poDateTo, string predict = null, CancellationToken cancellationToken = default);
    }
}
