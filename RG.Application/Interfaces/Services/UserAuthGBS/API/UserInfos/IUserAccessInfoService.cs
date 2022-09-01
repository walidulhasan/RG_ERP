using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.UserAuthGBS.API.UserInfos.Queries;
using RG.Application.Contracts.UserAuthGBS.Setup.DeviceMacWiseUser.RequestResponseModel;
using RG.Application.Contracts.UserAuthGBS.Setup.UsersDeviceDependency.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.UserAuthGBS.API.UserInfos
{
    public interface IUserAccessInfoService
    {
        Task<List<LoggedUserInfoResponseModel>> GetLoggedUserInfo(string UserName, int ProjectID, int? CompanyID, int? BusinessID);
        Task<string> GetUserMenu();
        Task<List<SelectListItem>> GetDDLCompany();
        Task<List<SelectListItem>> GetDDLUserBusiness(int UserID, int companyID);
        Task<List<UserDashboardAccessRM>> GetUserDashboardAccessItems();
        Task<string> AutoGenerateUserScheduler();
        Task<UsersRM> GetUserInfo(int userID, int sourceUserID);
        Task<bool> AuthenticateUserDevice(int userID, string deviceIdentity, string deviceType, string AppVersion = null);
        Task<string> AuthenticatedUserDeviceIdentity(string deviceType);
        Task<List<SelectListItem>> DDLUsersDeviceDependencyType();
        Task<List<SelectListItem>> DDLUsers(string predict);
        Task<UserWiseDeviceDependencyRM> UserWiseDeviceDependency(int userID);
        Task<RResult> UpdateUserWiseDeviceDependency(int userID, int deviceDependencyTypeID);
        Task<RResult> RemoveUserDeviceAuth(int userID);
        Task<DeviceMacWiseUserRM> DeviceMacWiseUser(string deviceMac);
        Task<RResult> RemoveDeviceMacWiseDevice(string deviceMac,int UserID);
    }
}
