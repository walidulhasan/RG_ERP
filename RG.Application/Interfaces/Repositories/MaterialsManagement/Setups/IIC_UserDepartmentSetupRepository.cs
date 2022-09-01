using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_UserDepartmentSetups.Commands.DataTransferModel;
using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.MaterialsManagement.Setups
{
    public interface IIC_UserDepartmentSetupRepository : IGenericRepository<IC_UserDepartmentSetup>
    {
        // Task<List<UserWiseDepartmentResponseModel>> GetUserWiseDepartmentByUserID(int userID, CancellationToken cancellationToken);
        Task<RResult> SaveUserWiseDepartmentAssaign(List<IC_UserDepartmentSetup> list, CancellationToken cancellationToken);
        Task<RResult> UserDepartmentRemove(List<IC_UserDepartmentSetupDTM> list, CancellationToken cancellationToken);
    }
}
