using Microsoft.AspNetCore.Mvc.Rendering;
using RG.DBEntities.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.MaterialsManagement.Business
{
    public interface IYarn_POMasterRepository : IGenericRepository<Yarn_POMaster>
    {
        Task<List<SelectListItem>> DDLYarnPONo(int supplierID, DateTime poDateFrom, DateTime poDateTo, string predict = null, CancellationToken cancellationToken = default);
    }
}
