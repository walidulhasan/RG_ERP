using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_Departments.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Setups;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Setups
{
    public class IC_DepartmentService : IIC_DepartmentService
    {
        private readonly IIC_DepartmentRepository iC_DepartmentRepository;

        public IC_DepartmentService(IIC_DepartmentRepository _iC_DepartmentRepository)
        {
            iC_DepartmentRepository = _iC_DepartmentRepository;
        }
        public async Task<List<SelectListItem>> DDLGetDepartmentByUserID(int userID, CancellationToken cancellationToken)
        {
            return await iC_DepartmentRepository.DDLGetDepartmentByUserID(userID, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLGetDepartmentList(CancellationToken cancellationToken, int ID = 0)
        {
            return await iC_DepartmentRepository.DDLGetDepartmentList(cancellationToken, ID);
        }

        public async Task<IC_DepartmentRM> GetDepartmentInfo(long DepartmentID, CancellationToken cancellationToken)
        {
            var data = await iC_DepartmentRepository.GetByIdAsync((int)DepartmentID, cancellationToken);
            var model = new IC_DepartmentRM()
            {
                ID = data.ID,
                DepartmentName = data.Name
            };
            return model;
        }
    }
}
