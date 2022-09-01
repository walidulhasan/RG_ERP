using Microsoft.AspNetCore.Mvc.Rendering;
using RG.DBEntities.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Business
{
    public  interface IAssetDepartmentRepository:IGenericRepository<AssetDepartment>
    {
        Task<List<SelectListItem>> GetDivisionWiseDDLDepartment(int DivisionWiseID, string Predict = null, CancellationToken cancellationToken = default);
    }
}
