using Microsoft.AspNetCore.Mvc.Rendering;
using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.MaterialsManagement.Setups
{
    public interface IIC_DepartmentRepository : IGenericRepository<IC_Department>
    {
        Task<List<SelectListItem>> DDLGetDepartmentByUserID(int userID, CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLGetDepartmentList(CancellationToken cancellationToken, int ID = 0);
        Task<List<IC_Department>> GetAllData();

    }
}
