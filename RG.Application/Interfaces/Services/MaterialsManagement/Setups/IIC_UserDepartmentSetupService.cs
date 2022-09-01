using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_UserDepartmentSetups.Commands.DataTransferModel;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_UserDepartmentSetups.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.MaterialsManagement.Setups
{
    public interface IIC_UserDepartmentSetupService
    {
        Task<List<UserWiseDepartmentRM>> GetUserWiseDepartmentByUserID(int userID, CancellationToken cancellationToken);
        Task<RResult> SaveUserWiseDepartmentAssaign(List<IC_UserDepartmentSetupDTM> list, CancellationToken cancellationToken);
        Task<RResult> UserDepartmentRemove(List<IC_UserDepartmentSetupDTM> list, CancellationToken cancellationToken);
    }
}
